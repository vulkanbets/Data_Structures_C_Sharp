using System;
using System.Collections.ObjectModel;
// For De-Bugging
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;


namespace WpfAppTreeView
{
    public class WpfAppTreeViewModel : PropertyChangedBase
    {

        //-----------------
        // Private members
        //-----------------

        // View
        private MainWindow? _view;



        //-----------------
        // Public members
        //-----------------

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


        //--------------
        // Constructor
        //--------------
        public WpfAppTreeViewModel()
        {
            // Initialize private members
            _treeViewItemsStruct = new TreeViewDataStruct();
            _records = new ObservableCollection<ActualTreeViewRecord>();

            // The lines below these comments should never be part of the ViewModel, but were
            // needed to test this TreeView Data Structure.  These lines are just for testing purposes
            //----------------------------------------------------------------------------------------------------
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
            _records = _treeViewItemsStruct.Records;
            //----------------------------------------------------------------------------------------------------
            // The lines above these comments should never be part of the ViewModel, but were
            // needed to test this TreeView Data Structure.  These lines are just for testing purposes
        }
        //-----------------
        // End Constructor
        //-----------------



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


        private ObservableCollection<ActualTreeViewRecord> _records;
        public ObservableCollection<ActualTreeViewRecord> Records
        {
            get => _records;
            set
            {
                _records = value;
                OnPropertyChanged("Records");
            }
        }

    }

}
