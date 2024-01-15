using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        IWebHostEnvironment _environment;

        public ProductsController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
              _environment = environment;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            return View(await _context.products.ToListAsync());
        }

        public async Task<IActionResult> BarCode(int? id)
        {
            if (id == null || _context.products == null)
            {
                return NotFound();
            }

            var productm = await _context.products.FindAsync(id);
            if (productm == null)
            {
                return NotFound();
            }
            return View(productm);
        }




        // GET: Products/Details/5
        // add picture 
        // GET:  Id
        public async Task<IActionResult> AddPic(int? id)
        {
            if (id == null || _context.products == null)
            {
                return NotFound();
            }

            var productm = await _context.products.FindAsync(id);
            if (productm == null)
            {
                return NotFound();
            }
            return View(productm);
        }
        // add picture function 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPic(int id, [Bind("Id,Title, photo")] Products products)
        {
            String filename = "";
            if (products.photo != null)
            {
                String uploadfolder = Path.Combine(_environment.WebRootPath, "images");
                filename = Guid.NewGuid().ToString() + "_" + products.photo.FileName;
                String filepath = Path.Combine(uploadfolder, filename);
                products.photo.CopyTo(new FileStream(filepath, FileMode.Create));
            }

            var data = _context.products.FirstOrDefault(x => x.Id == id);

            if (data != null)
            {
                data.Id =  products.Id;
                data.Title = products.Title;
                data.ImageA = filename;
            }

            try
            {
                _context.Update(data);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductsExists(products.Id))
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



        // Add O Edit 
        public async Task<IActionResult> AddOEdit(int Id = 0)
        {
            if (Id == 0)
            {
                ViewData["CategoryName"] = new SelectList(_context.categories, "slug", "Name");
                ViewData["YesNo"] = new SelectList(_context.displayYesNo, "optionsyesno", "yesno");
                return View(new Products());
            }
            else
            {

                var products = await _context.products.FindAsync(Id);
                if (products == null)
                {
                    return NotFound();
                }
                ViewData["CategoryName"] = new SelectList(_context.categories, "slug", "Name", products.Category);
                ViewData["YesNo"] = new SelectList(_context.displayYesNo, "optionsyesno", "yesno", products.YesNo);

                return View(products);

            }
        }






        // GET: Products/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.products == null)
        //    {
        //        return NotFound();
        //    }

        //    var products = await _context.products.FindAsync(id);
        //    if (products == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["CategoryName"] = new SelectList(_context.categories, "slug", "Name", products.Category);
        //    ViewData["YesNo"] = new SelectList(_context.displayYesNo, "optionsyesno", "yesno", products.YesNo);

        //    return View(products);
        //}








        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOEdit(int id, [Bind("Id,Title,Description,Category,Price,Qty,ImageA,ImageB,YesNo, CreatedDate")] Products products)
        {
            if (ModelState.IsValid)
            {
                //Insert
                if (id == 0)
                {
                  

                    products.CreatedDate = DateTime.Now;
                    _context.Add(products);
                    await _context.SaveChangesAsync();

                }
                //Update
                else
                {
                    try
                    {
                        _context.Update(products);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ProductsExists(products.Id))
                        { return NotFound(); }
                        else
                        { throw; }
                    }
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.products.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOEdit", products) });
        }



        //if (id != products.Id)
        //{
        //    return NotFound();
        //}

        //if (ModelState.IsValid)
        //{
        //    try
        //    {
        //        _context.Update(products);
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ProductsExists(products.Id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }
        //    return RedirectToAction(nameof(Index));
        //}
        //return View(products);
        // }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.products == null)
            {
                return NotFound();
            }

            var products = await _context.products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.products == null)
            {
                return Problem("Entity set 'ApplicationDbContext.products'  is null.");
            }
            var products = await _context.products.FindAsync(id);
            if (products != null)
            {
                _context.products.Remove(products);
            }

            await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.products.ToList()) });
        }

        private bool ProductsExists(int id)
        {
            return _context.products.Any(e => e.Id == id);
        }
    }
}

