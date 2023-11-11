using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using UnitOfWork.Data;
using UnitOfWork.Migrations;
using UnitOfWork.Models;

namespace UnitOfWork.Controllers
{
    public class MerchandiseController : Controller
    {
        private readonly ApplicationDbContext _context;
        IWebHostEnvironment _environment;

        public MerchandiseController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // GET: Merchandise
        public async Task<IActionResult> Index()
        {
              return _context.merchandise != null ? 
                          View(await _context.merchandise.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.merchandise'  is null.");
        }

        // GET: Merchandise/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.merchandise == null)
            {
                return NotFound();
            }

            var merchandise = await _context.merchandise
                .FirstOrDefaultAsync(m => m.Id == id);
            if (merchandise == null)
            {
                return NotFound();
            }

            return View(merchandise);
        }

        // GET: Merchandise/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Merchandise/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Category,Price,Qty,photo")] MerchandiseView merchandisev)
         //public IActionResult Create([MerchandiseView merchandisev)

        {
            String filename = "";
            if (merchandisev.photo!=null)
            {
                String uploadfolder = Path.Combine(_environment.WebRootPath, "mercha");
                filename= Guid.NewGuid().ToString() + "_" + merchandisev.photo.FileName;
                String filepath = Path.Combine(uploadfolder, filename);
                merchandisev.photo.CopyTo(new FileStream(filepath, FileMode.Create));

            }

            Merchandise m = new Merchandise
            {
                Id = merchandisev.Id,
                Title = merchandisev.Title,
                Description = merchandisev.Description,
                Category = merchandisev.Category,
                Price = merchandisev.Price,
                Qty= merchandisev.Qty,
                ImageA = filename
            };
            _context.merchandise.Add(m);
            await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));
            ViewBag.success = "Record Updated";


            /*
             if (ModelState.IsValid)
             {
                 _context.Add(merchandise);
                 await _context.SaveChangesAsync();
                 return RedirectToAction(nameof(Index));
             }
            */
            return View();
        }

        // get Id to update the photo 
        
        // GET: Merchandise/Edit/5
        public async Task<IActionResult> UpdatePic(int? id)
        {
            if (id == null || _context.merchandise == null)
            {
                return NotFound();
            }

            var merchandise = await _context.merchandise.FindAsync(id);
            if (merchandise == null)
            {
                return NotFound();
            }
            return View(merchandise);
        }




        // GET: Merchandise/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.merchandise == null)
            {
                return NotFound();
            }

            var merchandise = await _context.merchandise.FindAsync(id);
            if (merchandise == null)
            {
                return NotFound();
            }
            return View(merchandise);
        }

        // POST: Merchandise/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Category,Price,Qty,ImageA")] Merchandise merchandise)
        {
            if (id != merchandise.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(merchandise);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MerchandiseExists(merchandise.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(merchandise);
        }

        // GET: Merchandise/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.merchandise == null)
            {
                return NotFound();
            }

            var merchandise = await _context.merchandise
                .FirstOrDefaultAsync(m => m.Id == id);
            if (merchandise == null)
            {
                return NotFound();
            }

            return View(merchandise);
        }

        // POST: Merchandise/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.merchandise == null)
            {
                return Problem("Entity set 'ApplicationDbContext.merchandise'  is null.");
            }
            var merchandise = await _context.merchandise.FindAsync(id);
            if (merchandise != null)
            {
                _context.merchandise.Remove(merchandise);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MerchandiseExists(int id)
        {
          return (_context.merchandise?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
