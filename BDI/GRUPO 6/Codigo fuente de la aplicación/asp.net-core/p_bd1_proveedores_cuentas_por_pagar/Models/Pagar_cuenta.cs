using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace p_bd1_proveedores_cuentas_por_pagar.Models
{
    public class Pagar_cuenta
    {
        public int ID_PARGAR_CUENTA { get; set; }
        public int ID_FORMA_PAGO { get; set; }
        public int ID_CUENTA_PAGAR { get; set; }
        public int ID_BANCO { get; set; }
        public double MyProperty { get; set; }
    }
}
