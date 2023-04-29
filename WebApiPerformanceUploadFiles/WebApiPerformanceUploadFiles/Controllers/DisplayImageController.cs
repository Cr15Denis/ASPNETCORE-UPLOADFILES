using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.IO.Pipes;

namespace WebApiPerformanceUploadFiles.Controllers
{
    public class DisplayImageController : Controller
    {
        // GET: DisplayImageController
        public ActionResult Index()
        {
            
            return View();

            
        }

        // GET: DisplayImageController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DisplayImageController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DisplayImageController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: DisplayImageController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DisplayImageController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: DisplayImageController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DisplayImageController/Delete/5
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
