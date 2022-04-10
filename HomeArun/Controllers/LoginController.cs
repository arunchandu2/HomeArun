using HomeArun.Data;
using HomeArun.Models;
using Microsoft.AspNetCore.Mvc;

namespace HomeArun.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDbcontext _db;

        public LoginController(ApplicationDbcontext db)
        {
            _db = db;
        }
        public IActionResult LoanTracker()
        {
            return View();
        }
        //public 
        public IActionResult Index()
        {
            var objCtegoryList = _db.Personals;
            return View(objCtegoryList);
        }
        //public IActionResult CustomerPage()
        //{
        //    return View();
        //}
        //[HttpPost]
        public IActionResult CustomerPage()

        {
            string aid;
            int aid1;
            aid = (TempData["appid"]).ToString();
            aid1 = int.Parse(aid);

            var firstname = (from d in _db.Personals
                             where d.ApplicationID == aid1
                             select d.FirstName).FirstOrDefault();

            var lastname = (from c in _db.Personals
                            where c.ApplicationID == aid1
                            select c.LastName).FirstOrDefault();


            ViewBag.fname1 = firstname;
            ViewBag.lname1 = lastname;
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(string apnumber,string pass )
        {
            //string password;
            string b;
            int a;
            a = int.Parse(apnumber);
            b = pass;
            //_db.Personals.Find()
            //ApplicationDbcontext con = new ApplicationDbcontext();

            var password1 = (from pass1 in _db.Personals
                                              where pass1.ApplicationID == a
                                              select pass1.Password).FirstOrDefault();


            TempData["appid"] = a;
            if (password1 != null && password1.Equals(pass))
            {
                return RedirectToAction("CustomerPage") ;
            }
            else
            {
                ViewBag.Error = "Invalid ApplicationID or Password";
                return View();

            }




        }
    
    }
}
