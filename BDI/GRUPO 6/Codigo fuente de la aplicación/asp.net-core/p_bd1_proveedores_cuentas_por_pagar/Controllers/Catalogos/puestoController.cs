using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using p_bd1_proveedores_cuentas_por_pagar.Models;
using System;
using System.Collections.Generic;

namespace p_bd1_proveedores_cuentas_por_pagar.Controllers.Catalogos
{
    public class puestoController : Controller
    {
        // GET: puestoController
        public ActionResult Index()
        {
            List<Puesto> lista_puestos = new List<Puesto>();
            var sql = "SELECT * FROM PUESTO ORDER BY NOMBRE_PUESTO";
            var dr = ora_conn.ExecuteReader(sql);
            while (dr.Read())
            {
                Puesto mi_puesto = new Puesto();
                mi_puesto.ID_PUESTO = Convert.ToInt32(dr["ID_PUESTO"]);
                mi_puesto.NOMBRE_PUESTO =dr["NOMBRE_PUESTO"].ToString();
                lista_puestos.Add(mi_puesto);
            }

            dr.Dispose();
            return View(lista_puestos);
        }


        // GET: puestoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: puestoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var nombre_puesto = collection["nombre_puesto"];
                var sql = $"INSERT INTO PUESTO (ID_PUESTO, NOMBRE_PUESTO) VALUES ((SELECT NVL(MAX(ID_PUESTO),0) + 1 FROM PUESTO)," +
                    $"'{nombre_puesto.ToString().ToUpper().Trim()}')";
                ora_conn.ExecuteNonQuery(sql);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
                return View();
            }
        }

        // GET: puestoController/Edit/5
        public ActionResult Edit(int id)
        {
            Puesto mi_puesto = new Puesto();
            var sql = $"SELECT * FROM PUESTO WHERE ID_PUESTO = {id}";
            var dr = ora_conn.ExecuteReader(sql);
            while (dr.Read())
            {
                mi_puesto.ID_PUESTO = Convert.ToInt32(dr["ID_PUESTO"]);
                mi_puesto.NOMBRE_PUESTO = dr["NOMBRE_PUESTO"].ToString();
            }
            dr.Dispose();
            return View(mi_puesto);
        }

        // POST: puestoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                var nombre_puesto = collection["nombre_puesto"];
                var sql = $"UPDATE PUESTO SET NOMBRE_PUESTO = '{nombre_puesto.ToString().ToUpper().Trim()}' WHERE ID_PUESTO = {id}";
                ora_conn.ExecuteNonQuery(sql);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
                return View();
            }
        }

        // GET: puestoController/Delete/5
        public ActionResult Delete(int id)
        {
            Puesto mi_puesto = new Puesto();
            var sql = $"SELECT * FROM PUESTO WHERE ID_PUESTO = {id}";
            var dr = ora_conn.ExecuteReader(sql);
            while (dr.Read())
            {
                mi_puesto.ID_PUESTO = Convert.ToInt32(dr["ID_PUESTO"]);
                mi_puesto.NOMBRE_PUESTO = dr["NOMBRE_PUESTO"].ToString();
            }
            dr.Dispose();
            return View(mi_puesto);
        }

        // POST: puestoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var sql = $"DELETE FROM PUESTO WHERE ID_PUESTO = '{id}'";
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
