using Microsoft.AspNetCore.Mvc;
using WhiteLagoon.Domain.Entities;
using WhiteLagoon.Infrastructure.Data;

namespace WhiteLagoon.Web.Controllers
{
    public class VillaController : Controller
    {
        private readonly ApplicationDbContext _db;

        public VillaController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var villas = _db.Villas.ToList();
            return View(villas);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Villa obj)
        {
            // Custom validations
            if(obj.Name == obj.Description)
            {
                ModelState.AddModelError("", "The Description cannot exactly match the Name.");
            }


            if (ModelState.IsValid)
            {
                _db.Villas.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        public IActionResult Update(int villaId)
        {
            Villa? obj = _db.Villas.FirstOrDefault(_ => _.Id == villaId);
            
            //Villa? obj2 = _db.Villas.Find(villaId);
            //var villa = _db.Villas.Where(_ => _.Price>50 && _.Occupancy > 0).FirstOrDefault();

            if(obj == null)
            {
                return RedirectToAction("Error", "Home");
            }

            return View(obj);
        }

        [HttpPost]
        public IActionResult Update(Villa obj)
        {
            if (ModelState.IsValid)
            {
                _db.Villas.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);
        }
    }
}
