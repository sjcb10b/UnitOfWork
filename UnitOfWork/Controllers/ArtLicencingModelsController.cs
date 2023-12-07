using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UnitOfWork.Data;
using UnitOfWork.Models;

namespace UnitOfWork.Controllers
{
    public class ArtLicencingModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ArtLicencingModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ArtLicencingModels
        public async Task<IActionResult> Index()
        {
              return _context.ArtLicencingModel != null ? 
                          View(await _context.ArtLicencingModel.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.ArtLicencingModel'  is null.");
        }

        // GET: ArtLicencingModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ArtLicencingModel == null)
            {
                return NotFound();
            }

            var artLicencingModel = await _context.ArtLicencingModel
                .FirstOrDefaultAsync(m => m.LId == id);
            if (artLicencingModel == null)
            {
                return NotFound();
            }

            return View(artLicencingModel);
        }

        // GET: ArtLicencingModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ArtLicencingModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LId,Title,Artist,Description,Brand,Images,OriginalPublisherID,Cost,RetailPrice,SalesPrice,Warranty,ProductType,FrameColor,Style,Category,PhotoOrientation,Color,Tags,SEOTitle,SEoKeywords,MetaDescription")] ArtLicencingModel artLicencingModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(artLicencingModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(artLicencingModel);
        }

        // GET: ArtLicencingModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ArtLicencingModel == null)
            {
                return NotFound();
            }

            var artLicencingModel = await _context.ArtLicencingModel.FindAsync(id);
            if (artLicencingModel == null)
            {
                return NotFound();
            }
            return View(artLicencingModel);
        }

        // POST: ArtLicencingModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LId,Title,Artist,Description,Brand,Images,OriginalPublisherID,Cost,RetailPrice,SalesPrice,Warranty,ProductType,FrameColor,Style,Category,PhotoOrientation,Color,Tags,SEOTitle,SEoKeywords,MetaDescription")] ArtLicencingModel artLicencingModel)
        {
            if (id != artLicencingModel.LId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(artLicencingModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArtLicencingModelExists(artLicencingModel.LId))
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
            return View(artLicencingModel);
        }

        // GET: ArtLicencingModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ArtLicencingModel == null)
            {
                return NotFound();
            }

            var artLicencingModel = await _context.ArtLicencingModel
                .FirstOrDefaultAsync(m => m.LId == id);
            if (artLicencingModel == null)
            {
                return NotFound();
            }

            return View(artLicencingModel);
        }

        // POST: ArtLicencingModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ArtLicencingModel == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ArtLicencingModel'  is null.");
            }
            var artLicencingModel = await _context.ArtLicencingModel.FindAsync(id);
            if (artLicencingModel != null)
            {
                _context.ArtLicencingModel.Remove(artLicencingModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArtLicencingModelExists(int id)
        {
          return (_context.ArtLicencingModel?.Any(e => e.LId == id)).GetValueOrDefault();
        }
    }
}
