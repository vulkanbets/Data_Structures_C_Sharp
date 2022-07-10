using System;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace WpfAppTreeView
{

    public class TreeViewDataStruct : PropertyChangedBase
    {
        // Constructor
        public TreeViewDataStruct()
        {
            // Initialize private members
            _myTreeItems = new ObservableCollection<Tuple<State, City>>();
            _myTreeDataStruct = new ObservableCollection<Tuple<State, List<City>>>();
            _records = new ObservableCollection<ActualTreeViewRecord>();
        }

        private ObservableCollection<Tuple<State, List<City>>>? _myTreeDataStruct;
        public ObservableCollection<Tuple<State, List<City>>>? MyTreeDataStruct
        {
            get => _myTreeDataStruct;
            set
            {
                _myTreeDataStruct = value;
                OnPropertyChanged("MyTreeDataStruct");
            }
        }

        private ObservableCollection<Tuple<State, City>>? _myTreeItems;
        public ObservableCollection<Tuple<State, City>>? MyTreeItems
        {
            get => _myTreeItems;
            set
            {
                _myTreeItems = value;
                OnPropertyChanged("MyTreeItems");
            }
        }

        public void CompileTreeStructure()
        {
            // Return a string type, instead of a <State> object list. Filtering
            // by string instead of object. This helps with filtering later
            var statesQuery =
                from items in _myTreeItems
                select items.Item1.StateName;

            // I could only use Distinct() with string types. I will conduct further research
            // on how to accomplish using Distinct() with a custom class or object.
            IEnumerable<string> temp = statesQuery.Distinct();

            // Create a new list of unique states that are
            // associated with each "Child" city
            var statesList = new List<State>();
            foreach (var item in temp)
            {
                statesList.Add(new State(item));
            }


            // Done with the States list, now on to the Cities list.
            // For each "State" in the previous list, create another
            // list of cities that each State is assigned to. 
            foreach (var itemState in statesList)
            {
                if (_myTreeItems != null)
                {
                    var tempCities = new List<City>();
                    foreach (var itemTree in _myTreeItems)
                    {
                        if (itemState.StateName == itemTree.Item1.StateName)
                        {
                            tempCities.Add(itemTree.Item2);
                        }
                    }

                    // Add the new tuple to the data struct
                    _myTreeDataStruct?.Add(new Tuple<State, List<City>>(itemState, tempCities));
                    _records.Add( new ActualTreeViewRecord(itemState, new ObservableCollection<City>(tempCities)) );
                }
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




    public class ActualTreeViewRecord : PropertyChangedBase
    {
        public ActualTreeViewRecord(State state_arg, ObservableCollection<City> cities_arg)
        {
            StateRecord = state_arg;
            CitiesSubRecords = cities_arg;
        }

        public State StateRecord { get; set; }
        public ObservableCollection<City> CitiesSubRecords { get; set; }
    }



    public class State : PropertyChangedBase
    {
        public State(string state)
        {
            StateName = state;
        }

        private string? _strStateName = string.Empty;
        public string? StateName
        {
            get => _strStateName;
            set
            {
                _strStateName = value;
                OnPropertyChanged("StateName");
            }
        }

        private bool? _isChecked = false;
        public bool? IsChecked
        {
            get => _isChecked;
            set
            {
                _isChecked = value;
                OnPropertyChanged("IsChecked");
            }
        }

    }



    public class City : PropertyChangedBase
    {
        public City(string cityname)
        {
            CityName = cityname;
        }

        private string? _strCityName = string.Empty;
        public string? CityName
        {
            get => _strCityName;
            set
            {
                _strCityName = value;
                OnPropertyChanged("CityName");
            }
        }

        private bool? _isChecked = false;
        public bool? IsChecked
        {
            get => _isChecked;
            set
            {
                _isChecked = value;
                OnPropertyChanged("IsChecked");
            }
        }

    }


    //----------------------------------------------------------------------------
    //----------------------------------------------------------------------------
    //----------------------------------------------------------------------------
    // "Notify Property has Changed" Base class.  Classes Inherits from this class
    public class PropertyChangedBase : INotifyPropertyChanged
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
    // "Notify Property has Changed" Base class.  Classes Inherits from this class
    //----------------------------------------------------------------------------
    //----------------------------------------------------------------------------
    //----------------------------------------------------------------------------
}
