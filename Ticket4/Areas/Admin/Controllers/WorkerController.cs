using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ticket4.Areas.Admin.ViewModels.Worker;
using Ticket4.DAL;
using Ticket4.Models;
using Ticket4.Utilities.Enums;
using Ticket4.Utilities.Extensions;

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
            List<Worker> workers = await _context.Workers.Include(w => w.Position).ToListAsync();


            return View(workers);
        }
        public async Task<IActionResult> Create()
        {
            List<Position> positions = await _context.Positions.ToListAsync();
            CreateWorkerVM createWorkerVM = new() {
                Positions = positions };
            return View(createWorkerVM);

        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateWorkerVM createWorkerVM)
        {
            if (!ModelState.IsValid)
            {
                createWorkerVM.Positions = await _context.Positions.ToListAsync();
            }
            if (!createWorkerVM.ImageFile.ValidateType("image"))
            {
                ModelState.AddModelError("ImageFile", "Please select a valid Image File ");
                createWorkerVM.Positions = await _context.Positions.ToListAsync();
                return View(createWorkerVM);



            }
            if (!createWorkerVM.ImageFile.ValidateSize(FileSize.MB, 2))
            {
                ModelState.AddModelError("ImageFile", "This file size is not suitable");
                createWorkerVM.Positions = await _context.Positions.ToListAsync();
                return View(createWorkerVM);

            }
            Worker worker = new()
            {
                Name = createWorkerVM.Name,
                Surname = createWorkerVM.Surname,
                ImageUrl = await createWorkerVM.ImageFile.CreateFileAsync(_env.WebRootPath, "assets", "img")

            };
            await _context.Workers.AddAsync(worker);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));



        }
        public async Task<IActionResult> Update(int id)
        {
            Worker? worker = await _context.Workers.FirstOrDefaultAsync(w => w.Id == id);
            if (worker == null)
            {
                return NotFound();
            }
            UpdateWorkerVM updateWorkerVM = new()
            {
                Id = worker.Id,
                Name = worker.Name,
                Surname = worker.Surname,
                PositionId = worker.PositionId,
                Positions = await _context.Positions.ToListAsync()


            };
            return View(updateWorkerVM);

        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, UpdateWorkerVM updateWorkerVM)
        {
            Worker? worker = await _context.Workers.FirstOrDefaultAsync(worker => worker.Id == id);
            if (worker == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                updateWorkerVM.Positions = await _context.Positions.ToListAsync();
                return View(updateWorkerVM);


            }
            if (await _context.Workers.AnyAsync(w => w.Name == updateWorkerVM.Name && w.Id != id)) {
                ModelState.AddModelError("Name", "This name is already given");
                updateWorkerVM.Positions = await _context.Positions.ToListAsync();
                return View(updateWorkerVM);

            }

            
        
            worker.Surname = updateWorkerVM.Surname;
            worker.Name = updateWorkerVM.Name;
            worker.PositionId = updateWorkerVM.PositionId;
            if (!updateWorkerVM.ImageFile.ValidateType("image"))
            {
                ModelState.AddModelError("ImageFile", "Please add valid file type");
                updateWorkerVM.Positions = await _context.Positions.ToListAsync();
                return View(updateWorkerVM);
            }
            if (!updateWorkerVM.ImageFile.ValidateSize(FileSize.MB, 2))
            {
                ModelState.AddModelError("ImageFile", "The size is not suitable");
                updateWorkerVM.Positions = await _context.Positions.ToListAsync();
                return View(updateWorkerVM);
            }
            worker.ImageUrl = await updateWorkerVM.ImageFile.CreateFileAsync(_env.WebRootPath, "assets", "img");
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult> Delete(int id)
        {
            Worker? worker = await _context.Workers.FirstOrDefaultAsync(worker => worker.Id == id);
            if (worker == null)
            {
                return NotFound();
            }
            _context.Workers.Remove(worker);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


        }
    } }
