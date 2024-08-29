using Microsoft.AspNetCore.Mvc;
using BartenderApp.Models;

namespace BartenderApp.Data
{
    public class FakeCocktailRepository : ICocktailRepository
    {
        private readonly List<Cocktail> _cocktails;


        public FakeCocktailRepository()
        {
            // Add some beverages for testing
            _cocktails = new List<Cocktail>
            {
                new Cocktail
                 {
                    Id = 1,
                    Name = "Old Fashioned",
                    Price = 6.99,
                    Description = "Simple yet enjoyable"
                 },
                new Cocktail
                {
                   Id = 2,
                   Name = "Margarita",
                   Price = 7.99,
                   Description = "Tequila-based; sweet, tart, and strong flavors."
                }
             };
            
        }// end constructor

        public Cocktail GetById(int id)
        {
            return _cocktails.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Cocktail> GetAll()
        {
            return _cocktails;
        }
    }
}
