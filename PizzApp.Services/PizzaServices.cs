using PizzAppOnion.Contracts.Services;
using PizzAppOnion.Contracts.ViewModels.Pizza;
using PizzAppOnion.Domain.Entities;
using PizzAppOnion.Domain.Repositories;
using PizzAppOnion.Services.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzAppOnion.Services
{
    public class PizzaServices : IPizzaServices
    {
        private readonly IPizzaRepository _pizzaRepository;

        public  PizzaServices(IPizzaRepository pizzaRepository)
        {
            _pizzaRepository = pizzaRepository;
        }

        public IReadOnlyList<PizzaDetailsViewModel> GetAllPizzas()
        {
            IReadOnlyList<Pizza> dbPizzas = _pizzaRepository.GetAllPizzas();

            return dbPizzas.Select(x => x.ToPizzaDetailsViewModel()).ToArray();   
        }
    }
}
