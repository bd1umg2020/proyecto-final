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
    public class municipioController : Controller
    {
        // GET: municipioController
        public ActionResult Index()
        {
            List<Municipio> lista_municipios = new List<Municipio>();
            var sql = "SELECT * FROM MUNICIPIO_CIUDAD_ A INNER JOIN DEPARTAMENTO_ESTADO_ B ON A.ID_DEPARTAMENTO = B.ID_DEPARTAMENTO INNER JOIN PAIS C ON B.ID_PAIS = C.ID_PAIS ORDER BY NOMBRE_PAIS, NOMBRE_DEPARTAMENTO, NOMBRE_MUNICIPIO";
            var dr = ora_conn.ExecuteReader(sql);
            while (dr.Read())
            {
                Municipio mi_municipio = new Municipio();
                mi_municipio.ID_DEPARTAMENTO = Convert.ToInt32(dr["id_departamento"]);
                mi_municipio.ID_MUNICIPIO = Convert.ToInt32(dr["id_municipio"]);
                mi_municipio.NOMBRE_MUNICIPIO = dr["nombre_municipio"].ToString();
                mi_municipio.NOMBRE_DEPARTAMENTO = dr["nombre_departamento"].ToString();
                mi_municipio.NOMBRE_PAIS = dr["nombre_pais"].ToString();
                lista_municipios.Add(mi_municipio);
            }

            dr.Dispose();
            return View(lista_municipios);
        }

   

        // GET: municipioController/Create
        public ActionResult Create()
        {
            var departamentos = new List<SelectListItem>();

            var sql = "SELECT * FROM DEPARTAMENTO_ESTADO_ ORDER BY NOMBRE_DEPARTAMENTO";
            var dr = ora_conn.ExecuteReader(sql);
            while (dr.Read())
            {
                departamentos.Add(new SelectListItem()
                {
                    Text = dr["nombre_departamento"].ToString(),
                    Value = dr["id_departamento"].ToString()
                });
            }
            ViewBag.departamentos = departamentos;
            return View();
        }

        // POST: municipioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var nombre_municipio = collection["nombre_municipio"];
                var id_departamento = collection["id_departamento"];
                var sql = $"INSERT INTO MUNICIPIO_CIUDAD_ (ID_MUNICIPIO, ID_DEPARTAMENTO, NOMBRE_MUNICIPIO) VALUES ((SELECT NVL(MAX(ID_MUNICIPIO),0) + 1 FROM MUNICIPIO_CIUDAD_)," +
                    $"'{id_departamento}','{nombre_municipio.ToString().ToUpper().Trim()}')";
                ora_conn.ExecuteNonQuery(sql);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
                return View();
            }
        }

        // GET: municipioController/Edit/5
        public ActionResult Edit(int id)
        {
            Municipio mi_municipio = new Municipio();
            var sql = $"SELECT * FROM MUNICIPIO_CIUDAD_ WHERE ID_MUNICIPIO = {id}";
            var dr = ora_conn.ExecuteReader(sql);
            while (dr.Read())
            {
                mi_municipio.ID_MUNICIPIO = Convert.ToInt32(dr["id_municipio"]);
                mi_municipio.ID_DEPARTAMENTO = Convert.ToInt32(dr["id_departamento"]);
                mi_municipio.NOMBRE_MUNICIPIO = dr["nombre_municipio"].ToString();
            }
            dr.Dispose();
            return View(mi_municipio);
        }

        // POST: municipioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                var nombre_municipio = collection["nombre_municipio"];
                var sql = $"UPDATE MUNICIPIO_CIUDAD_ SET NOMBRE_MUNICIPIO = '{nombre_municipio.ToString().ToUpper().Trim()}' WHERE ID_MUNICIPIO = {id}";
                ora_conn.ExecuteNonQuery(sql);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
                return View();
            }
        }

        // GET: municipioController/Delete/5
        public ActionResult Delete(int id)
        {
            Municipio mi_municipio = new Municipio();
            var sql = $"SELECT * FROM MUNICIPIO_CIUDAD_ WHERE ID_MUNICIPIO = {id}";
            var dr = ora_conn.ExecuteReader(sql);
            while (dr.Read())
            {
                mi_municipio.ID_MUNICIPIO = Convert.ToInt32(dr["id_municipio"]);
                mi_municipio.ID_DEPARTAMENTO = Convert.ToInt32(dr["id_departamento"]);
                mi_municipio.NOMBRE_MUNICIPIO = dr["nombre_municipio"].ToString();
            }
            dr.Dispose();
            return View(mi_municipio);
        }

        // POST: municipioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var sql = $"DELETE FROM MUNICIPIO_CIUDAD_ WHERE ID_MUNICIPIO = '{id}'";
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
