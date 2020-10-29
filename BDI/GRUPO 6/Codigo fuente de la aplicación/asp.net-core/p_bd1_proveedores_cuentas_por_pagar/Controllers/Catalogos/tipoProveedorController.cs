using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using p_bd1_proveedores_cuentas_por_pagar.Models;

namespace p_bd1_proveedores_cuentas_por_pagar.Controllers.Catalogos
{
    public class tipoProveedorController : Controller
    {
        // GET: tipoProveedorController
        public ActionResult Index()
        {
            List<Tipo_proveedor> lista_tipo_proveedor = new List<Tipo_proveedor>();
            var sql = "SELECT * FROM TIPO_PROVEEDOR ORDER BY NOMBRE_TIPO_PROVEEDOR";
            var dr = ora_conn.ExecuteReader(sql);
            while (dr.Read())
            {
                Tipo_proveedor mi_tipo_proveedor = new Tipo_proveedor();
                mi_tipo_proveedor.ID_TIPO_PROVEEDOR = Convert.ToInt32(dr["ID_TIPO_PROVEEDOR"]);
                mi_tipo_proveedor.NOMBRE_TIPO_PROVEEDOR = dr["NOMBRE_TIPO_PROVEEDOR"].ToString();
                lista_tipo_proveedor.Add(mi_tipo_proveedor);
            }
            dr.Dispose();
            return View(lista_tipo_proveedor);
        }


        // GET: tipoProveedorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tipoProveedorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var nombre_tipo_proveedor = collection["nombre_tipo_proveedor"];
                var sql = $"INSERT INTO TIPO_PROVEEDOR (ID_TIPO_PROVEEDOR, NOMBRE_TIPO_PROVEEDOR) VALUES ((SELECT NVL(MAX(ID_TIPO_PROVEEDOR),0) + 1 FROM TIPO_PROVEEDOR)," +
                    $"'{nombre_tipo_proveedor.ToString().ToUpper().Trim()}')";
                ora_conn.ExecuteNonQuery(sql);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
                return View();
            }
        }

        // GET: tipoProveedorController/Edit/5
        public ActionResult Edit(int id)
        {
            Tipo_proveedor mi_tipo_proveedor = new Tipo_proveedor();
            var sql = $"SELECT * FROM TIPO_PROVEEDOR WHERE ID_TIPO_PROVEEDOR = {id}";
            var dr = ora_conn.ExecuteReader(sql);
            while (dr.Read())
            {
                mi_tipo_proveedor.ID_TIPO_PROVEEDOR = Convert.ToInt32(dr["ID_TIPO_PROVEEDOR"]);
                mi_tipo_proveedor.NOMBRE_TIPO_PROVEEDOR = dr["NOMBRE_TIPO_PROVEEDOR"].ToString();
            }
            dr.Dispose();
            return View(mi_tipo_proveedor);
        }

        // POST: tipoProveedorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                var nombre_tipo_proveedor = collection["nombre_tipo_proveedor"];
                var sql = $"UPDATE TIPO_PROVEEDOR SET NOMBRE_TIPO_PROVEEDOR = '{nombre_tipo_proveedor.ToString().ToUpper().Trim()}' WHERE ID_TIPO_PROVEEDOR = {id}";
                ora_conn.ExecuteNonQuery(sql);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
                return View();
            }
        }

        // GET: tipoProveedorController/Delete/5
        public ActionResult Delete(int id)
        {
            Tipo_proveedor mi_tipo_proveedor = new Tipo_proveedor();
            var sql = $"SELECT * FROM TIPO_PROVEEDOR WHERE ID_TIPO_PROVEEDOR = {id}";
            var dr = ora_conn.ExecuteReader(sql);
            while (dr.Read())
            {
                mi_tipo_proveedor.ID_TIPO_PROVEEDOR = Convert.ToInt32(dr["ID_TIPO_PROVEEDOR"]);
                mi_tipo_proveedor.NOMBRE_TIPO_PROVEEDOR = dr["NOMBRE_TIPO_PROVEEDOR"].ToString();
            }
            dr.Dispose();
            return View(mi_tipo_proveedor);
        }

        // POST: tipoProveedorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var sql = $"DELETE TIPO_PROVEEDOR WHERE ID_TIPO_PROVEEDOR = '{id}'";
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
