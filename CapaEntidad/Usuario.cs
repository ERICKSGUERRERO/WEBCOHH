using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Usuario
    {
        //atributos para listar 
        public int dni { get; set; }
        public int id_trabajador { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string usuario { get; set; }
        public string contrasenia { get; set; }

        public string tipo_usuario { get; set; }

        public string descripcion { get; set; }

        public Boolean estado { get; set; }
        public int id_usuario { get; set; }


        //atributos de la tabla usuario
        public int id_tipo_usuario { get; set; }
        
       
        

       
        
    }
}
