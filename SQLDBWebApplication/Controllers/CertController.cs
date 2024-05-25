using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using DotnetMirror.ASPNETCORESQLDBWebApplication.Data;
using DotnetMirror.ASPNETCORESQLDBWebApplication.Models;
using System.Runtime.ConstrainedExecution;

namespace DotnetMirror.ASPNETCORESQLDBWebApplication.Controllers
{
    public class CertController : Controller
    {
        private IDAL _data;

        public CertController(IDAL context)
        {
            _data = context;
        }

        // GET: CertController
        public ActionResult Index()
        {

            var certs = new List<Cert>();


            certs = _data.ListCertfications();


            return View(certs);


        }

        // GET: CertController/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var cert = _data.GetCertfication(id.ToString());
            return View(cert);
        }

        // GET: CertController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CertController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Code,Description,ExamDate")] Cert cert)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _data.Save(cert);

                    return RedirectToAction(nameof(Index));
                }
                return View(cert);
            }
            catch
            {
                return View();
            }
        }

        // GET: CertController/Edit/5
        public ActionResult Edit(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var cert = _data.GetCertfication(id.ToString());
            return View(cert);
        }

        // POST: CertController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CertController/Delete/5
        public ActionResult Delete(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            _data.Delete(id.ToString());


            return RedirectToAction(nameof(Index));
        }

        // POST: CertController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
