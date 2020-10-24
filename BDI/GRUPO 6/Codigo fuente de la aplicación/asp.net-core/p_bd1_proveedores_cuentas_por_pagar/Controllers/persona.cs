using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace p_bd1_proveedores_cuentas_por_pagar.Controllers
{
    public class persona : Controller
    {
        // GET: persona
        public ActionResult Index()
        {
            return View();
        }

        // GET: persona/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: persona/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: persona/Create
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

        // GET: persona/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: persona/Edit/5
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

        // GET: persona/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: persona/Delete/5
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
