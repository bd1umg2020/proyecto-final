using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using p_bd1_proveedores_cuentas_por_pagar.Models;

namespace p_bd1_proveedores_cuentas_por_pagar.Controllers
{
    public class personaController : Controller
    {
        // GET: personaController
        public ActionResult Index()
        {
            List<Persona> lista_personas = new List<Persona>();
            var sql = "SELECT * FROM PERSONA ORDER BY ID_PERSONA";
            var dr = ora_conn.ExecuteReader(sql);
            while (dr.Read())
            {
                Persona mi_persona = new Persona();
                mi_persona.ID_PERSONA = Convert.ToInt32(dr["id_persona"]);
                mi_persona.NOMBRE_PERSONA = dr["nombre_persona"].ToString();
                mi_persona.APELLIDO_PERSONA = dr["apellido_persona"].ToString();
                mi_persona.GENERO = dr["genero"].ToString();
                mi_persona.DPI_PERSONA = dr["dpi_persona"].ToString();
                mi_persona.NIT_PERSONA = dr["nit_persona"].ToString();
                lista_personas.Add(mi_persona);
            }

            dr.Dispose();
            return View(lista_personas); ;
        }

        // GET: personaController/Details/5
        public ActionResult Details(int id)
        {
            Persona mi_persona = new Persona();
            var sql = $"SELECT * FROM PERSONA WHERE ID_PERSONA = {id}";
            var dr = ora_conn.ExecuteReader(sql);
            while (dr.Read())
            {
                mi_persona.ID_PERSONA = Convert.ToInt32(dr["id_persona"]);
                mi_persona.ID_DIRECCION = Convert.ToInt32(dr["id_direccion"]);
                mi_persona.NOMBRE_PERSONA = dr["nombre_persona"].ToString();
                mi_persona.APELLIDO_PERSONA = dr["apellido_persona"].ToString();
                mi_persona.GENERO = dr["genero"].ToString();
                mi_persona.DPI_PERSONA = dr["dpi_persona"].ToString();
                mi_persona.NIT_PERSONA = dr["nit_persona"].ToString();
                mi_persona.CORREO_PERSONA = dr["correo_persona"].ToString();
                mi_persona.TELEFONO = dr["telefono"].ToString();
            }
            return View(mi_persona);
        }

        // GET: personaController/Create
        public ActionResult Create()
        {
            var direcciones = new List<SelectListItem>();
            var sql = "SELECT * FROM DIRECCION ORDER BY DIRECCION";
            var dr = ora_conn.ExecuteReader(sql);
            while (dr.Read())
            {
                direcciones.Add(new SelectListItem()
                {
                    Text = dr["direccion"].ToString(),
                    Value = dr["id_direccion"].ToString()
                });
            }
            ViewBag.direcciones = direcciones;
            return View();
        }

