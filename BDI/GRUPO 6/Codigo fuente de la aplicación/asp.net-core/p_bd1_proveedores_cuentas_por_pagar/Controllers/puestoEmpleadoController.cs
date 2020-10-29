using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using p_bd1_proveedores_cuentas_por_pagar.Models;

namespace p_bd1_proveedores_cuentas_por_pagar.Controllers
{
    public class puestoEmpleadoController : Controller
    {
        // GET: puestoEmpleadoController
        public ActionResult Index(int id)
        {
            List<Puesto_empleado> lista_puesto_empleado = new List<Puesto_empleado>();
            var sql = $"SELECT * FROM PUESTO_EMPLEADO A INNER JOIN PUESTO B ON B.ID_PUESTO = A.ID_PUESTO INNER JOIN EMPLEADO C ON C.ID_EMPLEADO = A.ID_EMPLEADO " +
                $"INNER JOIN PERSONA D ON D.ID_PERSONA = C.ID_PERSONA INNER JOIN ROL E ON E.ID_ROL = A.ID_ROL WHERE ID_EMPLEADO = {id} ORDER BY FECHA_INICIO DESC";
            var dr = ora_conn.ExecuteReader(sql);
            while (dr.Read())
            {
                Puesto_empleado mi_puesto_empleado = new Puesto_empleado();
                mi_puesto_empleado.ID_PUESTO_EMPLEADO = Convert.ToInt32(dr["ID_PUESTO_EMPLEADO"]);
                mi_puesto_empleado.ID_PUESTO = Convert.ToInt32(dr["ID_PUESTO"]);
                mi_puesto_empleado.ID_EMPLEADO = Convert.ToInt32(dr["ID_EMPLEADO"]);
                mi_puesto_empleado.ID_ROL = Convert.ToInt32(dr["ID_ROL"]);
                mi_puesto_empleado.FECHA_INICIO = Convert.ToDateTime(dr["FECHA_INICIO"]);
                mi_puesto_empleado.FECHA_FIN = Convert.ToDateTime(dr["FECHA_FIN"]);
                mi_puesto_empleado.NOMBRE_PERSONA = dr["NOMBRE_PERSONA"].ToString();
                mi_puesto_empleado.NOMBRE_PUESTO =dr["NOMBRE_PUESTO"].ToString();
                mi_puesto_empleado.NOMBRE_ROL = dr["NOMBRE_ROL"].ToString();
                lista_puesto_empleado.Add(mi_puesto_empleado);
            }
            dr.Dispose();
            return View(lista_puesto_empleado);
        }

        // GET: puestoEmpleadoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: puestoEmpleadoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: puestoEmpleadoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: puestoEmpleadoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: puestoEmpleadoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: puestoEmpleadoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: puestoEmpleadoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
