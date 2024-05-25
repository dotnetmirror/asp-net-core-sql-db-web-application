using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using DotnetMirror.SQLDBWebApplication.Data;
using DotnetMirror.SQLDBWebApplication.Models;
using System.Runtime.ConstrainedExecution;

namespace DotnetMirror.SQLDBWebApplication.Controllers
{
    public class CertController : Controller
    {
        private DAL _data;
        private readonly IDistributedCache _cache;

        public CertController(IDAL context, IDistributedCache cache)
        {
            _data = new DAL();
            _cache = cache;
        }

        // GET: CertController1
        public ActionResult Index()
        {

            var certs = new List<Cert>();


            certs = _data.ListCertfications();


            return View(certs);


        }

        // GET: CertController1/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var cert = _data.GetCertfication(id.ToString());
            return View(cert);
        }

        // GET: CertController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CertController1/Create
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

        // GET: CertController1/Edit/5
        public ActionResult Edit(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }
           var  cert = _data.GetCertfication(id.ToString());
            return View(cert);
        }

        // POST: CertController1/Edit/5
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

        // GET: CertController1/Delete/5
        public ActionResult Delete(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

             _data.Delete(id.ToString());


            return RedirectToAction(nameof(Index));
        }

        // POST: CertController1/Delete/5
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
