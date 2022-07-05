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
        // Constructor
        public WpfAppTreeViewModel()
        {
            _treeViewItemsList = new TreeViewDataStruct();
            _treeViewItemsList.MyTreeItems?.Add( new Tuple<State, City>(new State("California"), new City("San Diego")) );
            _treeViewItemsList.MyTreeItems?.Add( new Tuple<State, City>(new State("California"), new City("Sacramento")) );
            _treeViewItemsList.MyTreeItems?.Add( new Tuple<State, City>(new State("California"), new City("Carlsbad")) );
            _treeViewItemsList.MyTreeItems?.Add( new Tuple<State, City>(new State("Florida"), new City("Orlando")) );
            _treeViewItemsList.MyTreeItems?.Add( new Tuple<State, City>(new State("Florida"), new City("Miami")) );
            _treeViewItemsList.MyTreeItems?.Add( new Tuple<State, City>(new State("Florida"), new City("Jacksonville")) );
            _treeViewItemsList.MyTreeItems?.Add( new Tuple<State, City>(new State("North Carolina"), new City("Raleigh")) );
            _treeViewItemsList.MyTreeItems?.Add( new Tuple<State, City>(new State("North Carolina"), new City("Jacksonville")) );

            // Create the TreeView Data Structure
            _treeViewItemsList.CompileTreeStructure();


            //MenuItem root = new MenuItem() { Title = "Menu" };
            //MenuItem childItem1 = new MenuItem() { Title = "Child item #1" };
            //childItem1.Items.Add(new MenuItem() { Title = "Child item #1.1" });
            //childItem1.Items.Add(new MenuItem() { Title = "Child item #1.2" });
            //root.Items.Add(childItem1);
            //root.Items.Add(new MenuItem() { Title = "Child item #2" });
            //trvMenu.Items.Add(root);

            Task.Run(() =>
            {
                while (true)
                {
                    if (_treeViewItemsList.MyTreeItems != null)
                    {
                        Trace.WriteLine("\n");
                        foreach (var itemState in _treeViewItemsList.MyTreeDataStruct)
                        {
                            Trace.WriteLine("");
                            Trace.Write(itemState.Item1.StateName);
                            foreach (var itemCity in itemState.Item2)
                            {
                                Trace.WriteLine("");
                                Trace.Write(" |-- ");
                                Trace.Write(itemCity.CityName);
                            }
                        }
                        Trace.WriteLine("\n");
                    }

                    Thread.Sleep(1250);
                }
            });
        }

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

        private TreeViewDataStruct? _treeViewItemsList;
        public TreeViewDataStruct? TreeViewItemsList
        {
            get => _treeViewItemsList;
            set
            {
                _treeViewItemsList = value;
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
