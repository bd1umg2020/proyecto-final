using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace p_bd1_proveedores_cuentas_por_pagar.Models
{
    public class Proveedor
    {
        public int ID_PROVEEDOR { get; set; }
        public int ID_TIPO_PROVEEDOR { get; set; }
        public int ID_PERSONA { get; set; }
        public int ID_DIRECCION { get; set; }
        public string NOMBRE_PROVEEDOR { get; set; }
        public string NIT_PROVEEDOR { get; set; }
        public string NOMBRE_TIPO_PROVEEDOR { get; internal set; }
        public string DIRECCION { get; internal set; }
    }
}
