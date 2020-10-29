using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace p_bd1_proveedores_cuentas_por_pagar.Models
{
    public class Factura_proveedor
    {
        public int ID_FACTURA_PROVEEDOR { get; set; }
        public int ID_SERVICIO { get; set; }
        public int ID_ORDEN_COMPRA { get; set; }
        public int SERIE_FACTURA { get; set; }
        public int NUMERO_FACTURA { get; set; }
        public DateTime FECHA { get; set; }
        public double MONTO { get; set; }
    }
}
