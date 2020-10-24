using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace p_bd1_proveedores_cuentas_por_pagar.Controllers
{
    public static class ora_conn
    {
        public static string connection_string = "Data Source=31.193.227.12:1521/ORCLCDB.localdomain; User Id=proyectobd; Password=proyectobd;";

        public static void ExecuteNonQuery(string sql)
        {
            using (OracleConnection con = new OracleConnection(connection_string))
            {
                using (OracleCommand cmd = new OracleCommand())
                {
                    try
                    {
                        con.Open();
                        //cmd.BindByName = true;
                        cmd.Connection = con;
                        cmd.CommandText = sql;
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }

            }
        }
        public static OracleDataReader ExecuteReader(string sql)
        {
            using (OracleConnection con = new OracleConnection(connection_string))
            {
                using (OracleCommand cmd = new OracleCommand())
                {
                    try
                    {
                        con.Open();
                        //cmd.BindByName = true;
                        cmd.Connection = con;
                        cmd.CommandText = sql;
                        return cmd.ExecuteReader();
                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }
                }

            }
        }
    }
}
