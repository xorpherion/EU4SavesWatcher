using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EU4SavesWatcher
{
    public class CorruptFileChecker : IDisposable
    {
        private FileWatcher fileWatcher;

        public event Action<String> OnSaveCorrupt;

        public CorruptFileChecker(String eu4SavesDirectory)
        {
            fileWatcher = new FileWatcher(eu4SavesDirectory);
            fileWatcher.OnFileModified += OnFileModifiedHandler;
        }

        private void OnFileModifiedHandler(string s)
        {
            var info = new FileInfo(s);
            if (info.Length < 1024)
            {
                OnSaveCorrupt?.Invoke(s);
            }


        }

        public void Dispose()
        {
            fileWatcher.Dispose();
        }
    }
}
