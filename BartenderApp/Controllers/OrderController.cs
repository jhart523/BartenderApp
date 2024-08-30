using BartenderApp.Data;
using Microsoft.AspNetCore.Mvc;
using BartenderApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BartenderApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // This query uses Include to load the cocktail information as well as the list of orders based on the DateTime property in descending order.
            // I could have used a view model but this seems simpler for now to get cocktail info on the Order Queue view. 
            var orders = await _context.Orders.
                Include(o => o.Cocktail)
                .OrderByDescending(o => o.OrderDate)
                .ToListAsync();

            return View(orders);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(int cocktailId, string customerName)
        {
            var cocktail = await _context.Cocktails.FindAsync(cocktailId);
            if(cocktail == null)
            {
                return NotFound();
            }

            var order = new Order
            {
                CocktailId = cocktailId,
                CustomerName = customerName,
                OrderPrice = cocktail.Price,
                IsReady = false
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return RedirectToAction("Confirmation","Order", new {orderId = order.Id});
        }

        [HttpPost]
        public async Task<IActionResult> MarkDrinkReady(int orderId)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if(order == null)
            {
                return NotFound();
            }

            order.IsReady = true;
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Confirmation(int orderId)
        {
            var order = await _context.Orders
                .Include(o => o.Cocktail)
                .FirstOrDefaultAsync(o => o.Id == orderId);

            if(order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        public async Task<IActionResult> DeleteOrder(int orderId)
        {
            var order = _context.Orders.Find(orderId);

            if(order == null)
            {
                return NotFound();
            }
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
