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
    public class OrdersCartsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrdersCartsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: OrdersCarts
        public async Task<IActionResult> Index()
        {
              return View(await _context.ordersCarts.ToListAsync());
        }

        // GET: OrdersCarts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ordersCarts == null)
            {
                return NotFound();
            }

            var ordersCart = await _context.ordersCarts
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (ordersCart == null)
            {
                return NotFound();
            }

            return View(ordersCart);
        }

        // GET: OrdersCarts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OrdersCarts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,FirstName,LastName,Company,Street,City,State,ZipCode,Country,Phone")] OrdersCart ordersCart)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ordersCart);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ordersCart);
        }

        // GET: OrdersCarts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ordersCarts == null)
            {
                return NotFound();
            }

            var ordersCart = await _context.ordersCarts.FindAsync(id);
            if (ordersCart == null)
            {
                return NotFound();
            }
            return View(ordersCart);
        }

        // POST: OrdersCarts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,FirstName,LastName,Company,Street,City,State,ZipCode,Country,Phone")] OrdersCart ordersCart)
        {
            if (id != ordersCart.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ordersCart);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdersCartExists(ordersCart.OrderId))
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
            return View(ordersCart);
        }

        // GET: OrdersCarts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ordersCarts == null)
            {
                return NotFound();
            }

            var ordersCart = await _context.ordersCarts
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (ordersCart == null)
            {
                return NotFound();
            }

            return View(ordersCart);
        }

        // POST: OrdersCarts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ordersCarts == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ordersCarts'  is null.");
            }
            var ordersCart = await _context.ordersCarts.FindAsync(id);
            if (ordersCart != null)
            {
                _context.ordersCarts.Remove(ordersCart);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdersCartExists(int id)
        {
          return _context.ordersCarts.Any(e => e.OrderId == id);
        }
    }
}
