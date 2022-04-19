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
        #region IncomeDetails
        [HttpGet]
        public IActionResult Create1()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create1(string lname,string tname,string ename,string rname,string oname,string enname)
        {
           int  ename1 = int.Parse(ename);
            int rname1 = int.Parse(rname);
            IncomeDetails obj1 = new IncomeDetails();
            obj1.PropertyLocation = lname;
            obj1.PropertyType = tname;
            obj1.EstimatedAmount = ename1;
            obj1.RetirementAge = rname1;
            obj1.OrganizationType = oname;
            obj1.EmployerName = enname;
             _db.Incomes.Add(obj1);
            _db.SaveChanges();
            return View();
        }
        
    }
    #endregion
}
