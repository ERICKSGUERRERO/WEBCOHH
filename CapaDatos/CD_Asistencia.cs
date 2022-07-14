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
    public class CD_Asistencia
    {
        public static CD_Asistencia _instancia = null;

        private CD_Asistencia()
        {

        }

        public static CD_Asistencia Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new CD_Asistencia();
                }
                return _instancia;
            }
        }
        public bool eliminarAsistencia(Asistencia asistencia)
        {
            bool respuesta = false;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("[sp_eliminarAsistencia]", oConexion);
                    cmd.Parameters.AddWithValue("@id_asistencia", asistencia.id_asistencia);
                    cmd.CommandType = CommandType.StoredProcedure;
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    respuesta = true;

                }
                catch (Exception)
                {
                    respuesta = true;
                    throw;
                }
            }
            return respuesta;

        }
        public bool actualizarAsistencia(Asistencia asistencia)
        {
            bool respuesta = false;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("[sp_actualizarAsistencia]", oConexion);
                    cmd.Parameters.AddWithValue("@id_asistencia", asistencia.id_asistencia);
                    cmd.Parameters.AddWithValue("@id_trabajador", asistencia.id_trabajador);
                    cmd.Parameters.AddWithValue("@fecha", DateTime.Now);
                    cmd.Parameters.AddWithValue("@hora_inicio", TimeSpan.Parse(asistencia.hora_inicio));
                    cmd.Parameters.AddWithValue("@hora_salida", TimeSpan.Parse(asistencia.hora_salida));
                    cmd.Parameters.AddWithValue("@alcotest", asistencia.alcotest);
                    cmd.Parameters.AddWithValue("@id_estado_asistencia", asistencia.id_estado_asistencia);
                    cmd.CommandType = CommandType.StoredProcedure;
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    respuesta = true;
                }
                catch (Exception)
                {
                    respuesta = true;
                    throw;
                }
            }
            return respuesta;


        }

        public bool registrarAsistencia(Asistencia asistencia)
        {
            bool respuesta = false;
            
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("[sp_registrarAsistencia]", oConexion);
                    cmd.Parameters.AddWithValue("@id_trabajador", asistencia.id_trabajador);
                    cmd.Parameters.AddWithValue("@fecha", DateTime.Now);
                    cmd.Parameters.AddWithValue("@hora_inicio", TimeSpan.Parse(asistencia.hora_inicio));
                    cmd.Parameters.AddWithValue("@hora_salida", TimeSpan.Parse(asistencia.hora_salida));
                    cmd.Parameters.AddWithValue("@alcotest", asistencia.alcotest);
                    cmd.Parameters.AddWithValue("@id_estado_asistencia", asistencia.id_estado_asistencia);
                    cmd.CommandType = CommandType.StoredProcedure;
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    respuesta = true;

                }
                catch (Exception)
                {
                    respuesta = true;
                    throw;
                }
            }
            return respuesta;
        }

        public Trabajador buscarTrabajadorPorDNI(int dni)
        {
            Trabajador trabajador = null;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("[sp_retornarTrabajadorPorDNI]", oConexion);
                    cmd.Parameters.AddWithValue("@dni", dni);
                    cmd.CommandType = CommandType.StoredProcedure;
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        trabajador = new Trabajador()
                        {
                            id_trabajador = Convert.ToInt32(dr["ID_TRABAJADOR"].ToString()),
                            nombre = dr["NOMBRE"].ToString(),
                            apellidos = dr["APELLIDOS"].ToString()
                            
                        };
                    }
                    dr.Close();
                    return trabajador;
                }
                catch (Exception)
                {
                    trabajador = null;
                    return trabajador;
                    throw;

                }
            }

        }

        public List<Asistencia> obtenerAsistenciasTrabajadores()
        {
            List<Asistencia> asistencias = new List<Asistencia>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("[sp_listadoAsistenciasTrabajadores]", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        asistencias.Add(new Asistencia()
                        {
                            id_asistencia = Convert.ToInt32(dr["ID_ASISTENCIA"].ToString()),
                            id_trabajador = Convert.ToInt32(dr["ID_TRABAJADOR"].ToString()),
                            id_contrato = Convert.ToInt32(dr["ID_CONTRATO"].ToString()),
                            id_estado_asistencia = Convert.ToInt32(dr["ID_ESTADO_ASISTENCIA"].ToString()),
                            hora_inicio = dr["HORA_INICIO"].ToString(),
                            hora_salida = dr["HORA_SALIDA"].ToString(),
                            estado_asistencia = dr["ESTADO"].ToString(),
                            nombre = dr["NOMBRE"].ToString(),
                            apellidos = dr["APELLIDOS"].ToString(),
                            dni = Convert.ToInt32(dr["DNI"].ToString()),
                            alcotest = Convert.ToBoolean(dr["ALCOTEST"].ToString())
                            
                            
                            

                        });
                    }
                    dr.Close();
                    Console.WriteLine(asistencias.ToString());
                    return asistencias;

                }
                catch (Exception)
                {
                    asistencias = null;
                    return asistencias;
                    throw;
                }
            }
        }
    }
}
