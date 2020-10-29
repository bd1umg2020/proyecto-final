using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace p_bd1_proveedores_cuentas_por_pagar.Models
{
    public class Departamento
    {
        public int ID_DEPARTAMENTO { get; set; }
        public int ID_PAIS { get; set; }
        public string NOMBRE_DEPARTAMENTO { get; set; }
        public string NOMBRE_PAIS { get; set; }
    }
}
