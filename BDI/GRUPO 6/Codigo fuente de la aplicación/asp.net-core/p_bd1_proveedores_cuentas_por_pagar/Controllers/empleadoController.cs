using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using p_bd1_proveedores_cuentas_por_pagar.Models;

namespace p_bd1_proveedores_cuentas_por_pagar.Controllers
{
    public class empleadoController : Controller
    {
        // GET: empleadoController
        public ActionResult Index()
        {
            List<Empleado> lista_empleado = new List<Empleado>();
            var sql = "SELECT * FROM EMPLEADO A INNER JOIN PERSONA B ON A.ID_PERSONA = B.ID_PERSONA ORDER BY NOMBRE_PERSONA";
            var dr = ora_conn.ExecuteReader(sql);
            while (dr.Read())
            {
                Empleado mi_empleado = new Empleado();
                mi_empleado.ID_EMPLEADO = Convert.ToInt32(dr["ID_EMPLEADO"]);
                mi_empleado.ID_PERSONA = Convert.ToInt32(dr["ID_PERSONA"]);
                mi_empleado.NOMBRE_PERSONA = dr["NOMBRE_PERSONA"].ToString();
                mi_empleado.APELLIDO_PERSONA = dr["APELLIDO_PERSONA"].ToString();
                mi_empleado.STATUS = dr["STATUS"].ToString();
                lista_empleado.Add(mi_empleado);
            }
            dr.Dispose();
            return View(lista_empleado);
        }

        public ActionResult Activar(int id)
        {
            var sql = $"UPDATE EMPLEADO SET STATUS = 'ACTIVO' WHERE ID_EMPLEADO = {id}";
            ora_conn.ExecuteNonQuery(sql);
            return RedirectToAction("index");
        }

        public ActionResult Inactivar(int id)
        {
            var sql = $"UPDATE EMPLEADO SET STATUS = 'INACTIVO' WHERE ID_EMPLEADO = {id}";
            ora_conn.ExecuteNonQuery(sql);
            return RedirectToAction("index");
        }





    }
}
