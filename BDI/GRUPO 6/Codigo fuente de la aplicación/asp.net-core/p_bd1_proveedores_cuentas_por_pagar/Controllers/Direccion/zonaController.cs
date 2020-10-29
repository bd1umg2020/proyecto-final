using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using p_bd1_proveedores_cuentas_por_pagar.Models;

namespace p_bd1_proveedores_cuentas_por_pagar.Controllers.Direccion
{
    public class zonaController : Controller
    {
        // GET: zonaController
        public ActionResult Index()
        {
            List<Zona> lista_zonas = new List<Zona>();
            var sql = "SELECT * FROM ZONA_SECTOR_ A INNER JOIN MUNICIPIO_CIUDAD_ B ON A.ID_MUNICIPIO = B.ID_MUNICIPIO INNER JOIN DEPARTAMENTO_ESTADO_ C ON B.ID_DEPARTAMENTO = C.ID_DEPARTAMENTO INNER JOIN PAIS D ON D.ID_PAIS = C.ID_PAIS ORDER BY NOMBRE_PAIS, NOMBRE_DEPARTAMENTO, NOMBRE_MUNICIPIO, NOMBRE_ZONA";
            var dr = ora_conn.ExecuteReader(sql);
            while (dr.Read())
            {
                Zona mi_zona = new Zona();
                mi_zona.ID_ZONA = Convert.ToInt32(dr["id_zona"]);
                mi_zona.ID_MUNICIPIO = Convert.ToInt32(dr["id_municipio"]);
                mi_zona.NOMBRE_ZONA = dr["nombre_zona"].ToString();
                mi_zona.NOMBRE_MUNICIPIO = dr["nombre_municipio"].ToString();
                mi_zona.NOMBRE_DEPARTAMENTO = dr["nombre_departamento"].ToString();
                mi_zona.NOMBRE_PAIS = dr["nombre_pais"].ToString();
                lista_zonas.Add(mi_zona);
            }

            dr.Dispose();
            return View(lista_zonas);
        }

  

        // GET: zonaController/Create
        public ActionResult Create()
        {
            var municipios = new List<SelectListItem>();
            var sql = "SELECT * FROM MUNICIPIO_CIUDAD_ ORDER BY NOMBRE_MUNICIPIO";
            var dr = ora_conn.ExecuteReader(sql);
            while (dr.Read())
            {
                municipios.Add(new SelectListItem()
                {
                    Text = dr["nombre_municipio"].ToString(),
                    Value = dr["id_municipio"].ToString()
                });
            }
            ViewBag.municipios = municipios;
            return View();
        }

        // POST: zonaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var nombre_zona = collection["nombre_zona"];
                var id_municipio = collection["id_municipio"];
                var sql = $"INSERT INTO ZONA_SECTOR_ (ID_ZONA, ID_MUNICIPIO, NOMBRE_ZONA) VALUES ((SELECT NVL(MAX(ID_ZONA),0) + 1 FROM ZONA_SECTOR_)," +
                    $"'{id_municipio}','{nombre_zona.ToString().ToUpper().Trim()}')";
                ora_conn.ExecuteNonQuery(sql);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
                return View();
            }
        }

        // GET: zonaController/Edit/5
        public ActionResult Edit(int id)
        {
            Zona mi_zona = new Zona();
            var sql = $"SELECT * FROM ZONA_SECTOR_ WHERE ID_ZONA = {id}";
            var dr = ora_conn.ExecuteReader(sql);
            while (dr.Read())
            {
                mi_zona.ID_ZONA = Convert.ToInt32(dr["id_zona"]);
                mi_zona.ID_MUNICIPIO = Convert.ToInt32(dr["id_municipio"]);
                mi_zona.NOMBRE_ZONA = dr["nombre_zona"].ToString();
            }
            dr.Dispose();
            return View(mi_zona);
        }

        // POST: zonaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                var nombre_zona = collection["nombre_zona"];
                var sql = $"UPDATE ZONA_SECTOR_ SET NOMBRE_ZONA = '{nombre_zona.ToString().ToUpper().Trim()}' WHERE ID_ZONA = {id}";
                ora_conn.ExecuteNonQuery(sql);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
                return View();
            }
        }

        // GET: zonaController/Delete/5
        public ActionResult Delete(int id)
        {
            Zona mi_zona = new Zona();
            var sql = $"SELECT * FROM ZONA_SECTOR_ WHERE ID_ZONA = {id}";
            var dr = ora_conn.ExecuteReader(sql);
            while (dr.Read())
            {
                mi_zona.ID_ZONA = Convert.ToInt32(dr["id_zona"]);
                mi_zona.ID_MUNICIPIO = Convert.ToInt32(dr["id_municipio"]);
                mi_zona.NOMBRE_ZONA = dr["nombre_zona"].ToString();
            }
            dr.Dispose();
            return View(mi_zona);
        }

        // POST: zonaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var sql = $"DELETE FROM ZONA_SECTOR_ WHERE ID_ZONA = '{id}'";
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
