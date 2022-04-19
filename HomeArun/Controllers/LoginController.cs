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

        #region ProfilePage

        public IActionResult Profile()
        {
            string aid;
            int aid1;
            aid = (TempData["appid1"]).ToString();
            aid1 = int.Parse(aid);
            var firstname = (from d in _db.Personals
                             where d.ApplicationID == aid1
                             select d.FirstName).FirstOrDefault();
            var middlename = (from d in _db.Personals
                              where d.ApplicationID == aid1
                              select d.MiddleName).FirstOrDefault();

            var lastname = (from c in _db.Personals
                            where c.ApplicationID == aid1
                            select c.LastName).FirstOrDefault();

            var emailid = (from c in _db.Personals
                            where c.ApplicationID == aid1
                            select c.EmailId).FirstOrDefault();

            var phonenumber = (from c in _db.Personals
                            where c.ApplicationID == aid1
                            select c.PhoneNumber).FirstOrDefault();

            var dateofbirth = (from c in _db.Personals
                            where c.ApplicationID == aid1
                            select c.Dob).FirstOrDefault();
            //var firstname = (from d in _db.Incomes
            //                 where d.ApplicationID == aid1
                             //select d.FirstName).FirstOrDefault();
            ViewBag.fname1 = firstname;
            ViewBag.mname1 = middlename;
            ViewBag.lname1 = lastname;
            ViewBag.email1 = emailid;
            ViewBag.phn1 = phonenumber;
            ViewBag.date1 = dateofbirth;


            return View();
        }
        #endregion


        #region LoanTracker
        public IActionResult LoanTracker()
        {
            
           string  aid = (TempData["appidT"]).ToString();
           int  aid1 = int.Parse(aid);



            var doc = _db.UploadedDocuments.Find(aid1);

                if (doc.DocumentverifiedStatus == "Sent for Verification")
                {
                ViewBag.Tracker = "Sent for Verification";
                }
                else if (doc.DocumentverifiedStatus == "Documnet Verification Failed")
                {
                ViewBag.Tracker = doc.DocumentverifiedStatus;
                }

                else if (doc.DocumentverifiedStatus == "Document Verified" && doc.LoanApprovalStatus == "Sent for Approval")
                {
                ViewBag.Tracker = "Verified and Sent for Final Approval";
                }
                else if (doc.LoanApprovalStatus == "Loan Approved" || doc.LoanApprovalStatus == "Loan Rejected")
                {
                ViewBag.Tracker = doc.LoanApprovalStatus;
                }

               
                _db.SaveChanges();
                return View();

            

            
        }
        #endregion


        #region CustomerPage

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

        #endregion

        #region UserPage Login and Logout
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
            TempData["appid1"] = a;
            TempData["appidT"] = a;
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
        public IActionResult Logout()
        {
            return RedirectToAction("Create");

        }
        #endregion

    }
}
