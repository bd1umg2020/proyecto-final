using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using p_bd1_proveedores_cuentas_por_pagar.Models;

namespace p_bd1_proveedores_cuentas_por_pagar.Controllers.Catalogos
{
    public class rolController : Controller
    {
        // GET: rolController
        public ActionResult Index()
        {
            List<Rol> lista_roles = new List<Rol>();
            var sql = "SELECT * FROM ROL ORDER BY NOMBRE_ROL";
            var dr = ora_conn.ExecuteReader(sql);
            while (dr.Read())
            {
                Rol mi_rol = new Rol();
                mi_rol.ID_ROL = Convert.ToInt32(dr["ID_ROL"]);
                mi_rol.NOMBRE_ROL = dr["NOMBRE_ROL"].ToString();
                lista_roles.Add(mi_rol);
            }

            dr.Dispose();
            return View(lista_roles);
        }

        // GET: rolController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: rolController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var nombre_rol = collection["nombre_rol"];
                var sql = $"INSERT INTO ROL (ID_ROL, NOMBRE_ROL) VALUES ((SELECT NVL(MAX(ID_ROL),0) + 1 FROM ROL)," +
                    $"'{nombre_rol.ToString().ToUpper().Trim()}')";
                ora_conn.ExecuteNonQuery(sql);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
                return View();
            }
        }

        // GET: rolController/Edit/5
        public ActionResult Edit(int id)
        {
            Rol mi_rol = new Rol();
            var sql = $"SELECT * FROM ROL WHERE ID_ROL = {id}";
            var dr = ora_conn.ExecuteReader(sql);
            while (dr.Read())
            {
                mi_rol.ID_ROL = Convert.ToInt32(dr["ID_ROL"]);
                mi_rol.NOMBRE_ROL = dr["NOMBRE_ROL"].ToString();
            }
            dr.Dispose();
            return View(mi_rol);
        }

        // POST: rolController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                var nombre_rol = collection["nombre_rol"];
                var sql = $"UPDATE ROL SET NOMBRE_ROL = '{nombre_rol.ToString().ToUpper().Trim()}' WHERE ID_ROL = {id}";
                ora_conn.ExecuteNonQuery(sql);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
                return View();
            }
        }

        // GET: rolController/Delete/5
        public ActionResult Delete(int id)
        {
            Rol mi_rol = new Rol();
            var sql = $"SELECT * FROM ROL WHERE ID_ROL = {id}";
            var dr = ora_conn.ExecuteReader(sql);
            while (dr.Read())
            {
                mi_rol.ID_ROL = Convert.ToInt32(dr["ID_ROL"]);
                mi_rol.NOMBRE_ROL = dr["NOMBRE_ROL"].ToString();
            }
            dr.Dispose();
            return View(mi_rol);
        }

        // POST: rolController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var sql = $"DELETE FROM ROL WHERE ID_ROL = '{id}'";
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
