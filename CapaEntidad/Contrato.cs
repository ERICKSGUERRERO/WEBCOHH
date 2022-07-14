using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Contrato
    {
        public int ID_POSTULANTE { get; set; }
        public int ID_AREA { get; set; }
        public int ID_PUESTO_TRABAJO { get; set; }
        public DateTime FECHA_INICIO { get; set; }
        public DateTime FECHA_FINAL { get; set; }
        public int ID_HORARIO { get; set; }
        public int ID_REGIMEN { get; set; }

        public float SUELDO { get; set; }

        public byte ESTADO { get; set; }
    }
}
