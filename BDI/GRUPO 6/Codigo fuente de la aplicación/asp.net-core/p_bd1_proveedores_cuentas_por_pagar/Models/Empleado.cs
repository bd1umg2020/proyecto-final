using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace p_bd1_proveedores_cuentas_por_pagar.Models
{
    public class Empleado
    {
        public int ID_EMPLEADO { get; set; }
        public int ID_PERSONA { get; set; }
        public string STATUS { get; set; }
        public string NOMBRE_PERSONA { get; set; }
        public string APELLIDO_PERSONA { get; set; }
    }
}
