using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace p_bd1_proveedores_cuentas_por_pagar.Models
{
    public class Contacto
    {
        public int ID_CONTACTO { get; set; }
        public int ID_PROVEEDOR { get; set; }
        public int ID_PERSONA { get; set; }
    }
}
