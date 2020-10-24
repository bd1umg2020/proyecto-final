using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Oracle.ManagedDataAccess.Client;
using p_bd1_proveedores_cuentas_por_pagar.Models;

namespace p_bd1_proveedores_cuentas_por_pagar.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (true)
            {
                return RedirectToAction("Login");
            }
            ViewBag.lista_resultados = "";
            var connection = "Data Source=31.193.227.12:1521/ORCLCDB.localdomain; User Id=proyectobd; Password=proyectobd;";
            using (OracleConnection con = new OracleConnection(connection))
            {
                using (OracleCommand cmd = new OracleCommand())
                {
                    try
                    {
                        con.Open();
                        //cmd.BindByName = true;
                        cmd.Connection = con;
                        cmd.CommandText = "SELECT NOMBRE FROM PRUEBA1";
                        OracleDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            ViewBag.lista_resultados += dr.GetString(0) + "<br>";
                        }
                        dr.Dispose();
                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }
                }

            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
