using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace p_bd1_proveedores_cuentas_por_pagar.Models
{
    public class Banco
    {
        public int ID_BANCO { get; set; }
        public int ID_TIPO_CUENTA { get; set; }
        public string NOMBRE_BANCO { get; set; }
        public string NO_CUENTA { get; set; }
        public string SALDO { get; set; }
    }
}
