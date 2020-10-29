using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using p_bd1_proveedores_cuentas_por_pagar.Models;

namespace p_bd1_proveedores_cuentas_por_pagar.Controllers.Catalogos
{
    public class formaPagoController : Controller
    {
        // GET: formaPagoController
        public ActionResult Index()
        {
            List<Forma_pago> lista_forma_pago = new List<Forma_pago>();
            var sql = "SELECT * FROM FORMA_PAGO ORDER BY NOMBRE_FORMA_PAGO";
            var dr = ora_conn.ExecuteReader(sql);
            while (dr.Read())
            {
                Forma_pago mi_forma_pago = new Forma_pago();
                mi_forma_pago.ID_FORMA_PAGO = Convert.ToInt32(dr["ID_FORMA_PAGO"]);
                mi_forma_pago.NOMBRE_FORMA_PAGO = dr["NOMBRE_FORMA_PAGO"].ToString();
                lista_forma_pago.Add(mi_forma_pago);
            }

            dr.Dispose();
            return View(lista_forma_pago);
        }


        // GET: formaPagoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: formaPagoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var nombre_forma_pago = collection["nombre_forma_pago"];
                var sql = $"INSERT INTO FORMA_PAGO (ID_FORMA_PAGO, NOMBRE_FORMA_PAGO) VALUES ((SELECT NVL(MAX(ID_FORMA_PAGO),0) + 1 FROM FORMA_PAGO)," +
                    $"'{nombre_forma_pago.ToString().ToUpper().Trim()}')";
                ora_conn.ExecuteNonQuery(sql);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
                return View();
            }
        }

        // GET: formaPagoController/Edit/5
        public ActionResult Edit(int id)
        {
            Forma_pago mi_forma_pago = new Forma_pago();
            var sql = $"SELECT * FROM FORMA_PAGO WHERE ID_FORMA_PAGO = {id}";
            var dr = ora_conn.ExecuteReader(sql);
            while (dr.Read())
            {
                mi_forma_pago.ID_FORMA_PAGO = Convert.ToInt32(dr["ID_FORMA_PAGO"]);
                mi_forma_pago.NOMBRE_FORMA_PAGO = dr["NOMBRE_FORMA_PAGO"].ToString();
            }
            dr.Dispose();
            return View(mi_forma_pago);
        }

        // POST: formaPagoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                var nombre_forma_pago = collection["nombre_forma_pago"];
                var sql = $"UPDATE FORMA_PAGO SET NOMBRE_FORMA_PAGO = '{nombre_forma_pago.ToString().ToUpper().Trim()}' WHERE ID_FORMA_PAGO = {id}";
                ora_conn.ExecuteNonQuery(sql);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
                return View();
            }
        }

        // GET: formaPagoController/Delete/5
        public ActionResult Delete(int id)
        {
            Forma_pago mi_forma_pago = new Forma_pago();
            var sql = $"SELECT * FROM FORMA_PAGO WHERE ID_FORMA_PAGO = {id}";
            var dr = ora_conn.ExecuteReader(sql);
            while (dr.Read())
            {
                mi_forma_pago.ID_FORMA_PAGO = Convert.ToInt32(dr["ID_FORMA_PAGO"]);
                mi_forma_pago.NOMBRE_FORMA_PAGO = dr["NOMBRE_FORMA_PAGO"].ToString();
            }
            dr.Dispose();
            return View(mi_forma_pago);
        }

        // POST: formaPagoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var sql = $"DELETE FROM FORMA_PAGO WHERE ID_FORMA_PAGO = '{id}'";
                ora_conn.ExecuteNonQuery(sql);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
                return View();
            }
        }
    }
}
