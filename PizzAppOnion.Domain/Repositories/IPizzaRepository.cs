using PizzAppOnion.Domain.Entities;

namespace PizzAppOnion.Domain.Repositories
{
    public interface IPizzaRepository
    {
        IReadOnlyList<Pizza> GetAllPizzas();
        Pizza GetPizzaById(int pizzaId);
    }
}
