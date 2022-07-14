using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlTypes;

namespace CapaEntidad
{
    public class Asistencia
    {
        public int id_asistencia { get; set; }
        public int id_trabajador { get; set; }
        public string hora_inicio { get; set; }
        public string hora_salida { get; set; }

        public int id_contrato { get; set; }

        public int id_estado_asistencia { get; set; }

        public Boolean alcotest { get; set; }

        public int id_persona { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public char genero { get; set; }

        public int dni { get; set; }

        public string estado_asistencia { get; set; }
    }
}
