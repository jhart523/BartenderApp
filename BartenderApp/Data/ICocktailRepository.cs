using BartenderApp.Models;

namespace BartenderApp.Data
{
    public interface ICocktailRepository
    {
        Cocktail GetById(int id);
        IEnumerable<Cocktail> GetAll();

    }
}
