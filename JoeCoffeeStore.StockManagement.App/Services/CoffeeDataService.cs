using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JoeCoffeeStore.StockManagement.Model;
using JoeCoffeeStore.StockManagement.DAL;

namespace JoeCoffeeStore.StockManagement.App.Services
{
    public class CoffeeDataService : ICoffeeDataService
    {
        ICoffeeRepository _repository;

        public CoffeeDataService(ICoffeeRepository repository)
        {
            _repository = repository;
        }

        public Coffee GetCoffeeDetail(int coffeeId)
        {
            return _repository.GetCoffeeById(coffeeId);
        }

        public List<Coffee> GetAllCoffees()
        {
            return _repository.GetCoffees();
        }

        public void UpdateCoffee(Coffee coffee)
        {
            _repository.UpdateCoffee(coffee);
        }

        public void DeleteCoffee(Coffee coffee)
        {
            _repository.DeleteCoffee(coffee);
        }
    }
}
