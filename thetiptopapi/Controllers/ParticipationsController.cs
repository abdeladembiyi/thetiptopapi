using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace thetiptopapi.Controllers
{
    public class ParticipationsController : Controller
    {
        // GET: ParticipationsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ParticipationsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ParticipationsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ParticipationsController/Create
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

        // GET: ParticipationsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ParticipationsController/Edit/5
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

        // GET: ParticipationsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ParticipationsController/Delete/5
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
