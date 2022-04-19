using HomeArun.Data;
using Microsoft.AspNetCore.Mvc;

namespace HomeArun.Controllers
{
    public class EmiController : Controller
    {

        #region Emi calculator


        public IActionResult Calculate()
        {
            return View();
        }

        //postmethod

        [HttpPost]
        public IActionResult Calculate(string loan1,string Tenure,string ROI)
        {
            
            //string number1 = Request.Form["loan1"];
            int pa = Convert.ToInt32(loan1);
            float n = float.Parse(Tenure);
            float r = float.Parse(ROI);
            float emi = 0;
            float a = 0;
           float b = 0;
            double c = 0;
                r = (float)(r * (0.01/12));
                c = 1 + r;
                b = (float)Math.Pow(c, n);
                a = b / (b - 1);
                emi = pa * r * a;
                
                 
           
           //Console.WriteLine(emi);
            ViewBag.Result = emi;
            ViewBag.laon = loan1;
            ViewBag.ten = Tenure;
            ViewBag.rate = ROI;
            
            return View();

        }
        #endregion

        #region Eligibility Calculator
        //get method
        public IActionResult CalculateLoanAmount()
        {
            return View();
        }

        //post method
        [HttpPost]

        public IActionResult CalculateLoanAmount(string income, string ROI1, string cal)
        {
            float inc = float.Parse(income);
            float roi = float.Parse(ROI1);
            float totalloan = 0;
            if(cal == "calc")
            {
                roi = roi / 100;
                totalloan = 60 * (roi * inc);
            }
            ViewBag.Res = totalloan;
            ViewBag.inco = income;
            ViewBag.rate1 = ROI1;
           
            return View();




        }
        #endregion



    }
}
