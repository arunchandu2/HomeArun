#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HomeArun.Data;
using HomeArun.Models;

namespace HomeArun.Controllers
{
    public class UploadedDocumentsController : Controller
    {
        private readonly ApplicationDbcontext _context;

        public UploadedDocumentsController(ApplicationDbcontext context)
        {
            _context = context;
        }

        public IActionResult Display()
        {
            return View();
        }

        // GET: UploadedDocuments
        public async Task<IActionResult> Index()
        {
            var uid = (from d in _context.UploadedDocuments orderby d.DocumentId descending select d.DocumentId).FirstOrDefault();
            //var appdoc = (from d in _context.IncomeDetails orderby d.ApplicationId descending select d.ApplicationId).FirstOrDefault();
            //var appid = (from e in _context.UserDetails orderby e.ApplicationId descending select e.ApplicationId).FirstOrDefault();

            //if (appdoc != appid)
                //{
                //    return RedirectToAction("create", "uploadeddocuments");
                //}
                return RedirectToAction("Details", "uploadeddocuments", new { id = uid });

        }

        // GET: UploadedDocuments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uploadedDocument = await _context.UploadedDocuments
                .FirstOrDefaultAsync(m => m.DocumentId == id);
            if (uploadedDocument == null)
            {
                return NotFound();
            }

            return View(uploadedDocument);
        }

        // GET: UploadedDocuments/Create
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DocumentId,PanCard,AadharCard,SalarySlip,Loa,Noc,Agreement,DocumentverifiedStatus,ApplicationId,LoanApprovalStatus")] UploadedDocument uploadedDocument,
                        IFormFile PanUpload, IFormFile AadharUpload, IFormFile SalaryUpload, IFormFile LoaUpload, IFormFile NocUpload, IFormFile AgreementUpload)
        {
            {
                var pa = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "Upload"));

                //Pan Card Upload
                string panfile = TempData["applicationid"] + "PAN" + Path.GetExtension(PanUpload.FileName);
                uploadedDocument.PanCard = "~/Upload/" + panfile;
                panfile = Path.Combine(pa, panfile);
                using (var stream = new FileStream(panfile, FileMode.Create))
                {
                    await PanUpload.CopyToAsync(stream);
                }

                //Aadhar Upload
                string aadharfile = TempData["applicationid"] + "Aadhar" + Path.GetExtension(AadharUpload.FileName);
                uploadedDocument.AadharCard = "~/Upload/" + aadharfile;
                aadharfile = Path.Combine(pa, aadharfile);
                using (var stream = new FileStream(aadharfile, FileMode.Create))
                {
                    await AadharUpload.CopyToAsync(stream);
                }
                //Salary Upload
                string salaryfile = TempData["applicationid"] + "Salary" + Path.GetExtension(SalaryUpload.FileName);
                uploadedDocument.SalarySlip = "~/Upload/" + salaryfile;
                salaryfile = Path.Combine(pa, salaryfile);
                using (var stream = new FileStream(salaryfile, FileMode.Create))
                {
                    await SalaryUpload.CopyToAsync(stream);
                }

                //Loa Upload
                string loafile = TempData["applicationid"] + "Loa" + Path.GetExtension(LoaUpload.FileName);
                uploadedDocument.Loa = "~/Upload/" + loafile;
                loafile = Path.Combine(pa, loafile);
                using (var stream = new FileStream(loafile, FileMode.Create))
                {
                    await LoaUpload.CopyToAsync(stream);
                }

                //Noc Upload
                string nocfile = TempData["applicationid"] + "Noc" + Path.GetExtension(NocUpload.FileName);
                uploadedDocument.Noc = "~/Upload/" + nocfile;
                nocfile = Path.Combine(pa, nocfile);
                using (var stream = new FileStream(nocfile, FileMode.Create))
                {
                    await NocUpload.CopyToAsync(stream);
                }

                //Agreement upload
                string agreementfile = TempData["applicationid"] + "Agreement" + Path.GetExtension(AgreementUpload.FileName);
                uploadedDocument.Agreement = "~/Upload/" + agreementfile;
                agreementfile = Path.Combine(pa, agreementfile);
                using (var stream = new FileStream(agreementfile, FileMode.Create))
                {
                    await AgreementUpload.CopyToAsync(stream);
                }

                var uid = (from d in _context.UploadedDocuments orderby d.DocumentId descending select d.DocumentId).FirstOrDefault();

                if (uid == 0)
                {
                    TempData["Docid"] = 9000;
                    ViewBag.DocumnetID = TempData.Peek("Docid");
                }
                else
                {
                    TempData["Docid"] = ++uid;
                    ViewBag.DocumnetID = TempData.Peek("Docid");
                }
                ViewBag.ApplicationID = TempData["applicationid"];
                uploadedDocument.DocumentId = ViewBag.DocumnetID;
                //uploadedDocument.ApplicationId = ViewBag.ApplicationID;
                uploadedDocument.DocumentverifiedStatus = "Sent for Verification";
                uploadedDocument.LoanApprovalStatus = "Sent for Approval";
                _context.Add(uploadedDocument);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Display));


            }
        }
    }
}

















































//        // GET: UploadedDocuments/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var uploadedDocument = await _context.UploadedDocuments.FindAsync(id);
//            if (uploadedDocument == null)
//            {
//                return NotFound();
//            }
//            return View(uploadedDocument);
//        }

//        // POST: UploadedDocuments/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("DocumentId,PanCard,AadharCard,SalarySlip,Loa,Noc,Agreement,DocumentverifiedStatus,ApplicationId,LoanApprovalStatus")] UploadedDocument uploadedDocument)
//        {
//            if (id != uploadedDocument.DocumentId)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(uploadedDocument);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!UploadedDocumentExists(uploadedDocument.DocumentId))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            return View(uploadedDocument);
//        }

//        // GET: UploadedDocuments/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var uploadedDocument = await _context.UploadedDocuments
//                .FirstOrDefaultAsync(m => m.DocumentId == id);
//            if (uploadedDocument == null)
//            {
//                return NotFound();
//            }

//            return View(uploadedDocument);
//        }

//        // POST: UploadedDocuments/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            var uploadedDocument = await _context.UploadedDocuments.FindAsync(id);
//            _context.UploadedDocuments.Remove(uploadedDocument);
//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool UploadedDocumentExists(int id)
//        {
//            return _context.UploadedDocuments.Any(e => e.DocumentId == id);
//        }
//    }
//}
