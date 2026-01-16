using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Ticket4.Areas.Admin.ViewModels;
using Ticket4.DAL;
using Ticket4.Models;

namespace Ticket4.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class PositionController : Controller
    {
        private readonly AppDbContext _context;

        public PositionController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(Position position)
        {
            List<Position> positions = await _context.Positions.ToListAsync();
            return View(positions);
        }
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePositionVM createPositionVM)
        {
            if (!ModelState.IsValid)
            {
                return View(createPositionVM);

            }
            Position position = new()
            {
                Name = createPositionVM.Name,
            };


            await _context.Positions.AddAsync(position);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int id)
        {
            Position? position = await _context.Positions.FirstOrDefaultAsync(x => x.Id == id);
            if (position == null)
            {
                return NotFound();
            }
            return View(position);

        }
        [HttpPost]
        public async Task<IActionResult> Update(Position position)
        {
            if (!ModelState.IsValid)
            {
                return View(position);
            }
            Position? dbposition = await _context.Positions.FirstOrDefaultAsync(x => x.Id == position.Id);
            if (dbposition == null)
            {
                return NotFound();
            }
            if (await _context.Positions.AnyAsync(x => x.Name == position.Name && x.Id != dbposition.Id))
            {
                ModelState.AddModelError("Name", "This name is aldready taken");
                return View(position);
            }
            dbposition.Name = position.Name;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


        }
        public async Task<IActionResult> Delete (int id)
        {
            Position? position = await _context.Positions.FirstOrDefaultAsync(x => x.Id == id);
            if(position == null) { return NotFound(); }
            _context.Positions.Remove(position);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }

}
