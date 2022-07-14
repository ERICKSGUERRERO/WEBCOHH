using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using System.Data.SqlTypes;

namespace CapaDatos
{
    public class CD_AsistenciaCapacitacion
    {
        public static CD_AsistenciaCapacitacion _instancia = null;

        private CD_AsistenciaCapacitacion()
        {

        }

        public static CD_AsistenciaCapacitacion Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new CD_AsistenciaCapacitacion();
                }
                return _instancia;
            }
        }

        public bool registrarAsistenciaCapacitacion(AsistenciaCapacitacion asistenciaCapacitacion)
        {
            bool respuesta = false;
            Console.WriteLine(asistenciaCapacitacion);

            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("[sp_registrarAsistenciaCapacitacion]", oConexion);
                    cmd.Parameters.AddWithValue("@id_capacitacion", asistenciaCapacitacion.id_capacitacion);
                    cmd.Parameters.AddWithValue("@id_trabajador", asistenciaCapacitacion.id_trabajador);
                    cmd.Parameters.AddWithValue("@estado", asistenciaCapacitacion.estado);
                    cmd.CommandType = CommandType.StoredProcedure;
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    respuesta = true;

                }
                catch (Exception)
                {
                    respuesta = false;
                    throw;

                }
            }
            return respuesta;

        }

    }
}
