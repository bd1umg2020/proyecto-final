using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using p_bd1_proveedores_cuentas_por_pagar.Models;

namespace p_bd1_proveedores_cuentas_por_pagar.Controllers.Direccion
{
    public class paisController : Controller
    {
        // GET: paisController
        public ActionResult Index()
        {
            List<Pais> lista_paises = new List<Pais>();
            var sql = "SELECT * FROM PAIS ORDER BY NOMBRE_PAIS";
            var dr = ora_conn.ExecuteReader(sql);
            while (dr.Read())
            {
                Pais mi_pais = new Pais();
                mi_pais.ID_PAIS = Convert.ToInt32(dr["id_pais"]);
                mi_pais.NOMBRE_PAIS = dr["nombre_pais"].ToString();
                lista_paises.Add(mi_pais);
            }

            dr.Dispose();
            return View(lista_paises);
        }


        // GET: paisController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: paisController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var nombre_pais = collection["nombre_pais"];
                var sql = $"INSERT INTO PAIS (ID_PAIS, NOMBRE_PAIS) VALUES ((SELECT NVL(MAX(ID_PAIS),0) + 1 FROM PAIS),'{nombre_pais.ToString().ToUpper().Trim()}')";
                ora_conn.ExecuteNonQuery(sql);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
                return View();
            }
        }

        // GET: paisController/Edit/5
        public ActionResult Edit(int id)
        {
            Pais mi_pais = new Pais();
            var sql = $"SELECT * FROM PAIS WHERE ID_PAIS = {id}";
            var dr = ora_conn.ExecuteReader(sql);
            while (dr.Read())
            {
                mi_pais.ID_PAIS = Convert.ToInt32(dr["id_pais"]);
                mi_pais.NOMBRE_PAIS = dr["nombre_pais"].ToString();
            }
            dr.Dispose();
            return View(mi_pais);
        }

        // POST: paisController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                var nombre_pais = collection["nombre_pais"];
                var sql = $"UPDATE PAIS SET NOMBRE_PAIS = '{nombre_pais.ToString().ToUpper().Trim()}' WHERE ID_PAIS = '{id}'";
                ora_conn.ExecuteNonQuery(sql);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
                return View();
            }
        }

        // GET: paisController/Delete/5
        public ActionResult Delete(int id)
        {
            Pais mi_pais = new Pais();
            var sql = $"SELECT * FROM PAIS WHERE ID_PAIS = {id}";
            var dr = ora_conn.ExecuteReader(sql);
            while (dr.Read())
            {
                mi_pais.ID_PAIS = Convert.ToInt32(dr["id_pais"]);
                mi_pais.NOMBRE_PAIS = dr["nombre_pais"].ToString();
            }
            dr.Dispose();
            return View(mi_pais);
        }

        // POST: paisController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var sql = $"DELETE FROM PAIS WHERE ID_PAIS = '{id}'";
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
