using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.AccessControl;
using UnitOfWork.Data;
using UnitOfWork.Models;

namespace UnitOfWork.Controllers
{
    public class CountryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CountryController(ApplicationDbContext applicationDb)
        {
            _context = applicationDb;
        }



        public IActionResult Index()
        {
            List<Country> countries;
            countries = _context.countries.ToList();
            return View(countries);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Country country = new Country();
            return View(country);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Create(Country country)
        {
            _context.Add(country);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Details(int Id)
        {
            Country country = GetCountry(Id);
            return View(country);
        }







        [HttpGet]
        public IActionResult CreateModalForm()
        {
            Country country = new Country();
            return PartialView("_CreateModelForm", country);
        }

        [HttpPost]
        public IActionResult CreateModelForm(Country country)
        {
            _context.Add(country);
            _context.SaveChanges();
            return NoContent();
        }




        [HttpGet]
        public IActionResult Edit(int Id)
        {
            Country country = GetCountry(Id);
            return View(country);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Edit(Country country)
        {
            _context.Attach(country);
            _context.Entry(country).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private Country GetCountry(int id)
        {
            Country country;
            country = _context.countries
             .Where(c => c.Id == id).FirstOrDefault();
            return country;

        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            Country country = GetCountry(Id);
            return View(country);
        }


        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Delete(Country country)
        {
            try
            {
                _context.Attach(country);
                _context.Entry(country).State = EntityState.Deleted;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _context.Entry(country).Reload();
                ModelState.AddModelError("", ex.InnerException.Message);
                return View(country);
            }
            return RedirectToAction(nameof(Index));
        }

        public JsonResult GetCountries()
        {
            var lstCountries = new List<SelectListItem>();
            List<Country> countries = _context.countries.ToList();
            lstCountries = countries.Select(ct => new SelectListItem()
            {
                Value = ct.Id.ToString(),
                Text = ct.Name

            }).ToList();

            var defItem = new SelectListItem()
            {
                Value = "",
                Text = " ---- SELECT COUNTRY "
            };
            lstCountries.Insert(0, defItem);



            return Json(lstCountries);
        }


    }
}
