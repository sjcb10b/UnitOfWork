using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UnitOfWork.Data;
using UnitOfWork.Models;
using static UnitOfWork.Helper;

namespace UnitOfWork.Areas.Myadmin.Controllers
{
    [Area("Myadmin")]
    public class ProductOptionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductOptionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Myadmin/ProductOptions
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProductOptions.ToListAsync());
        }



        // GET: Myadmin/ProductOptions/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null || _context.ProductOptions == null)
        //    {
        //        return NotFound();
        //    }

        //    var productOptions = await _context.ProductOptions
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (productOptions == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(productOptions);
        //}

        // GET: Myadmin/ProductOptions/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}


        [NoDirectAccess]
        public async Task<IActionResult> AddOEdit(int id = 0)
        {
            if (id == 0)
                return View(new ProductOptions());
            else
            {
                var productOpt = await _context.ProductOptions.FindAsync(id);
                if (productOpt == null)
                {
                    return NotFound();
                }
                return View(productOpt);
            }
        }

        // POST: Myadmin/ProductOptions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,option11,option22,option33,option44,option55,option66")] ProductOptions productOptions)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(productOptions);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(productOptions);
        //}

        //GET: Myadmin/ProductOptions/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.ProductOptions == null)
        //    {
        //        return NotFound();
        //    }

        //    var productOptions = await _context.ProductOptions.FindAsync(id);
        //    if (productOptions == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(productOptions);
        //}

        // POST: Myadmin/ProductOptions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOEdit(int id, [Bind("Id,option11,option22,option33,option44,option55,option66")] ProductOptions productOptions)
        {
            if (ModelState.IsValid)
            {
                //Insert
                if (id == 0)
                {
                    //transactionModel.Date = DateTime.Now;
                    _context.Add(productOptions);
                    await _context.SaveChangesAsync();

                }
                //Update
                else
                {
                    try
                    {
                        _context.Update(productOptions);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ProductOptionsExists(productOptions.Id))
                        { return NotFound(); }
                        else
                        { throw; }
                    }
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.ProductOptions.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOEdit", productOptions) });

        }

        // GET: Myadmin/ProductOptions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProductOptions == null)
            {
                return NotFound();
            }

            var productOptions = await _context.ProductOptions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productOptions == null)
            {
                return NotFound();
            }

            return View(productOptions);
        }

        // POST: Myadmin/ProductOptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProductOptions == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ProductOptions'  is null.");
            }
            var productOptions = await _context.ProductOptions.FindAsync(id);
            if (productOptions != null)
            {
                _context.ProductOptions.Remove(productOptions);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductOptionsExists(int id)
        {
          return (_context.ProductOptions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
