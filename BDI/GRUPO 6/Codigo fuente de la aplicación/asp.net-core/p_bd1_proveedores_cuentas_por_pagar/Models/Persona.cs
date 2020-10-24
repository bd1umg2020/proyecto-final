using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace p_bd1_proveedores_cuentas_por_pagar.Models
{
    public class Persona
    {
        public int ID_PERSONA { get; set; }
        public int ID_DIRECCION { get; set; }
        public int ID_TELEFONO { get; set; }
        public string NOMBRE_PERSONA { get; set; }
        public string APELLIDO_PERSONA { get; set; }
        public string GENERO { get; set; }
        public string CORREO_PERSONA { get; set; }
        public string DPI_PERSONA { get; set; }
        public string NIT_PERSONA { get; set; }
    }
}
