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
    public class departamentoController : Controller
    {
        // GET: departamentoController
        public ActionResult Index()
        {
            List<Departamento> lista_departamentos = new List<Departamento>();
            var sql = "SELECT * FROM DEPARTAMENTO_ESTADO_ A INNER JOIN PAIS B ON A.ID_PAIS = B.ID_PAIS ORDER BY NOMBRE_PAIS, NOMBRE_DEPARTAMENTO";
            var dr = ora_conn.ExecuteReader(sql);
            while (dr.Read())
            {
                Departamento mi_departamento = new Departamento();
                mi_departamento.ID_DEPARTAMENTO = Convert.ToInt32(dr["id_departamento"]);
                mi_departamento.ID_PAIS = Convert.ToInt32(dr["id_pais"]);
                mi_departamento.NOMBRE_DEPARTAMENTO = dr["nombre_departamento"].ToString();
                mi_departamento.NOMBRE_PAIS = dr["nombre_pais"].ToString();
                lista_departamentos.Add(mi_departamento);
            }

            dr.Dispose();
            return View(lista_departamentos);
        }

        // GET: departamentoController/Create
        public ActionResult Create()
        {
            var paises = new List<SelectListItem>();

            var sql = "SELECT * FROM PAIS ORDER BY NOMBRE_PAIS";
            var dr = ora_conn.ExecuteReader(sql);
            while (dr.Read())
            {
                paises.Add(new SelectListItem()
                {
                    Text = dr["nombre_pais"].ToString(),
                    Value = dr["id_pais"].ToString()
                });
            }
            ViewBag.paises = paises;
            return View();
        }

        // POST: departamentoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var nombre_departamento = collection["nombre_departamento"];
                var id_pais = collection["id_pais"];
                var sql = $"INSERT INTO DEPARTAMENTO_ESTADO_ (ID_DEPARTAMENTO, ID_PAIS, NOMBRE_DEPARTAMENTO) VALUES ((SELECT NVL(MAX(ID_DEPARTAMENTO),0) + 1 FROM DEPARTAMENTO_ESTADO_)," +
                    $"'{id_pais}','{nombre_departamento.ToString().ToUpper().Trim()}')";
                ora_conn.ExecuteNonQuery(sql);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
                return View();
            }
        }

        // GET: departamentoController/Edit/5
        public ActionResult Edit(int id)
        {
            Departamento mi_departamento = new Departamento();
            var sql = $"SELECT * FROM DEPARTAMENTO_ESTADO_ WHERE ID_DEPARTAMENTO = {id}";
            var dr = ora_conn.ExecuteReader(sql);
            while (dr.Read())
            {
                mi_departamento.ID_DEPARTAMENTO = Convert.ToInt32(dr["id_departamento"]);
                mi_departamento.ID_PAIS = Convert.ToInt32(dr["id_pais"]);
                mi_departamento.NOMBRE_DEPARTAMENTO = dr["nombre_departamento"].ToString();
            }
            dr.Dispose();
            return View(mi_departamento);
        }

        // POST: departamentoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                var nombre_departamento = collection["nombre_departamento"];
                var sql = $"UPDATE DEPARTAMENTO_ESTADO_ SET NOMBRE_DEPARTAMENTO = '{nombre_departamento.ToString().ToUpper().Trim()}' WHERE ID_DEPARTAMENTO = {id}";
                ora_conn.ExecuteNonQuery(sql);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
                return View();
            }
        }

        // GET: departamentoController/Delete/5
        public ActionResult Delete(int id)
        {
            Departamento mi_departamento = new Departamento();
            var sql = $"SELECT * FROM DEPARTAMENTO_ESTADO_ WHERE ID_DEPARTAMENTO = {id}";
            var dr = ora_conn.ExecuteReader(sql);
            while (dr.Read())
            {
                mi_departamento.ID_DEPARTAMENTO = Convert.ToInt32(dr["id_departamento"]);
                mi_departamento.ID_PAIS = Convert.ToInt32(dr["id_pais"]);
                mi_departamento.NOMBRE_DEPARTAMENTO = dr["nombre_departamento"].ToString();
            }
            dr.Dispose();
            return View(mi_departamento);
        }

        // POST: departamentoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var sql = $"DELETE FROM DEPARTAMENTO_ESTADO_ WHERE ID_DEPARTAMENTO = '{id}'";
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
