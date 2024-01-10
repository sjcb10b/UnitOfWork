using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using UnitOfWork.Data;
using UnitOfWork.Models;
using static UnitOfWork.Helper;

namespace UnitOfWork.Areas.Myadmin.Controllers
{
    [Area("Myadmin")]
    public class CategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;
        IWebHostEnvironment _environment;

        public CategoriesController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;

        }

        // GET: Myadmin/Categories
        public async Task<IActionResult> Index()
        {
            return View(await _context.categories.ToListAsync());
        }

   

        [NoDirectAccess]
     
        public async Task<IActionResult> AddOEdit(int id = 0)
         {
            if (id == 0)
            {
                return View(new Category());
            }
            else
            {
                var category = await _context.categories.FindAsync(id);
                if (category == null)
                {
                    return NotFound();
                }
                return View(category);

            }

         }




 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOEdit(int id, [Bind("Id,Name,DisplayOrder,CreatedDate,slug,Description")] Category category)
        {
            if (ModelState.IsValid)
            {
                //Insert
                if (id == 0)
                {
                    //category.Date = DateTime.Now;
                    _context.Add(category);
                    await _context.SaveChangesAsync();

                }
                //Update
                else
                {
                    try
                    {
                        _context.Update(category);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!CategoryExists(category.Id))
                        { return NotFound(); }
                        else
                        { throw; }
                    }
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.categories.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOEdit", category) });




        }

        // GET: Myadmin/Categories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.categories == null)
            {
                return NotFound();
            }

            var category = await _context.categories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // add picture 
        // GET:  Id
        public async Task<IActionResult> AddPic(int? id)
        {
            if (id == null || _context.categories == null)
            {
                return NotFound();
            }

            var categorym = await _context.categories.FindAsync(id);
            if (categorym == null)
            {
                return NotFound();
            }
            return View(categorym);
        }
        // add picture function 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPic(int id, [Bind("Id,photo")] Category category)
        {
            String filename = "";
            if (category.photo != null)
            {
                String uploadfolder = Path.Combine(_environment.WebRootPath, "images");
                filename = Guid.NewGuid().ToString() + "_" + category.photo.FileName;
                String filepath = Path.Combine(uploadfolder, filename);
                category.photo.CopyTo(new FileStream(filepath, FileMode.Create));
            }

            var data = _context.categories.FirstOrDefault(x => x.Id == id);

            if (data != null)
            {
                data.Id = category.Id;
                data.ImageCategoryA = filename;
            }

            try
            {
                _context.Update(data);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(category.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            //return View(inventoryNModel);
            return RedirectToAction(nameof(Index));

        }





            // POST: Myadmin/Categories/Delete/5
            [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.categories == null)
            {
                return Problem("Entity set 'ApplicationDbContext.categories'  is null.");
            }
            var category = await _context.categories.FindAsync(id);
            if (category != null)
            {
                _context.categories.Remove(category);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(int id)
        {
          return (_context.categories?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
