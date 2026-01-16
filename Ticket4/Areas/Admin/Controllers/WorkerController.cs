using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ticket4.Areas.Admin.ViewModels.Worker;
using Ticket4.DAL;
using Ticket4.Models;

namespace Ticket4.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WorkerController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public WorkerController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            List<Worker> workers = await _context.Workers.Include(w=>w.Position).ToListAsync();
         

            return View(workers);
        }

    }
}
