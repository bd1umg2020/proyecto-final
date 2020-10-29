using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace p_bd1_proveedores_cuentas_por_pagar.Models
{
    public class Puesto_empleado
    {
        public int ID_PUESTO_EMPLEADO { get; set; }
        public int ID_PUESTO { get; set; }
        public int ID_EMPLEADO { get; set; }
        public int ID_ROL { get; set; }
        public DateTime FECHA_INICIO { get; set; }
        public DateTime FECHA_FIN { get; set; }
        public string NOMBRE_PERSONA { get; set; }
        public string NOMBRE_PUESTO { get; set; }
        public string NOMBRE_ROL { get; set; }
    }
}
