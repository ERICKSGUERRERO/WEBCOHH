using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Postulante
    {
        public int ID_POSTULANTE { get; set; }
        public int ID_CONVOCATORIA { get; set; }
        public int ID_PERSONA { get; set; }
        public string NOMBRE { get; set; }
        public string APELLIDOS { get; set; }
        public DateTime FECHA_NACIMIENTO { get; set; }
        public char GENERO { get; set; }
        public int DNI { get; set; }
        public int NUMERO { get; set; }
        public string NOMBRE_DIRECCION { get; set; }
        
    }
}
