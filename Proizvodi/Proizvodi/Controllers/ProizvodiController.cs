using BAL.Services;
using BAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proizvodi.Controllers
{
    public class ProizvodiController : Controller
    {
        private readonly IProizvodiService _proizvodiService;
        public ProizvodiController(IProizvodiService proizvodiService)
        {
            _proizvodiService = proizvodiService;
        }
        // GET: Proizvodi
        public ActionResult Index()
        {
            var viewModel = _proizvodiService.GetAll();
            return View(viewModel);
        }
        // GET Proizvodi/Edit/id
        public ActionResult Edit(int id)
        {
            if (id <= 0)
                return Content("Parametar ID mora biti veci od 0");
            var viewModel = _proizvodiService.GetById(id);
            if (viewModel == null)
                return HttpNotFound();
            return View(viewModel);
        }
        // POST Proizvodi/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProizvodViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);
            var result = _proizvodiService.Update(viewModel);
            if (result)
                return RedirectToAction("Index");
            return Content("Neuspesno!");
        }

        // GET Proizvodi/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST Proizvodi/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProizvodViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);
            var result = _proizvodiService.Create(viewModel);
            if (result)
                return RedirectToAction("Index");
            return Content("Neuspesno!");
        }

        // GET Proizvodi/Delete/id
        public ActionResult Delete(int id)
        {
            if (id <= 0)
                return Content("Parametar ID mora biti veci od 0");
            var viewModel = _proizvodiService.GetById(id);
            if (viewModel == null)
                return HttpNotFound();
            return View(viewModel);
        }

        // POST Proizvodi/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (id <= 0)
                return Content("Parametar ID mora biti veci od 0");
            var viewModel = _proizvodiService.GetById(id);
            if (viewModel == null)
                return HttpNotFound();
            var result = _proizvodiService.Delete(id);
            if (result)
                return RedirectToAction("Index");
            return Content("Neuspesno!");
        }
    }
}