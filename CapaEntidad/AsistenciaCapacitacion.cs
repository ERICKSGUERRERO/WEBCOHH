using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class AsistenciaCapacitacion
    {
        public int id_asistencia_capacitacion { get; set; }
        public int id_capacitacion { get; set; }

        public int id_trabajador { get; set; }
        public Boolean estado { get; set; }
    }
}
