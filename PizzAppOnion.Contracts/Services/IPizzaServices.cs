
using PizzAppOnion.Contracts.ViewModels.Pizza;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzAppOnion.Contracts.Services
{
    public interface IPizzaServices
    {
        IReadOnlyList<PizzaDetailsViewModel> GetAllPizzas();
    }
}
