using HomeArun.Data;
using HomeArun.Models;
using HomeLoanArun.Models;
using Microsoft.AspNetCore.Mvc;

namespace HomeArun.Controllers
{
    public class PersonalDetailsController : Controller
    {
        private readonly ApplicationDbcontext _db;

        public PersonalDetailsController(ApplicationDbcontext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var objCtegoryList = _db.Personals;
            return View(objCtegoryList);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(PersonalDetails obj)
        {
            _db.Personals.Add(obj);
            _db.SaveChanges();
            return View();
        }

    }
}
