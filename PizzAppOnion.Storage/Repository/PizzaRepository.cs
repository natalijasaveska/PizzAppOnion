using PizzAppOnion.Domain.Entities;
using PizzAppOnion.Domain.Repositories;
using PizzAppOnion.Storage.Database;

namespace PizzAppOnion.Storage.Repository
{
    public class PizzaRepository : IPizzaRepository
    {
        public IReadOnlyList<Pizza> GetAllPizzas()
        {
            return PizzaDatabase.PIZZAS;
        }

        public Pizza GetPizzaById(int pizzaId)
        {
            return PizzaDatabase.PIZZAS.SingleOrDefault(x => x.Id == pizzaId);
        }
    }
}
