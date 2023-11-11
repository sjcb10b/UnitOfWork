using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UnitOfWork.Data;
using UnitOfWork.Models;

namespace UnitOfWork.Areas.Myadmin.Controllers
{
    public class ProductOptionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductOptionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProductOptions
        public async Task<IActionResult> Index()
        {
            return _context.ProductOptions != null ?
                        View(await _context.ProductOptions.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.ProductOptions'  is null.");
        }





        // GET: ProductOptions/Details/5
        public async Task<IActionResult> Details(int? id)
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

        // GET: ProductOptions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductOptions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,option11,option22,option33,option44,option55,option66")] ProductOptions productOptions)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productOptions);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productOptions);
        }

        public async Task<IActionResult> AddOEdit(int Id = 0)
        {
            if (Id == 0)
            {
                return View(new ProductOptions());
            }
            else
            {
                var productOptions = await _context.ProductOptions.FindAsync(Id);

                if (productOptions == null)
                {
                    return NotFound();
                }
                return View(productOptions);
            }



        }

        // GET: ProductOptions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProductOptions == null)
            {
                return NotFound();
            }

            var productOptions = await _context.ProductOptions.FindAsync(id);
            if (productOptions == null)
            {
                return NotFound();
            }
            return View(productOptions);
        }

        // POST: ProductOptions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,option11,option22,option33,option44,option55,option66")] ProductOptions productOptions)
        {
            if (id != productOptions.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productOptions);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductOptionsExists(productOptions.Id))
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
            return View(productOptions);
        }

        // GET: ProductOptions/Delete/5
        public async Task<IActionResult> Delete(int? Id)
        {
            if (Id == null || _context.ProductOptions == null)
            {
                return NotFound();
            }

            var productOptions = await _context.ProductOptions
                .FirstOrDefaultAsync(m => m.Id == Id);
            if (productOptions == null)
            {
                return NotFound();
            }

            return View(productOptions);
        }

        // POST: ProductOptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int Id)
        {
            if (_context.ProductOptions == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ProductOptions'  is null.");
            }
            var productOptions = await _context.ProductOptions.FindAsync(Id);
            if (productOptions != null)
            {
                _context.ProductOptions.Remove(productOptions);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductOptionsExists(int Id)
        {
            return (_context.ProductOptions?.Any(e => e.Id == Id)).GetValueOrDefault();
        }
    }
}
