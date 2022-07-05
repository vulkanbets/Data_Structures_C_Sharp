using System;
using System.ComponentModel;
// For De-Bugging
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace WpfAppTreeView
{
    public class WpfAppTreeViewModel : ViewModelBase
    {
        //--------------
        // Constructor
        public WpfAppTreeViewModel()
        {
            _treeViewItemsStruct = new TreeViewDataStruct();
            _treeViewItemsStruct.MyTreeItems?.Add( new Tuple<State, City>(new State("California"), new City("San Diego")) );
            _treeViewItemsStruct.MyTreeItems?.Add( new Tuple<State, City>(new State("California"), new City("Sacramento")) );
            _treeViewItemsStruct.MyTreeItems?.Add( new Tuple<State, City>(new State("California"), new City("Carlsbad")) );
            _treeViewItemsStruct.MyTreeItems?.Add( new Tuple<State, City>(new State("Florida"), new City("Orlando")) );
            _treeViewItemsStruct.MyTreeItems?.Add( new Tuple<State, City>(new State("Florida"), new City("Miami")) );
            _treeViewItemsStruct.MyTreeItems?.Add( new Tuple<State, City>(new State("Florida"), new City("Jacksonville")) );
            _treeViewItemsStruct.MyTreeItems?.Add( new Tuple<State, City>(new State("North Carolina"), new City("Raleigh")) );
            _treeViewItemsStruct.MyTreeItems?.Add( new Tuple<State, City>(new State("North Carolina"), new City("Jacksonville")) );

            // Create the TreeView Data Structure
            _treeViewItemsStruct.CompileTreeStructure();


            // Print-out test variables to see test functionality
            //Task.Run(() =>
            //{
            //    while (true)
            //    {
            //        if (_treeViewItemsStruct.MyTreeItems != null)
            //        {
            //            Trace.WriteLine("\n");
            //            foreach (var itemState in _treeViewItemsStruct.MyTreeDataStruct)
            //            {
            //                Trace.WriteLine("");
            //                Trace.Write(itemState.Item1.StateName);
            //                foreach (var itemCity in itemState.Item2)
            //                {
            //                    Trace.WriteLine("");
            //                    Trace.Write(" |-- ");
            //                    Trace.Write(itemCity.CityName);
            //                }
            //            }
            //            Trace.WriteLine("\n");
            //        }

            //        Thread.Sleep(1250);
            //    }
            //});
        }
        // End Constructor
        //-----------------

        // View
        private MainWindow? _view;

        // Show the View
        public void showView()
        {
            // Create the startup window & initialize DataContext
            _view = new MainWindow()
            {
                Title = "TreeView with Checkboxes Example",
                DataContext = this
            };

            // Show the window
            _view.Show();
        }

        private TreeViewDataStruct? _treeViewItemsStruct;
        public TreeViewDataStruct? TreeViewItemsStruct
        {
            get => _treeViewItemsStruct;
            set
            {
                _treeViewItemsStruct = value;
                OnPropertyChanged("TreeViewItemsList");
            }
        }
    }







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
