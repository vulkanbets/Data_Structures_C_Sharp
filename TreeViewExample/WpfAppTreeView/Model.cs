using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace WpfAppTreeView
{
    //----------------------------------------------------------------------------
    //----------------------------------------------------------------------------
    //----------------------------------------------------------------------------
    //----------------------------------------------------------------------------
    //----------------------------------------------------------------------------
    //----------------------------------------------------------------------------
    public class TreeViewDataStruct : ViewModelBase
    {
        // Constructor
        public TreeViewDataStruct()
        {
            // Initialize private members
            _myTreeItems = new ObservableCollection<Tuple<State, City>>();
            _myTreeDataStruct = new ObservableCollection<Tuple<State, List<City>>>();
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

            // I could only use Distinct() with string types. I must conduct further research
            // on how to accomplish using Distinct() with a custom class or object.
            IEnumerable<string> temp = statesQuery.Distinct();

            // Create a new list of unique states that are
            // associated with each "Child" city
            var statesList = new List<State>();
            foreach (var item in temp)
            {
                statesList.Add(new State(item));
            }


            var tempCities = new List<City>();
            foreach (var itemState in statesList)
            {
                tempCities.Clear();
                foreach (var itemTree in _myTreeItems)
                {
                    if (itemState.StateName  ==  itemTree.Item1.StateName)
                    {
                        tempCities.Add(itemTree.Item2);
                    }
                }
                _myTreeDataStruct?.Add(new Tuple<State, List<City>>(itemState, tempCities));
            }










        }
    }
    //----------------------------------------------------------------------------
    //----------------------------------------------------------------------------
    //----------------------------------------------------------------------------
    //----------------------------------------------------------------------------
    //----------------------------------------------------------------------------
    //----------------------------------------------------------------------------









    //----------------------------------------------------------------------------
    //----------------------------------------------------------------------------
    //----------------------------------------------------------------------------
    //----------------------------------------------------------------------------
    //----------------------------------------------------------------------------
    //----------------------------------------------------------------------------
    public class City : ViewModelBase
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
    }
    //----------------------------------------------------------------------------
    //----------------------------------------------------------------------------
    //----------------------------------------------------------------------------
    //----------------------------------------------------------------------------
    //----------------------------------------------------------------------------
    //----------------------------------------------------------------------------









    //----------------------------------------------------------------------------
    //----------------------------------------------------------------------------
    //----------------------------------------------------------------------------
    //----------------------------------------------------------------------------
    //----------------------------------------------------------------------------
    //----------------------------------------------------------------------------
    public class State : ViewModelBase
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
    }
    //----------------------------------------------------------------------------
    //----------------------------------------------------------------------------
    //----------------------------------------------------------------------------
    //----------------------------------------------------------------------------
    //----------------------------------------------------------------------------
    //----------------------------------------------------------------------------
}
