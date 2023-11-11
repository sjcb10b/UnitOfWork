using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using UnitOfWork.Data;
using UnitOfWork.Migrations;
using UnitOfWork.Models;

namespace UnitOfWork.Controllers
{
    public class ItemsController : Controller
    {
        private readonly ApplicationDbContext _context;
        IWebHostEnvironment _environment;

        public ItemsController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // GET: Items
        public async Task<IActionResult> Index()
        {
              return _context.items != null ? 
                          View(await _context.items.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.items'  is null.");
        }

        // GET: Items/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.items == null)
            {
                return NotFound();
            }

            var items = await _context.items
                .FirstOrDefaultAsync(m => m.Id == id);
            if (items == null)
            {
                return NotFound();
            }

            return View(items);
        }

        // GET: Items/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Category,Price,Qty,photo,photob")] Items items)
        {

            String filename = "";
            String filenameb = "";

            if (items.photo != null)
            {
                String uploadfolder = Path.Combine(_environment.WebRootPath, "mercha");
                filename = Guid.NewGuid().ToString() + "_" + items.photo.FileName;
                String filepath = Path.Combine(uploadfolder, filename);
                items.photo.CopyTo(new FileStream(filepath, FileMode.Create));
            }
            if (items.photob != null)
            {
                String uploadfolder = Path.Combine(_environment.WebRootPath, "mercha");
                filenameb = Guid.NewGuid().ToString() + "_" + items.photo.FileName;
                String filepath = Path.Combine(uploadfolder, filenameb);
                items.photob.CopyTo(new FileStream(filepath, FileMode.Create));
            }



            Items m = new Items
            {
                Id = items.Id,
                Title = items.Title,
                Description =items.Description,
                Category = items.Category,
                Price = items.Price,
                Qty = items.Qty,
                ImageA = filename,
                ImageB = filenameb
            };
            _context.items.Add(m);
            await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));
            ViewBag.success = "Record Updated";

            /*
            if (ModelState.IsValid)
            {
                _context.Add(items);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            */



            return View();
        }

        // GET: Items/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.items == null)
            {
                return NotFound();
            }

            var items = await _context.items.FindAsync(id);


            if (items == null)
            {
                return NotFound();
            }
            return View(items);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Category,Price,Qty,ImageA,ImageB, photo,photob")] Items items)
        {
            if (id != items.Id)
            {
                return NotFound();
            }

            String filename = "";

            if (items.photo != null)
            {
                
                String uploadfolder = Path.Combine(_environment.WebRootPath, "mercha");
                filename = Guid.NewGuid().ToString() + "_" + items.photo.FileName;
                String filepath = Path.Combine(uploadfolder, filename);
                items.photo.CopyTo(new FileStream(filepath, FileMode.Create));
            }
            else
            {
             filename = items.ImageA;
            }


            String filenameb = "";
            if (items.photob != null)
            {
               
                String uploadfolder = Path.Combine(_environment.WebRootPath, "mercha");
                filenameb = Guid.NewGuid().ToString() + "_" + items.photob.FileName;
                String filepath = Path.Combine(uploadfolder, filenameb);
                items.photob.CopyTo(new FileStream(filepath, FileMode.Create));
            }
            else
            {
               filenameb = items.ImageB;
            }
           

            if (ModelState.IsValid)
            {
                try
                {
                    
                    Items m = new Items
                    {
                        Id = items.Id,
                        Title = items.Title,
                        Description = items.Description,
                        Category = items.Category,
                        Price = items.Price,
                        Qty = items.Qty,
                        
                        ImageA = filename,
                        ImageB = filenameb
                    };


                    _context.Update(m);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemsExists(items.Id))
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
            // original 
            // return View(items);
            return RedirectToAction(nameof(Index));


        }

        // GET: Items/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.items == null)
            {
                return NotFound();
            }

            var items = await _context.items
                .FirstOrDefaultAsync(m => m.Id == id);
            if (items == null)
            {
                return NotFound();
            }

            return View(items);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.items == null)
            {
                return Problem("Entity set 'ApplicationDbContext.items'  is null.");
            }
            var items = await _context.items.FindAsync(id);
            if (items != null)
            {
                _context.items.Remove(items);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemsExists(int id)
        {
          return (_context.items?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
