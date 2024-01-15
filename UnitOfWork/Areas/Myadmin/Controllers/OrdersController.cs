using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UnitOfWork.Data;
using UnitOfWork.Migrations;
using UnitOfWork.Models;

namespace UnitOfWork.Areas.Myadmin.Controllers
{
    [Area("Myadmin")]
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;
        // order items and orders


        


        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Myadmin/Orders
        public async Task<IActionResult> Index()
        {
            var orders = (from s in _context.orders
                            select s).ToList();

            var itemsOrdered = (from c in  _context.orderedItems
                           select c).ToList();




            var fullOrders = from s in orders
                             join st in itemsOrdered on s.forderO equals st.forders
                             
                            select new OrdersViewModel { orders = s, orderedItems = st };

            return View(fullOrders);





            //return _context.orders != null ? 
            //              View(await _context.orders.ToListAsync()) :
            //              Problem("Entity set 'ApplicationDbContext.orders'  is null.");
        }

        public async Task<IActionResult> OrderDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orders = (from s in _context.orders
                          select s).ToList();

            var itemsOrdered = (from c in _context.orderedItems
                                select c).ToList();




            var fullOrdersD = from s in orders
                             join st in itemsOrdered on s.forderO equals st.forders
                              where s.Id == id
                             select new OrdersViewModel { orders = s, orderedItems = st };

            return View(fullOrdersD);


        }


        // GET: Myadmin/Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.orders == null)
            {
                return NotFound();
            }

            var orders = await _context.orders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orders == null)
            {
                return NotFound();
            }

            return View(orders);
        }

        // GET: Myadmin/Orders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Myadmin/Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName_o,LastName_o,Company_o,Street_o,City_o,State_o,ZipCode_o,Phone_o,ccc_name_o,ccc_number_o,expiration_o,cvv_o,ShoppingCartIdCustomer_o")] Orders orders)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orders);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(orders);
        }

        // GET: Myadmin/Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.orders == null)
            {
                return NotFound();
            }

            var orders = await _context.orders.FindAsync(id);
            if (orders == null)
            {
                return NotFound();
            }
            return View(orders);
        }

        // POST: Myadmin/Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName_o,LastName_o,Company_o,Street_o,City_o,State_o,ZipCode_o,Phone_o,ccc_name_o,ccc_number_o,expiration_o,cvv_o,ShoppingCartIdCustomer_o")] Orders orders)
        {
            if (id != orders.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orders);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdersExists(orders.Id))
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
            return View(orders);
        }

        // GET: Myadmin/Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.orders == null)
            {
                return NotFound();
            }

            var orders = await _context.orders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orders == null)
            {
                return NotFound();
            }

            return View(orders);
        }

        // POST: Myadmin/Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.orders == null)
            {
                return Problem("Entity set 'ApplicationDbContext.orders'  is null.");
            }
            var orders = await _context.orders.FindAsync(id);
            if (orders != null)
            {
                _context.orders.Remove(orders);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdersExists(int id)
        {
          return (_context.orders?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