        // POST: personaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var id_direccion = collection["id_direccion"];
                var nombre = collection["nombre_persona"];
                var apellido = collection["apellido_persona"];
                var genero = collection["genero"];
                var correo = collection["correo_persona"];
                var dpi = collection["dpi_persona"];
                var nit = collection["nit_persona"];
                var telefono = collection["telefono"];
                var sql = $"INSERT INTO PERSONA (ID_PERSONA, ID_DIRECCION, NOMBRE_PERSONA, APELLIDO_PERSONA, GENERO, CORREO_PERSONA" +
                    $",DPI_PERSONA, NIT_PERSONA, TELEFONO) VALUES ((SELECT NVL(MAX(ID_PERSONA),0) + 1 FROM PERSONA),'{id_direccion}','{nombre.ToString().ToUpper().Trim()}','{apellido.ToString().ToUpper().Trim()}','{genero.ToString().ToUpper().Trim()}'," +
                    $"'{correo.ToString().ToUpper().Trim()}','{dpi.ToString().ToUpper().Trim()}','{nit.ToString().ToUpper().Trim()}','{telefono.ToString().ToUpper().Trim()}')";
                ora_conn.ExecuteNonQuery(sql);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
                return View();
            }
        }

        // GET: personaController/Edit/5
        public ActionResult Edit(int id)
        {
            Persona mi_persona = new Persona();
            var sql = $"SELECT * FROM PERSONA WHERE ID_PERSONA = {id}";
            var dr = ora_conn.ExecuteReader(sql);
            while (dr.Read())
            {
                mi_persona.ID_PERSONA = Convert.ToInt32(dr["id_persona"]);
                mi_persona.ID_DIRECCION = Convert.ToInt32(dr["id_direccion"]);
                mi_persona.NOMBRE_PERSONA = dr["nombre_persona"].ToString();
                mi_persona.APELLIDO_PERSONA = dr["apellido_persona"].ToString();
                mi_persona.GENERO = dr["genero"].ToString();
                mi_persona.DPI_PERSONA = dr["dpi_persona"].ToString();
                mi_persona.NIT_PERSONA = dr["nit_persona"].ToString();
                mi_persona.CORREO_PERSONA = dr["correo_persona"].ToString();
                mi_persona.TELEFONO = dr["telefono"].ToString();
            }

            var direcciones = new List<SelectListItem>();
            sql = "SELECT * FROM DIRECCION ORDER BY DIRECCION";
            dr = ora_conn.ExecuteReader(sql);
            while (dr.Read())
            {
                direcciones.Add(new SelectListItem()
                {
                    Text = dr["direccion"].ToString(),
                    Value = dr["id_direccion"].ToString()
                });
            }
            ViewBag.direcciones = direcciones;

            return View(mi_persona);
        }

        // POST: personaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                var id_direccion = collection["id_direccion"];
                var nombre = collection["nombre_persona"];
                var apellido = collection["apellido_persona"];
                var genero = collection["genero"];
                var correo = collection["correo_persona"];
                var dpi = collection["dpi_persona"];
                var nit = collection["nit_persona"];
                var telefono = collection["telefono"];
                var sql = $"UPDATE PERSONA SET  ID_DIRECCION = '{id_direccion}', NOMBRE_PERSONA='{nombre}', APELLIDO_PERSONA='{apellido}', GENERO='{genero}', " +
                    $"CORREO_PERSONA='{correo}', DPI_PERSONA='{dpi}', NIT_PERSONA='{nit}', TELEFONO='{telefono}'" +
                    $" WHERE ID_PERSONA = '{id}'";
                ora_conn.ExecuteNonQuery(sql);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
                return View();
            }
        }

        // GET: personaController/Delete/5
        public ActionResult Delete(int id)
        {
            Persona mi_persona = new Persona();
            var sql = $"SELECT * FROM PERSONA WHERE ID_PERSONA = {id}";
            var dr = ora_conn.ExecuteReader(sql);
            while (dr.Read())
            {
                mi_persona.ID_PERSONA = Convert.ToInt32(dr["id_persona"]);
                mi_persona.ID_DIRECCION = Convert.ToInt32(dr["id_direccion"]);
                mi_persona.NOMBRE_PERSONA = dr["nombre_persona"].ToString();
                mi_persona.APELLIDO_PERSONA = dr["apellido_persona"].ToString();
                mi_persona.GENERO = dr["genero"].ToString();
                mi_persona.DPI_PERSONA = dr["dpi_persona"].ToString();
                mi_persona.NIT_PERSONA = dr["nit_persona"].ToString();
                mi_persona.CORREO_PERSONA = dr["correo_persona"].ToString();
                mi_persona.TELEFONO = dr["telefono"].ToString();
            }
            return View(mi_persona);
        }

        // POST: personaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var sql = $"DELETE FROM PERSONA WHERE ID_PERSONA = '{id}'";
                ora_conn.ExecuteNonQuery(sql);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
                return View();
            }
        }

        public JsonResult obtenerDireccionCompleta(int idDireccion)
        {


            direccion_compleata mi_direccion = new direccion_compleata();
            var sql = $"SELECT * FROM DIRECCION A INNER JOIN ZONA_SECTOR_ B ON A.ID_ZONA = B.ID_ZONA INNER JOIN MUNICIPIO_CIUDAD_ C ON C.ID_MUNICIPIO = B.ID_MUNICIPIO " +
                $"INNER JOIN DEPARTAMENTO_ESTADO_ D ON D.ID_DEPARTAMENTO = C.ID_DEPARTAMENTO INNER JOIN PAIS E ON E.ID_PAIS = D.ID_PAIS WHERE ID_DIRECCION = '{idDireccion}'";
            var dr = ora_conn.ExecuteReader(sql);
            while (dr.Read())
            {
                mi_direccion.zona = dr["nombre_zona"].ToString();
                mi_direccion.municipio = dr["nombre_municipio"].ToString();
                mi_direccion.departamento = dr["nombre_departamento"].ToString();
                mi_direccion.pais = dr["nombre_pais"].ToString();
            }

            dr.Dispose();

            return Json(mi_direccion);

        }
        public class direccion_compleata
        {
            public string zona { get; set; }
            public string municipio { get; set; }
            public string departamento { get; set; }
            public string pais { get; set; }
        };


        public ActionResult CrearEmpleado(int id)
        {
            var sql = $"INSERT INTO EMPLEADO (ID_EMPLEADO, ID_PERSONA, STATUS) VALUES ((SELECT NVL(MAX(ID_EMPLEADO),0) + 1 FROM EMPLEADO),'{id}','ACTIVO')";
            ora_conn.ExecuteNonQuery(sql);
            return RedirectToAction("Index", "empleado");
        }


    }
}
