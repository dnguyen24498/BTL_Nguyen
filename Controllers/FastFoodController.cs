using System.Linq;
using System.Threading.Tasks;
using BTL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BTL.Controllers
{
    public class FastFoodController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FastFoodController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET
        public async Task<IActionResult> Index()
        {
            var fastFoodProducts = await _context.Products.Where(x=>x.CategoryId==2).ToListAsync();
            return View(fastFoodProducts);
        }
    }
}