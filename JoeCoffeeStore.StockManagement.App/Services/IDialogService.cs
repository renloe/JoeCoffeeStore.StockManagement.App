using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoeCoffeeStore.StockManagement.App.Services
{
    public interface IDialogService
    {
        void CloseDetailDialog();
        void ShowDetailDialog();
    }
}
