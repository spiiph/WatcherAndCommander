using System;
using System.IO;
using System.Security.Permissions;

public class Watcher
{
    private FileSystemWatcher mFileSystemWatcher;

    // Constructor
    public Watcher(String path)
    {
        // Create a new FileSystemFileSystemWatcher and set its properties.
        mFileSystemWatcher = new FileSystemWatcher();

        mFileSystemWatcher.Path = path;

        // Watch for changes in LastAccess and LastWrite times, and
        // the renaming of files or directories.
        mFileSystemWatcher.NotifyFilter = NotifyFilters.LastAccess
                | NotifyFilters.LastWrite | NotifyFilters.FileName
                | NotifyFilters.DirectoryName;

        // Include subdirectories in the watch
        // TODO: Make this a setting
        mFileSystemWatcher.IncludeSubdirectories = true;
    }

    // Public methods
    override public string ToString() { return mFileSystemWatcher.Path; }

    // Event handler wrappers
    public event FileSystemEventHandler Changed
    {
        add { mFileSystemWatcher.Changed += value; }
        remove { mFileSystemWatcher.Changed -= value; }
    }

    public event FileSystemEventHandler Created
    {
        add { mFileSystemWatcher.Created += value; }
        remove { mFileSystemWatcher.Created -= value; }
    }

    public event FileSystemEventHandler Deleted
    {
        add { mFileSystemWatcher.Deleted += value; }
        remove { mFileSystemWatcher.Deleted -= value; }
    }
        
    public event RenamedEventHandler Renamed
    {
        add { mFileSystemWatcher.Renamed += value; }
        remove { mFileSystemWatcher.Renamed -= value; }
    }


    // Public functions
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    public void Run()
    {
        // Begin watching
        mFileSystemWatcher.EnableRaisingEvents = true;
    }

    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    public void Pause()
    {
        // Stop watching
        mFileSystemWatcher.EnableRaisingEvents = false;
    }

    
}
