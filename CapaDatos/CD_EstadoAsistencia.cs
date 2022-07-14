using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;

namespace CapaDatos
{
    public class CD_EstadoAsistencia
    {
        public static CD_EstadoAsistencia _instancia = null;

        private CD_EstadoAsistencia()
        {

        }

        public static CD_EstadoAsistencia Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new CD_EstadoAsistencia();
                }
                return _instancia;
            }
        }

        public List<EstadoAsistencia> obtenerEstadoAsistencia()
        {
            List<EstadoAsistencia> estadoAsistencias = new List<EstadoAsistencia>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("[sp_listarEstadoAsistencia]", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        estadoAsistencias.Add(new EstadoAsistencia()
                        {
                            id_estado_asistencia = Convert.ToInt32(dr["ID_ESTADO_ASISTENCIA"].ToString()),
                            estado_asistencia = dr["ESTADO"].ToString()
                        }) ;
                    }
                    dr.Close();
                    return estadoAsistencias;
                }
                catch (Exception)
                {
                    estadoAsistencias = null;
                    return estadoAsistencias;
                    throw;
                }
            }
        }
    }
}
