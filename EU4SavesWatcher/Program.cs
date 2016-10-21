using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EU4SavesWatcher
{
    class Program
    {
        
        static void Main(string[] args)
        {
            using (var window = new Window())
            {
                var path = File.ReadAllLines("Settings.txt");
                MessageBox.Show(path[0]);
                CorruptFileChecker checker = new CorruptFileChecker(File.ReadAllLines("Settings.txt")[0]);
                checker.OnSaveCorrupt += s =>
                {
                    window.ShowBallonTip("Savegame corrupt: " + s);
                };
                window.Init();
            }
        }
    }
}
