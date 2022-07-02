using System.ComponentModel;

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















    //-----------------------------------------------------------
    //-----------------------------------------------------------
    //-----------------------------------------------------------
    //-----------------------------------------------------------
    //-----------------------------------------------------------
    //-----------------------------------------------------------
    public class City : ViewModelBase
    {
        private string _strCityName = string.Empty;
        public string CityName
        {
            get
            {
                return _strCityName;
            }
            set
            {
                _strCityName = value;
                OnPropertyChanged("CityName");
            }
        }

        public City(string cityname)
        {
            CityName = cityname;
        }
    }
    //-----------------------------------------------------------
    //-----------------------------------------------------------
    //-----------------------------------------------------------
    //-----------------------------------------------------------
    //-----------------------------------------------------------
    //-----------------------------------------------------------

















    //-----------------------------------------------------------
    //-----------------------------------------------------------
    //-----------------------------------------------------------
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
    // ViewModel Base class.  ViewModel Inherits from this class
    //-----------------------------------------------------------
    //-----------------------------------------------------------
    //-----------------------------------------------------------
}
