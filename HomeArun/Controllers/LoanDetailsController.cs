using HomeArun.Data;
using HomeArun.Models;
using Microsoft.AspNetCore.Mvc;

namespace HomeArun.Controllers
{
    public class LoanDetailsController : Controller
    {
        private readonly ApplicationDbcontext _db;

        public LoanDetailsController(ApplicationDbcontext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var objCtegoryList = _db.LoanDetails;
            return View(objCtegoryList);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(LoanDetails obj1)
        {
            _db.LoanDetails.Add(obj1);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
 
}
