using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppTreeView
{
    public class WpfAppTreeViewModel : ViewModelBase
    {
        // View
        private MainWindow? _view;

        // Show the View
        public void showView()
        {
            // Create the startup window & initialize DataContext
            _view = new MainWindow()
            {
                Title = "TreeView Example",
                DataContext = this
            };

            // Show the window
            _view.Show();
        }

    }






    // ViewModel Base class.  ViewModel Inherits from this class
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string propname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propname));
            }
        }

    }

}
