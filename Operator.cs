using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

public class OperatorLogEventArgs : EventArgs
{
    public string Message;

    public OperatorLogEventArgs(string message)
    {
        Message = message;
    }
}

class Operation
{
    public Operation() {}

    public Operation(WatcherChangeTypes changeType, 
                     string path,
                     string workingDirectory,
                     List<string> commands)
    {
        ChangeType = changeType;
        Path = path;
        OldPath = path;
        WorkingDirectory = workingDirectory;
        Commands = commands;
    }

    public Operation(WatcherChangeTypes changeType, 
                     string path,
                     string oldPath,
                     string workingDirectory,
                     List<string> commands)
    {
        ChangeType = changeType;
        Path = path;
        OldPath = oldPath;
        WorkingDirectory = workingDirectory;
        Commands = commands;
    }

    public WatcherChangeTypes ChangeType;
    public string Path;
    public string OldPath;
    public string WorkingDirectory;
    public List<string> Commands;

    public string Name {
        get { return System.IO.Path.GetFileName(Path); }
    }

    public string RelPath {
        get { return Path.Replace(WorkingDirectory, ""); }
    }

    public string Directory
    {
        get { return System.IO.Path.GetDirectoryName(Path); }
    }

    public string OldName
    {
        get { return System.IO.Path.GetFileName(OldPath); }
    }

    public string OldRelPath {
        get { return OldPath.Replace(WorkingDirectory, ""); }
    }

    public string OldDirectory
    {
        get { return System.IO.Path.GetDirectoryName(OldPath); }
    }

    public override bool Equals(object obj)
    {
        if (obj != null && obj.GetType() == GetType())
        {
            Operation o = obj as Operation;
            return o.Path == Path && o.OldPath == OldPath;
        }
        else
        {
            return false;
        }
    }

    public override int GetHashCode()
    {
        return Path.GetHashCode() ^ OldPath.GetHashCode();
    }
}

class MatchEvaluatorHelper
{
    private Dictionary<string, string> mMacros = 
            new Dictionary<string, string>();

    private Operation mOperation;

    public MatchEvaluatorHelper(Operation o)
    {
        mOperation = o;
        mMacros.Add("path", mOperation.Path);
        mMacros.Add("relpath", mOperation.RelPath);
        mMacros.Add("name", mOperation.Name);
        mMacros.Add("directory", mOperation.Directory);
        mMacros.Add("oldpath", mOperation.OldPath);
        mMacros.Add("oldrelpath", mOperation.OldRelPath);
        mMacros.Add("oldname", mOperation.OldName);
        mMacros.Add("olddirectory", mOperation.OldDirectory);
    }

    public string EvaluateMatch(Match m)
    {
        string repl;

        // Replace the macro with the path
        try
        {
            repl = mMacros[m.Groups[2].Value];
        }
        catch (KeyNotFoundException)
        {
            repl = "";
        }

        // Apply modifiers
        foreach (char c in m.Groups[1].Value)
        {
            switch (c)
            {
                // Escape \ and . in filenames, for regexps
                case 'e':
                    repl = Regex.Replace(repl, @"[.\\]", @"\$&");
                    break;
                default:
                    break;
            }
        }

        return repl;
    }
}

class Operator : IDisposable
{
    private EventWaitHandle mTaskQueuedEvent;
    private Thread mWorker;
    private readonly object mLocker;
    Queue<Operation> mOperations;
    private int mCount;

    public delegate void LogEventHandler(object sender, OperatorLogEventArgs e);
    public event LogEventHandler Log;

    public Operator()
    {
        mTaskQueuedEvent = new AutoResetEvent(false);
        mWorker = new Thread(Run);
        mLocker = new object();
        mOperations = new Queue<Operation>();
        mCount = 0;

        mWorker.Start();
    }

    public void EnqueueOperation(Operation o)
    {
        lock (mLocker)
        {
            if (!mOperations.Contains(o))
            {
                mOperations.Enqueue(o);
            }
        }
        mTaskQueuedEvent.Set();
    }

