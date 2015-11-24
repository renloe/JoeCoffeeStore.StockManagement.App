using JoeCoffeeStore.StockManagement.App.Extensions;
using JoeCoffeeStore.StockManagement.App.Messages;
using JoeCoffeeStore.StockManagement.App.Services;
using JoeCoffeeStore.StockManagement.App.Utility;
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
        public event PropertyChangedEventHandler PropertyChanged;
        private ICoffeeDataService _coffeeDataService;
        private IDialogService _dialogService;

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

        public void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public CoffeeOverviewViewModel(ICoffeeDataService coffeeDataService, IDialogService dialogService)
        {
            _coffeeDataService = coffeeDataService;
            _dialogService = dialogService;

            LoadData();
            LoadCommands();

            Messenger.Default.Register<UpdateListMessage>(this, OnUpdateListMessageReceived);
        }

        private void LoadCommands()
        {
            EditCommand = new CustomCommand(EditCoffee, CanEditCoffee);
        }

        private void OnUpdateListMessageReceived(UpdateListMessage obj)
        {
            LoadData();
            _dialogService.CloseDetailDialog();
        }

        private void EditCoffee(object obj)
        {
            Messenger.Default.Send<Coffee>(_selectedCoffee);
            _dialogService.ShowDetailDialog();
        }

        private bool CanEditCoffee(object obj)
        {
            if (SelectedCoffee != null)
            {
                return true;
            }
            return false;
        }      

        private void LoadData()
        {
            _coffees = _coffeeDataService.GetAllCoffees().ToObservableCollection();
        }
    }
}
