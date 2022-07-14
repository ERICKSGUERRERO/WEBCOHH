using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Capacitacion
    {
        public int id_persona { get; set; }
        public int id_capacitacion { get; set; }
        public int id_tema_capacitacion { get; set; }
        public string nombre_tema { get; set; }

        public string fecha { get; set; }
        public string hora_inicio { get; set; }
        public string hora_final { get; set; }

        public string nombre { get; set; }

        public string apellidos { get; set; }

        public int dni { get; set; }
    }
}
