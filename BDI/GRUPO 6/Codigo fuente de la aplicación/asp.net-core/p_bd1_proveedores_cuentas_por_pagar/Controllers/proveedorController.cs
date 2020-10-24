using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace p_bd1_proveedores_cuentas_por_pagar.Controllers
{
    public class proveedorController : Controller
    {
        // GET: proveedorController
        public ActionResult Index()
        {
            return View();
        }

        // GET: proveedorController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: proveedorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: proveedorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var nombre = collection["nombre_proveedor"];
                var nit = collection["nit_proveedor"];
                var sql = $"INSERT INTO PROVEEDOR (ID_PROVEEDOR, ID_TIPO_PROVEEDOR, ID_PERSONA, ID_DIRECCION, NOMBRE_PROVEEDOR, NIT_PROVEEDOR) VALUES ('1'," +
                    $"'1','1','1','{nombre}','{nit}')";
                ora_conn.ExecuteNonQuery(sql);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.error = ex.Message;
                return View();
            }
        }

        // GET: proveedorController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: proveedorController/Edit/5
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

        // GET: proveedorController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: proveedorController/Delete/5
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
