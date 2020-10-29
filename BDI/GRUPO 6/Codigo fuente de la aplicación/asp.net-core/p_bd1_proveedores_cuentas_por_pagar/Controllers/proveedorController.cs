using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using p_bd1_proveedores_cuentas_por_pagar.Models;

namespace p_bd1_proveedores_cuentas_por_pagar.Controllers
{
    public class proveedorController : Controller
    {
        // GET: proveedorController
        public ActionResult Index()
        {
            List<Proveedor> lista_proveedores = new List<Proveedor>();
            var sql = "SELECT * FROM PROVEEDOR A INNER JOIN TIPO_PROVEEDOR B ON A.ID_TIPO_PROVEEDOR = B.ID_TIPO_PROVEEDOR " +
                "INNER JOIN DIRECCION C ON C.ID_DIRECCION = A.ID_DIRECCION INNER JOIN ZONA_SECTOR_ D ON D.ID_ZONA = C.ID_ZONA " +
                "INNER JOIN MUNICIPIO_CIUDAD_ E ON E.ID_MUNICIPIO = D.ID_MUNICIPIO INNER JOIN DEPARTAMENTO_ESTADO_ F ON F.DEPARTAMENTO = E.ID_DEPARTAMENTO " +
                "INNER JOIN PAIS G ON G.ID_PAIS = F.ID_PAIS ORDER BY NOMBRE_PROVEEDOR";
            var dr = ora_conn.ExecuteReader(sql);
            while (dr.Read())
            {
                Proveedor mi_proveedor = new Proveedor();
                mi_proveedor.ID_PROVEEDOR = Convert.ToInt32(dr["ID_PROVEEDOR"]);
                mi_proveedor.NOMBRE_TIPO_PROVEEDOR = dr["NOMBRE_TIPO_PROVEEDOR"].ToString();
                mi_proveedor.DIRECCION = $"{dr["DIRECCION"].ToString()}, {dr["NOMBRE_ZONA"].ToString()}, {dr["NOMBRE_MUNICIPIO"].ToString()},{dr["NOMBER_DEPARTAMENTO"].ToString()},{dr["NOMBRE_PAISS"].ToString()}" ;
                mi_proveedor.NOMBRE_PROVEEDOR = dr["NOMBRE_PROVEEDOR"].ToString();
                mi_proveedor.NIT_PROVEEDOR = dr["NIT_PROVEEDOR"].ToString();
                lista_proveedores.Add(mi_proveedor);
            }

            dr.Dispose();
            return View(lista_proveedores);
        }

        // GET: proveedorController/Details/5
        public ActionResult Details(int id)
        {
            Proveedor mi_proveedor = new Proveedor();
            var sql = $"SELECT * FROM PROVEEDOR WHERE ID_PROVEEDOR = {id}";
            var dr = ora_conn.ExecuteReader(sql);
            while (dr.Read())
            {
                mi_proveedor.ID_PERSONA = Convert.ToInt32(dr["id_persona"]);
                mi_proveedor.ID_DIRECCION = Convert.ToInt32(dr["id_direccion"]);
                mi_proveedor.ID_TIPO_PROVEEDOR = Convert.ToInt32(dr["ID_TIPO_PROVEEDOR"]);
                mi_proveedor.NOMBRE_PROVEEDOR = dr["NOMBRE_PROVEEDOR"].ToString();
                mi_proveedor.NIT_PROVEEDOR = dr["NIT_PROVEEDOR"].ToString();

            }
            return View(mi_proveedor);
        }

        // GET: proveedorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: proveedorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var nombre = collection["nombre_proveedor"];
                var nit = collection["nit_proveedor"];
                var sql = $"INSERT INTO PROVEEDOR (ID_PROVEEDOR, ID_TIPO_PROVEEDOR, ID_PERSONA, ID_DIRECCION, NOMBRE_PROVEEDOR, NIT_PROVEEDOR) VALUES ('1'," +
                    $"'1','1','1','{nombre}','{nit}')";
                ora_conn.ExecuteNonQuery(sql);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.error = ex.Message;
                return View();
            }
        }

        // GET: proveedorController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: proveedorController/Edit/5
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

        // GET: proveedorController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: proveedorController/Delete/5
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


        public ActionResult CrearContacto()
        {
            return View();
        }
        public ActionResult EliminarContacto()
        {
            return View();
        }
    }
}
