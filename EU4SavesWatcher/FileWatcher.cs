using System;
using System.IO;

namespace EU4SavesWatcher
{
    public class FileWatcher : IDisposable
    {
        private string directory;
        private FileSystemWatcher watcher;

        public event Action<String> OnFileModified;

        public FileWatcher(String directory)
        {
            this.directory = directory;
            watcher = new FileSystemWatcher(directory);
            watcher.Changed += fileChangeHandler;

            watcher.EnableRaisingEvents = true;
        }

        private void fileChangeHandler(object sender, FileSystemEventArgs e)
        {
            OnFileModified?.Invoke(e.FullPath);
        }

        public void Dispose()
        {
            watcher.Dispose();
        }
    }
}