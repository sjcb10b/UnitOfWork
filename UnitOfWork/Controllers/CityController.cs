using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UnitOfWork.Data;
using UnitOfWork.Models;

namespace UnitOfWork.Controllers
{
    public class CityController : Controller
    {
        readonly ApplicationDbContext _context;
        
        public CityController(ApplicationDbContext context)
        {
          _context= context;
        }


        public IActionResult Index()
        {
            List<City> Cities;
            Cities = _context.cities.ToList();
            return View(Cities);
        }

        [HttpGet]
        public IActionResult Create()
        {
            City City = new City();
            ViewBag.Countries = GetCountries();
            return View(City);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Create(City City)
        {

            _context.Add(City);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Details(int Id)
        {
            City City = _context.cities
              .Where(c => c.Id == Id).FirstOrDefault();

            return View(City);
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            City City = _context.cities
              .Where(c => c.Id == Id).FirstOrDefault();

            ViewBag.Countries = GetCountries();

            return View(City);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Edit(City City)
        {
            _context.Attach(City);
            _context.Entry(City).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public IActionResult Delete(int Id)
        {
            City City = _context.cities
              .Where(c => c.Id == Id).FirstOrDefault();

            return View(City);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Delete(City City)
        {
            _context.Attach(City);
            _context.Entry(City).State = EntityState.Deleted;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        private List<SelectListItem> GetCountries()
        {
            var lstCountries = new List<SelectListItem>();

            List<Country> Countries = _context.countries.ToList();

            lstCountries = Countries.Select(ct => new SelectListItem()
            {
                Value = ct.Id.ToString(),
                Text = ct.Name
            }).ToList();

            var defItem = new SelectListItem()
            {
                Value = "",
                Text = "----Select Country----"
            };

            lstCountries.Insert(0, defItem);

            return lstCountries;
        }








    }
}
