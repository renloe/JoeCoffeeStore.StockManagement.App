using JoeCoffeeStore.StockManagement.App.Extensions;
using JoeCoffeeStore.StockManagement.App.Services;
using JoeCoffeeStore.StockManagement.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace JoeCoffeeStore.StockManagement.App.ViewModel
{
    public class CoffeeOverviewViewModel : INotifyPropertyChanged
    {
        private ICoffeeDataService _coffeeDataService;
        private IDialogService _dialogService;

        public CoffeeOverviewViewModel(ICoffeeDataService coffeeDataService, IDialogService dialogService)
        {
            _coffeeDataService = coffeeDataService;
            _dialogService = dialogService;
        }

        private ObservableCollection<Coffee> _coffees;
        public ObservableCollection<Coffee> Coffees
        {
            get
            {
                return _coffees;
            }
            set
            {
                _coffees = value;
                RaisePropertyChanged("Coffees");
            }
        }

        private Coffee _selectedCoffee;
        public Coffee SelectedCoffee
        {
            get
            {
                return _selectedCoffee;
            }
            set
            {
                _selectedCoffee = value;
                RaisePropertyChanged("SelectedCoffee");
            }
        }

        public ICommand EditCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void Load()
        {
            _coffees = _coffeeDataService.GetAllCoffees().ToObservableCollection();
        }
    }
}
