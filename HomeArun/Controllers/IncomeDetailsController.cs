using HomeArun.Data;
using HomeArun.Models;
using Microsoft.AspNetCore.Mvc;

namespace HomeArun.Controllers
{
    public class IncomeDetailsController : Controller
    {
        private readonly ApplicationDbcontext _db;

        public IncomeDetailsController(ApplicationDbcontext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var objCtegoryList = _db.Incomes;
            return View(objCtegoryList);
        }
        [HttpGet]
        public IActionResult Create1()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create1(IncomeDetails obj1)
        {
            _db.Incomes.Add(obj1);
            _db.SaveChanges();
            return View();
        }
        
    }
}
