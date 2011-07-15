using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text.RegularExpressions;

public class CommanderLogEventArgs : EventArgs
{
    public string Message;

    public CommanderLogEventArgs(string message)
    {
        Message = message;
    }
}

public class Commander
{
    private string mName;
    private string mFilter;
    private string mWorkingDirectory;
    private List<string> mCommands;
    private List<string> mPaths;
    private List<Watcher> mWatchers;
    private Operator mOperator;
    private Regex mFilterRe;


    public delegate void LogEventHandler(object sender, CommanderLogEventArgs e);
    public event LogEventHandler Log;

    public Commander(Commander original)
    {
        Initialize(original.Name,
                   original.mFilter,
                   original.mWorkingDirectory,
                   new List<string>(original.Commands),
                   new List<string>(original.Paths));
    }

    public Commander(string name, 
                     string filter, 
                     string workingDirectory, 
                     List<string> commands, 
                     List<string> paths)
    {
        Initialize(name, filter, workingDirectory, commands, paths);
    }

    private void Initialize(string name,
                            string filter,
                            string workingDirectory,
                            List<string> commands,
                            List<string> paths)
    {
        mName = name;
        mFilter = filter;
        mWorkingDirectory = workingDirectory;
        if (!mWorkingDirectory.EndsWith(Path.DirectorySeparatorChar.ToString()))
        {
            mWorkingDirectory += Path.DirectorySeparatorChar;
        }
        mCommands = commands;
        mPaths = paths;

        mFilterRe = new Regex(mFilter,
                              RegexOptions.Compiled | RegexOptions.IgnoreCase);

        mWatchers = new List<Watcher>();
        foreach (string path in paths)
        {
            Watcher w = new Watcher(path);
            w.Changed += FileChanged;
            w.Created += FileChanged;
            w.Deleted += FileChanged;
            w.Renamed += FileRenamed;
            mWatchers.Add(w);
        }

        mOperator = new Operator();
        mOperator.Log += OperatorLog;
    }

    public void Shutdown()
    {
        mOperator.Dispose();
    }

    //////////////////////////////////////////////////
    // Public information methods
    public override string ToString() { return mName; }

    //////////////////////////////////////////////////
    // Properties
    public string Name {
        get { return mName; }
    }

    public string Filter {
        get { return mFilter; }
    }

    public string WorkingDirectory {
        get { return mWorkingDirectory; }
    }

    public List<string> Commands {
        get { return mCommands; }
    }

    public List<string> Paths {
        get { return mPaths; }
    }


    //////////////////////////////////////////////////
    // Methods to control watchers
    public void Start()
    {
        foreach (Watcher w in mWatchers)
        {
            w.Run();
        }
    }

    public void Stop()
    {
        foreach (Watcher w in mWatchers)
        {
            w.Pause();
        }
    }


    //////////////////////////////////////////////////
    // Log event
    protected virtual void OnLog(string s)
    {
        if (Log != null)
        {
            CommanderLogEventArgs e = new CommanderLogEventArgs(s);
            Log(this, e);
        }
    }


    //////////////////////////////////////////////////
    // Watcher event handlers
    protected virtual void FileChanged(object source, FileSystemEventArgs e)
    {
        string s;
        bool match = mFilterRe.IsMatch(e.Name);
       
        // Log message depending on the file matches our filter or should be
        // ignored
        if (match)
        {
            s = string.Format("[{0}] {1} {2} {3}",
                              mName,
                              DateTime.Now.ToString(),
                              e.ChangeType,
                              e.Name);
        }
        else
        {
            s = string.Format("[{0}] {1} Ignored changes to {2}",
                              mName,
                              DateTime.Now.ToString(),
                              e.Name);
        }
        OnLog(s);

        // Perform operation if the file matches
        if (match)
        {
            Operation o = new Operation(e.ChangeType,
                                        e.FullPath,
                                        mWorkingDirectory,
                                        new List<string>(mCommands));
            mOperator.EnqueueOperation(o);
        }
    }

    protected virtual void FileRenamed(object source, RenamedEventArgs e)
    {
        string s;
        bool match = mFilterRe.IsMatch(e.Name) && mFilterRe.IsMatch(e.OldName);
       
        if (match)
        {
            s = string.Format("[{0}] {1} Renamed {2} => {3}",
                              mName,
                              DateTime.Now.ToString(),
                              e.OldName,
                              e.Name);
        }
        else
        {
            s = string.Format("[{0}] {1} Ignored changes to {2}",
                              mName,
                              DateTime.Now.ToString(),
                              e.Name);
        }
        OnLog(s);

        if (match)
        {
            Operation o = new Operation(e.ChangeType,
                                        e.FullPath,
                                        mWorkingDirectory,
                                        new List<string>(mCommands));

            mOperator.EnqueueOperation(o);
        }
    }

    //////////////////////////////////////////////////
    // Operator event handlers
    protected virtual void OperatorLog(object source, OperatorLogEventArgs e)
    {
        string s = string.Format("[{0}] {1} {2}",
                                 mName,
                                 DateTime.Now.ToString(),
                                 e.Message);
        OnLog(s);
    }

}

