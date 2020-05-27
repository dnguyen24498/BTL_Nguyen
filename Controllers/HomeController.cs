using System.Linq;
using System.Threading.Tasks;
using BTL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BTL.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
            
        }
        // GET
        public async Task<IActionResult> Index()
        {
            var products = await _context.Products.Where(x=>x.Price>0).ToListAsync();
            return View(products);
        }
    }
}