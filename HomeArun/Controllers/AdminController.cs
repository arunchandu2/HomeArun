using HomeArun.Data;
using Microsoft.AspNetCore.Mvc;

namespace HomeArun.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbcontext _db;

        public AdminController(ApplicationDbcontext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AdminPage()
        {
            return View();

        }
        /// <summary>
        /// It shows the logic for  user Income Details
        /// </summary>
       
        #region UserDetails
        public IActionResult UserIncomeDetails()
        {
            var objCtegoryList = _db.Incomes;
            return View(objCtegoryList);
        }
        #endregion

        /// <summary>
        /// It shows the logic for user Personal Details
        /// </summary>
        /// <returns></returns>

        #region PersonalDetails
        public IActionResult UserPersonalDetails()
        {
            var objCtegoryList = _db.Personals;
            return View(objCtegoryList);
        }
        #endregion

        /// <summary>
        /// It shows the logic for how the Document Verification is done
        /// </summary>
        /// <returns></returns>

        #region DocumentVerification
        public IActionResult DocVerify()
        {
            var id = (from m in _db.UploadedDocuments where m.DocumentverifiedStatus.Equals("Sent for Verification") select m.ApplicationId).ToList();
            return View(id);

        }
        [HttpPost]
        public IActionResult DocVerify(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            return View();
        }   
          

        public IActionResult VerifyClick(int id)
        {
            TempData["Id"] = id;
            TempData.Keep();
            return View();
        }
        [HttpPost]
        public IActionResult VerifyClick(string button)
        {
            if(button == "Verify")
            {
                string Appid;
               
               
                Appid = TempData["id"].ToString();
                var Appid1 = int.Parse(Appid);

                //var docid = (from w in _db.UploadedDocuments
                //            where w.ApplicationId.Equals(TempData["Id"])
                //            select w.DocumentId).FirstOrDefault();

                var userdoc = _db.UploadedDocuments.Find(Appid1);
                userdoc.DocumentverifiedStatus = "Document Verified";
                _db.SaveChanges();
                return RedirectToAction("Approval");

            }
            else
            {
                string Appid;


                Appid = TempData["id"].ToString();
                var Appid1 = int.Parse(Appid);
               //// var docid = (from w in _db.UploadedDocuments
               //              where w.ApplicationId.Equals(TempData["Id"])
               //              select w.DocumentId).FirstOrDefault();

                var userdoc = _db.UploadedDocuments.Find(Appid1);
                userdoc.DocumentverifiedStatus = "Documnet Verification Failed";
                _db.SaveChanges();
                return RedirectToAction("AdminPage");
            }

        }
        #endregion

        #region Approval of Loan
        public IActionResult Approval()
        {
            var id = (from m in _db.UploadedDocuments where m.DocumentverifiedStatus.Equals("Document Verified") select m.ApplicationId).ToList();
            return View(id);
        }

        [HttpPost]

        public IActionResult Approval(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            

            return View();
        }


        public IActionResult Approveonclick(int? id)
        {
            

            TempData["Id"] = id;
            TempData.Keep();
            return View();
        }

        [HttpPost]

        public IActionResult Approveonclick(string status)
        {
            if (status == "Approve")
            {
                string Appid;


                Appid = TempData["id"].ToString();
                var Appid1 = int.Parse(Appid);

                var userdoc = _db.UploadedDocuments.Find(Appid1);

                userdoc.LoanApprovalStatus = "Loan Approved";
                _db.SaveChanges();
                return RedirectToAction("AdminPage");
            }

            else
            {

                string Appid;


                Appid = TempData["id"].ToString();
                var Appid1 = int.Parse(Appid);
                var userdoc = _db.UploadedDocuments.Find(Appid1);
                userdoc.LoanApprovalStatus = "Loan Rejected";
                _db.SaveChanges();
                return RedirectToAction("AdminPage");
            }
        }
        #endregion
       

     
       
    
        #region Admin Login and Logout
        [HttpGet]
        public IActionResult alogin()
        {
            return View();

        }

        [HttpPost]
        public IActionResult alogin(string apnumber1,string pass1)
        {
            string b;
            int a;
            a = int.Parse(apnumber1);
            b = pass1;
            //_db.Personals.Find()
            //ApplicationDbcontext con = new ApplicationDbcontext();

            var password2 = (from f in _db.Admins
                             where f.AdminId == a
                             select f.AdminPassword).FirstOrDefault();



            TempData["appid"] = a;
            TempData["appid1"] = a;
            if (password2 != null && password2.Equals(pass1))
            {
                return RedirectToAction("AdminPage");
            }
            else
            {
                ViewBag.Error = "Invalid ApplicationID or Password";
                return View();

            }



        }
        public IActionResult alogout()
        {
            return RedirectToAction("alogin");
        }
    }
    #endregion
}
