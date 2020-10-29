using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using p_bd1_proveedores_cuentas_por_pagar.Models;

namespace p_bd1_proveedores_cuentas_por_pagar.Controllers.Catalogos
{
    public class tipoCuentaController : Controller
    {
        // GET: tipoCuentaController
        public ActionResult Index()
        {
            List<Tipo_cuenta> lista_tipo_cuenta = new List<Tipo_cuenta>();
            var sql = "SELECT * FROM TIPO_CUENTA ORDER BY TIPO_CUENTA";
            var dr = ora_conn.ExecuteReader(sql);
            while (dr.Read())
            {
                Tipo_cuenta mi_tipo_cuenta = new Tipo_cuenta();
                mi_tipo_cuenta.ID_TIPO_CUENTA = Convert.ToInt32(dr["ID_TIPO_CUENTA"]);
                mi_tipo_cuenta.TIPO_CUENTA = dr["TIPO_CUENTA"].ToString();
                lista_tipo_cuenta.Add(mi_tipo_cuenta);
            }

            dr.Dispose();
            return View(lista_tipo_cuenta);
        }


        // GET: tipoCuentaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tipoCuentaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var tipo_cuenta = collection["tipo_cuenta"];
                var sql = $"INSERT INTO TIPO_CUENTA (ID_TIPO_CUENTA, TIPO_CUENTA) VALUES ((SELECT NVL(MAX(ID_TIPO_CUENTA),0) + 1 FROM TIPO_CUENTA)," +
                    $"'{tipo_cuenta.ToString().ToUpper().Trim()}')";
                ora_conn.ExecuteNonQuery(sql);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
                return View();
            }
        }

        // GET: tipoCuentaController/Edit/5
        public ActionResult Edit(int id)
        {
            Tipo_cuenta mi_tipo_cuenta = new Tipo_cuenta();
            var sql = $"SELECT * FROM TIPO_CUENTA WHERE ID_TIPO_CUENTA = {id}";
            var dr = ora_conn.ExecuteReader(sql);
            while (dr.Read())
            {
                mi_tipo_cuenta.ID_TIPO_CUENTA = Convert.ToInt32(dr["ID_TIPO_CUENTA"]);
                mi_tipo_cuenta.TIPO_CUENTA = dr["TIPO_CUENTA"].ToString();
            }
            dr.Dispose();
            return View(mi_tipo_cuenta);
        }

        // POST: tipoCuentaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                var tipo_cuenta = collection["tipo_cuenta"];
                var sql = $"UPDATE TIPO_CUENTA SET TIPO_CUENTA = '{tipo_cuenta.ToString().ToUpper().Trim()}' WHERE IT_TIPO_CUENTA = {id}";
                ora_conn.ExecuteNonQuery(sql);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
                return View();
            }
        }

        // GET: tipoCuentaController/Delete/5
        public ActionResult Delete(int id)
        {
            Tipo_cuenta mi_tipo_cuenta = new Tipo_cuenta();
            var sql = $"SELECT * FROM TIPO_CUENTA WHERE ID_TIPO_CUENTA = {id}";
            var dr = ora_conn.ExecuteReader(sql);
            while (dr.Read())
            {
                mi_tipo_cuenta.ID_TIPO_CUENTA = Convert.ToInt32(dr["ID_TIPO_CUENTA"]);
                mi_tipo_cuenta.TIPO_CUENTA = dr["TIPO_CUENTA"].ToString();
            }
            dr.Dispose();
            return View(mi_tipo_cuenta);
        }

        // POST: tipoCuentaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var sql = $"DELETE FROM TIPO_CUENTA WHERE ID_TIPO_CUENTA = '{id}'";
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
