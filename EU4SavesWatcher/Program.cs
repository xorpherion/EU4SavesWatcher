using System;
using System.Collections.Generic;
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
                window.Start();
            }
        }
    }
}
