using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace p_bd1_proveedores_cuentas_por_pagar.Models
{
    public class Direccion_
    {
        public int ID_DIRECCION { get; set; }
        public int ID_ZONA { get; set; }
        public string DIRECCION { get; set; }
        public string NOMBRE_ZONA { get; set; }
        public string NOMBRE_MUNICIPIO { get; set; }
        public string NOMBRE_DEPARTAMENTO { get; set; }
        public string NOMBRE_PAIS { get; set; }
    }
}
