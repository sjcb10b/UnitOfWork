using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UnitOfWork.Data;
using UnitOfWork.Models;

namespace UnitOfWork.Areas.Myadmin.Controllers
{
    [Area("Myadmin")]
    [Authorize]
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Myadmin/Customers
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.customers.Include(c => c.City);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Myadmin/Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.customers == null)
            {
                return NotFound();
            }

            var customer = await _context.customers
                .Include(c => c.City)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Myadmin/Customers/Create
        public IActionResult Create()
        {
            ViewData["CityId"] = new SelectList(_context.cities, "Id", "Code");
            return View();
        }

        // POST: Myadmin/Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,EmailId,CityId,PhotoUrl")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CityId"] = new SelectList(_context.cities, "Id", "Code", customer.CityId);
            return View(customer);
        }

        // GET: Myadmin/Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.customers == null)
            {
                return NotFound();
            }

            var customer = await _context.customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            ViewData["CityId"] = new SelectList(_context.cities, "Id", "Code", customer.CityId);
            return View(customer);
        }

        // POST: Myadmin/Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,EmailId,CityId,PhotoUrl")] Customer customer)
        {
            if (id != customer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.Id))
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
            ViewData["CityId"] = new SelectList(_context.cities, "Id", "Code", customer.CityId);
            return View(customer);
        }

        // GET: Myadmin/Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.customers == null)
            {
                return NotFound();
            }

            var customer = await _context.customers
                .Include(c => c.City)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Myadmin/Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.customers == null)
            {
                return Problem("Entity set 'ApplicationDbContext.customers'  is null.");
            }
            var customer = await _context.customers.FindAsync(id);
            if (customer != null)
            {
                _context.customers.Remove(customer);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
          return (_context.customers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
