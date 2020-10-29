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
    public class direccionController : Controller
    {
        // GET: direccionController
        public ActionResult Index()
        {
            List<Direccion_> lista_direcciones = new List<Direccion_>();
            var sql = "SELECT * FROM DIRECCION A INNER JOIN ZONA_SECTOR_ B ON A.ID_ZONA = B.ID_ZONA INNER JOIN MUNICIPIO_CIUDAD_ C ON B.ID_MUNICIPIO = C.ID_MUNICIPIO INNER JOIN DEPARTAMENTO_ESTADO_ D ON D.ID_DEPARTAMENTO = C.ID_DEPARTAMENTO INNER JOIN PAIS E ON E.ID_PAIS = D.ID_PAIS ORDER BY NOMBRE_PAIS, NOMBRE_DEPARTAMENTO, NOMBRE_MUNICIPIO, NOMBRE_ZONA";
            var dr = ora_conn.ExecuteReader(sql);
            while (dr.Read())
            {
                Direccion_ mi_direccion = new Direccion_();
                mi_direccion.ID_ZONA = Convert.ToInt32(dr["id_zona"]);
                mi_direccion.ID_DIRECCION = Convert.ToInt32(dr["id_direccion"]);
                mi_direccion.DIRECCION = dr["direccion"].ToString();
                mi_direccion.NOMBRE_ZONA = dr["nombre_zona"].ToString();
                mi_direccion.NOMBRE_MUNICIPIO = dr["nombre_municipio"].ToString();
                mi_direccion.NOMBRE_DEPARTAMENTO = dr["nombre_departamento"].ToString();
                mi_direccion.NOMBRE_PAIS = dr["nombre_pais"].ToString();
                lista_direcciones.Add(mi_direccion);
            }

            dr.Dispose();
            return View(lista_direcciones);
        }

        // GET: direccionController/Create
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

        // POST: direccionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection, string zona) 
        {
            try
            {
                var direccion = collection["direccion"];
  
                var sql = $"INSERT INTO DIRECCION (ID_DIRECCION, ID_ZONA, DIRECCION) VALUES ((SELECT NVL(MAX(ID_DIRECCION),0) + 1 FROM DIRECCION)," +
                    $"'{zona}','{direccion.ToString().ToUpper().Trim()}')";
                ora_conn.ExecuteNonQuery(sql);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
                return View();
            }
        }

        // GET: direccionController/Edit/5
        public ActionResult Edit(int id)
        {
            Direccion_ mi_direccion = new Direccion_();
            var sql = $"SELECT * FROM DIRECCION WHERE ID_DIRECCION = {id}";
            var dr = ora_conn.ExecuteReader(sql);
            while (dr.Read())
            {
                mi_direccion.ID_ZONA = Convert.ToInt32(dr["id_zona"]);
                mi_direccion.ID_DIRECCION = Convert.ToInt32(dr["id_direccion"]);
                mi_direccion.DIRECCION = dr["direccion"].ToString();
            }
            dr.Dispose();
            return View(mi_direccion);
        }

        // POST: direccionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                var direccion = collection["direccion"];
                var sql = $"UPDATE DIRECCION SET DIRECCION = '{direccion.ToString().ToUpper().Trim()}' WHERE ID_DIRECCION = {id}";
                ora_conn.ExecuteNonQuery(sql);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
                return View();
            }
        }

        // GET: direccionController/Delete/5
        public ActionResult Delete(int id)
        {
            Direccion_ mi_direccion = new Direccion_();
            var sql = $"SELECT * FROM DIRECCION WHERE ID_DIRECCION = {id}";
            var dr = ora_conn.ExecuteReader(sql);
            while (dr.Read())
            {
                mi_direccion.ID_ZONA = Convert.ToInt32(dr["id_zona"]);
                mi_direccion.ID_DIRECCION = Convert.ToInt32(dr["id_direccion"]);
                mi_direccion.DIRECCION = dr["direccion"].ToString();
            }
            dr.Dispose();
            return View(mi_direccion);
        }

        // POST: direccionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var sql = $"DELETE FROM DIRECCION WHERE ID_DIRECCION = '{id}'";
                ora_conn.ExecuteNonQuery(sql);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
                return View();
            }
        }


        public JsonResult obtenerDepartamentos(int idPais)
        {

            List<Departamento> lista_departamentos = new List<Departamento>();
            var sql = $"SELECT * FROM DEPARTAMENTO_ESTADO_ WHERE ID_PAIS = '{idPais}'";
            var dr = ora_conn.ExecuteReader(sql);
            while (dr.Read())
            {
                Departamento mi_departamento = new Departamento();
                mi_departamento.ID_DEPARTAMENTO = Convert.ToInt32(dr["id_departamento"]);
                mi_departamento.ID_PAIS = Convert.ToInt32(dr["id_pais"]);
                mi_departamento.NOMBRE_DEPARTAMENTO = dr["nombre_departamento"].ToString();
                lista_departamentos.Add(mi_departamento);
            }

            dr.Dispose();
            lista_departamentos.Insert(0, new Departamento
            {
                ID_DEPARTAMENTO = -1,
                ID_PAIS = -1,
                NOMBRE_DEPARTAMENTO = "Selecciones departamento"
            });
            return Json(lista_departamentos);

        }

        public JsonResult obtenerMunicipios(int idDepartamento)
        {

            List<Municipio> lista_municipios = new List<Municipio>();
            var sql = $"SELECT * FROM MUNICIPIO_CIUDAD_ WHERE ID_DEPARTAMENTO = '{idDepartamento}'";
            var dr = ora_conn.ExecuteReader(sql);
            while (dr.Read())
            {
                Municipio mi_municipio = new Municipio();
                mi_municipio.ID_DEPARTAMENTO = Convert.ToInt32(dr["id_departamento"]);
                mi_municipio.ID_MUNICIPIO = Convert.ToInt32(dr["id_municipio"]);
                mi_municipio.NOMBRE_MUNICIPIO = dr["nombre_municipio"].ToString();
                lista_municipios.Add(mi_municipio);
            }

            dr.Dispose();
            lista_municipios.Insert(0, new Municipio
            {
                ID_DEPARTAMENTO = -1,
                ID_MUNICIPIO = -1,
                NOMBRE_MUNICIPIO = "Seleccione Municipio"
            });
            return Json(lista_municipios);

        }

        public JsonResult obtenerZonas(int idMunicipio)
        {

            List<Zona> lista_zonas = new List<Zona>();
            var sql = $"SELECT * FROM ZONA_SECTOR_ WHERE ID_MUNICIPIO = '{idMunicipio}'";
            var dr = ora_conn.ExecuteReader(sql);
            while (dr.Read())
            {
                Zona mi_zona = new Zona();
                mi_zona.ID_MUNICIPIO = Convert.ToInt32(dr["id_municipio"]);
                mi_zona.ID_ZONA = Convert.ToInt32(dr["id_zona"]);
                mi_zona.NOMBRE_ZONA = dr["nombre_zona"].ToString();
                lista_zonas.Add(mi_zona);
            }

            dr.Dispose();
            lista_zonas.Insert(0, new Zona
            {
                ID_ZONA = -1,
                ID_MUNICIPIO = -1,
                NOMBRE_ZONA = "Selecciones zona"
            });
            return Json(lista_zonas);

        }

    }
}
