using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoeCoffeeStore.StockManagement.Model
{
    public class Coffee : INotifyPropertyChanged
    {
        private int _coffeeId;
        public int CoffeeId
        {
            get
            {
                return _coffeeId;
            }
            set
            {
                _coffeeId = value;
                RaisePropertyChanged("CoffeeId");
            }
        }

        private string _coffeeName;
        public string CoffeeName
        {
            get
            {
                return _coffeeName;
            }
            set
            {
                _coffeeName = value;
                RaisePropertyChanged("CoffeeName");
            }
        }

        private int _price;
        public int Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
                RaisePropertyChanged("Price");
            }
        }

        public string Description { get; set; }
        public Country OriginCountry { get; set; }
        public bool InStock { get; set; }
        public int AmountInStock { get; set; }
        public DateTime FirstAddedToStockDate { get; set; }
        public int ImageId { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
