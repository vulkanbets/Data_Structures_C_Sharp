using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppTreeView
{
    public class WpfAppTreeViewModel
    {
        private MainWindow _view;

        public void showWindow()
        {
            // Create the startup window
            MainWindow wnd = new MainWindow();

            // Do stuff here, e.g. to the window
            wnd.Title = "Something else";

            // Show the window
            wnd.Show();
        }

    }
}
