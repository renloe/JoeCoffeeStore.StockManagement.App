using JoeCoffeeStore.StockManagement.App.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace JoeCoffeeStore.StockManagement.App.Services
{
    public class DialogService : IDialogService
    {
        private Window _coffeeDetailView = null;

        public DialogService()
        {
        }

        public void ShowDetailDialog()
        {
            _coffeeDetailView = new CoffeeDetailView();
            _coffeeDetailView.ShowDialog();
        }

        public void CloseDetailDialog()
        {
            if (_coffeeDetailView != null)
            {
                _coffeeDetailView.Close();
            }
        }

       
    }
}
