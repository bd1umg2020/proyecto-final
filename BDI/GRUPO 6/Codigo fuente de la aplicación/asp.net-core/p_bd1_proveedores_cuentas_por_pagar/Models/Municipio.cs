using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace p_bd1_proveedores_cuentas_por_pagar.Models
{
    public class Municipio
    {
        public int ID_MUNICIPIO { get; set; }
        public int ID_DEPARTAMENTO { get; set; }
        public string NOMBRE_MUNICIPIO { get; set; }
        public string NOMBRE_DEPARTAMENTO { get; set; }
        public string NOMBRE_PAIS { get; set; }
    }
}
