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

        #region PersonalDetails
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(string fname, string mname, string lname, string ename, string pname, string phname, string dname)
        {            PersonalDetails obj = new PersonalDetails();
           DateTime dname1 = DateTime.Parse(dname);
            obj.FirstName = fname;
            obj.MiddleName = mname;
            obj.LastName = lname;
            obj.EmailId = ename;
            obj.Password = pname;
            obj.PhoneNumber = phname;
            obj.Dob = dname1;



            _db.Personals.Add(obj);
            _db.SaveChanges();
            return View();
        }
        #endregion

    }
}
