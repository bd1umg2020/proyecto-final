using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using p_bd1_proveedores_cuentas_por_pagar.Models;

namespace p_bd1_proveedores_cuentas_por_pagar.Controllers.Catalogos
{
    public class tipoSucursalController : Controller
    {
        // GET: tipoSucursalController
        public ActionResult Index()
        {
            List<Tipo_sucursal> lista_tipo_sucursal = new List<Tipo_sucursal>();
            var sql = "SELECT * FROM TIPO_SUCURSAL ORDER BY NOMBRE_TIPO_SUCURSAL";
            var dr = ora_conn.ExecuteReader(sql);
            while (dr.Read())
            {
                Tipo_sucursal mi_tipo_sucursal = new Tipo_sucursal();
                mi_tipo_sucursal.ID_TIPO_SUCURSAL = Convert.ToInt32(dr["ID_TIPO_SUCURSAL"]);
                mi_tipo_sucursal.NOMBRE_TIPO_SUCURSAL = dr["NOMBRE_TIPO_SUCURSAL"].ToString();
                lista_tipo_sucursal.Add(mi_tipo_sucursal);
            }

            dr.Dispose();
            return View(lista_tipo_sucursal);
        }



        // GET: tipoSucursalController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tipoSucursalController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var nombre_tipo_sucursal = collection["nombre_tipo_sucursal"];
                var sql = $"INSERT INTO TIPO_SUCURSAL (ID_TIPO_SUCURSAL, NOMBRE_TIPO_SUCURSAL) VALUES ((SELECT NVL(MAX(ID_TIPO_SUCURSAL),0) + 1 FROM TIPO_SUCURSAL)," +
                    $"'{nombre_tipo_sucursal.ToString().ToUpper().Trim()}')";
                ora_conn.ExecuteNonQuery(sql);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
                return View();
            }
        }

        // GET: tipoSucursalController/Edit/5
        public ActionResult Edit(int id)
        {
            Tipo_sucursal mi_tiposucursal = new Tipo_sucursal();
            var sql = $"SELECT * FROM TIPO_SUCURSAL WHERE ID_TIPO_SUCURSAL = {id}";
            var dr = ora_conn.ExecuteReader(sql);
            while (dr.Read())
            {
                mi_tiposucursal.ID_TIPO_SUCURSAL = Convert.ToInt32(dr["ID_TIPO_SUCURSAL"]);
                mi_tiposucursal.NOMBRE_TIPO_SUCURSAL = dr["NOMBRE_TIPO_SUCURSAL"].ToString();
            }
            dr.Dispose();
            return View(mi_tiposucursal);

        }

        // POST: tipoSucursalController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                var nombre_tipo_sucursal = collection["nombre_tipo_sucursal"];
                var sql = $"UPDATE TIPO_SUCURSAL SET NOMBRE_TIPO_SUCURSAL = '{nombre_tipo_sucursal.ToString().ToUpper().Trim()}' WHERE ID_TIPO_SUCURSAL = {id}";
                ora_conn.ExecuteNonQuery(sql);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
                return View();
            }
        }

        // GET: tipoSucursalController/Delete/5
        public ActionResult Delete(int id)
        {
            Tipo_sucursal mi_tiposucursal = new Tipo_sucursal();
            var sql = $"SELECT * FROM TIPO_SUCURSAL WHERE ID_TIPO_SUCURSAL = {id}";
            var dr = ora_conn.ExecuteReader(sql);
            while (dr.Read())
            {
                mi_tiposucursal.ID_TIPO_SUCURSAL = Convert.ToInt32(dr["ID_TIPO_SUCURSAL"]);
                mi_tiposucursal.NOMBRE_TIPO_SUCURSAL = dr["NOMBRE_TIPO_SUCURSAL"].ToString();
            }
            dr.Dispose();
            return View(mi_tiposucursal);
        }

        // POST: tipoSucursalController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var sql = $"DELETE FROM TIPO_SUCURSAL WHERE ID_TIPO_SUCURSAL = '{id}'";
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
