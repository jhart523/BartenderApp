using System.ComponentModel.DataAnnotations;

namespace BartenderApp.Models
{
    public class Order
    {
        
        public int Id { get; set; }
        public int CocktailId { get; set; }
        public Cocktail Cocktail { get; set; }

        [Required]
        public string CustomerName { get; set; }
        public bool IsReady { get; set; }
        public decimal OrderPrice { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;

    }
}
