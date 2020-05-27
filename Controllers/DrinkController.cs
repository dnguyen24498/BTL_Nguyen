using System.Linq;
using System.Threading.Tasks;
using BTL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BTL.Controllers
{
    public class DrinkController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DrinkController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET
        public async Task<IActionResult> Index()
        {
            var drinkProducts = await _context.Products.Where(x => x.CategoryId == 1).ToListAsync();
            return View(drinkProducts);
        }
    }
}