    public void Dispose()
    {
        EnqueueOperation(null);
        mWorker.Join();
        mTaskQueuedEvent.Close();
    }

    public void Run()
    {
        while (true)
        {
            Operation o = null;

            lock (mLocker)
            {
                if (mOperations.Count > 0)
                {
                    o = mOperations.Dequeue();
                    // Instance disposed
                    if (o == null)
                    {
                        return;
                    }
                }
            }

            if (o != null)
            {
                // Increase operation count for this operator
                mCount++;
                // Process the commands of one operation
                processCommands(o);
                OnLog(string.Format("[{0}] Operation completed",
                                    mCount));
            }
            else
            {
                // Wait for a new task
                mTaskQueuedEvent.WaitOne();
                // Delay processing of new task until all changes have arrived
                Thread.Sleep(1000);
            }
        }
    }

    private void processCommands(Operation o)
    {
        MatchEvaluatorHelper evalHelper = new MatchEvaluatorHelper(o);

        foreach (string c in o.Commands)
        {
            if (commandIsValid(c, o.ChangeType))
            {
                string newCommand = expandCommand(c, evalHelper);
                int exitCode;
                string output = "";

                OnLog(string.Format("[{0}] Running {1}",
                                    mCount,
                                    newCommand));


                exitCode = executeCommand(newCommand,
                                          o.WorkingDirectory,
                                          ref output);
                if (exitCode == 0)
                {
                    OnLog(string.Format("[{0}] Result: Success",
                                        mCount));
                }
                else
                {
                    OnLog(string.Format("[{0}] Result: Failure ({1})",
                                        mCount,
                                        exitCode));
                    OnLog(string.Format("[{0}] Output: {1}",
                                        mCount,
                                        output));
                }
            }
        }
    }

    private int executeCommand(string command,
                               string workingDirectory,
                               ref string output)
    {
        // Maximum wait time: 5 minutes
        const int maxWait = 5*60*1000; 
        Process p = new Process();

        p.StartInfo.FileName = "cmd.exe";
        p.StartInfo.Arguments = "/c " + command;
        p.StartInfo.UseShellExecute = false;
        p.StartInfo.RedirectStandardOutput = true;
        p.StartInfo.RedirectStandardError = true;
        p.StartInfo.CreateNoWindow = true;
        p.StartInfo.WorkingDirectory = workingDirectory;
        p.Start();

        if (p.WaitForExit(maxWait))
        {
            output = p.StandardOutput.ReadToEnd();
            output += p.StandardError.ReadToEnd();
        }
        else
        {
            output = p.StandardOutput.ReadToEnd();
            output += p.StandardError.ReadToEnd();
            output += "*** Maximum execution time exceeded ***";
        }

        return p.ExitCode;
    }

    private string expandCommand(string c, MatchEvaluatorHelper e)
    {
        Regex pattern = new Regex(@"\${(?:([e]+):)?(\w+)}", RegexOptions.Compiled);
        MatchEvaluator evaluator = new MatchEvaluator(e.EvaluateMatch);
        return pattern.Replace(c, evaluator);
    }

    private bool commandIsValid(string c, WatcherChangeTypes t)
    {
        Regex re = new Regex(@"\${(?:\w+:)?(?:path|relpath|name|directory)",
                             RegexOptions.Compiled);
        Regex reOld = new Regex(@"\${(?:\w+:)?old(?:path|relpath|name|directory)",
                                RegexOptions.Compiled);

        // Ignore commands on the old file if a file was created
        if (t == WatcherChangeTypes.Created && reOld.IsMatch(c))
        {
            return false;
        }

        // Ignore commands on the new file if a file was deleted
        if (t == WatcherChangeTypes.Deleted && re.IsMatch(c))
        {
            return false;
        }

        return true;
    }

    protected virtual void OnLog(string s)
    {
        if (Log != null)
        {
            OperatorLogEventArgs e = new OperatorLogEventArgs(s);
            Log(this, e);
        }
    }

}
