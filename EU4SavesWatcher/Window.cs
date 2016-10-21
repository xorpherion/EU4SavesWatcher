using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EU4SavesWatcher
{
    public class Window : IDisposable
    {
        private Form window;

        private ListView fileList;



        public void Dispose()
        {
            window.Dispose();
        }

        public void Start()
        {
            Init();
            Application.Run(window);
        }

        private void Init()
        {
            InitWindow();
            InitListView();
        }

        private void InitListView()
        {
            fileList = new ListView();
        }

        private void InitWindow()
        {
            window = new Form();
            window.Text = "EU4SavesWatcher";
        }
    }
}
