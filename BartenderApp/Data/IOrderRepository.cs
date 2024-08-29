using BartenderApp.Models;

namespace BartenderApp.Data
{
    public interface IOrderRepository
    {
        IEnumerable<Cocktail> GetAll();
    }
}
