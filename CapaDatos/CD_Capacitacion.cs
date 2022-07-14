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
    public class CD_Capacitacion
    {
        public static CD_Capacitacion _instancia = null;

        private CD_Capacitacion()
        {

        }

        public static CD_Capacitacion Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new CD_Capacitacion();
                }
                return _instancia;
            }
        }

        public List<Capacitacion> obtenerListadoCapacitaciones()
        {
            List<Capacitacion> capacitacions = new List<Capacitacion>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("[sp_listarCapacitaciones]", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        capacitacions.Add(new Capacitacion()
                        {
                            id_persona = Convert.ToInt32(dr["ID_PERSONA"].ToString()),
                            id_capacitacion = Convert.ToInt32(dr["ID_CAPACITACION"].ToString()),
                            id_tema_capacitacion = Convert.ToInt32(dr["ID_TEMA_CAPACITACION"].ToString()),
                            nombre_tema = dr["NOMBRE_TEMA"].ToString(),
                            fecha = dr["FECHA"].ToString(),
                            hora_inicio = dr["HORA_INICIO"].ToString(),
                            hora_final = dr["HORA_FINAL"].ToString(),
                            nombre = dr["NOMBRE"].ToString(),
                            apellidos = dr["APELLIDOS"].ToString(),
                            dni = Convert.ToInt32(dr["DNI"].ToString())
                        }) ;
                    }
                    dr.Close();
                    return capacitacions;

                }
                catch (Exception)
                {
                    capacitacions = null;
                    return capacitacions;
                    throw;
                }
            }
        }
        public bool eliminarCapacitacion(Capacitacion capacitacion)
        {
            bool respuesta = false;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("[sp_eliminarCapacitacion]", oConexion);
                    cmd.Parameters.AddWithValue("@id_capacitacion", capacitacion.id_capacitacion);
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

        public bool actualizarCapacitacion(Capacitacion capacitacion)
        {
            bool respuesta = false;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("[sp_actualizarCapacitacion]", oConexion);
                    cmd.Parameters.AddWithValue("@id_capacitacion", capacitacion.id_capacitacion);
                    cmd.Parameters.AddWithValue("@id_tema_capacitacion", capacitacion.id_tema_capacitacion);
                    cmd.Parameters.AddWithValue("@fecha", DateTime.Parse(capacitacion.fecha));
                    cmd.Parameters.AddWithValue("@hora_inicio", TimeSpan.Parse(capacitacion.hora_inicio));
                    cmd.Parameters.AddWithValue("@hora_final", TimeSpan.Parse(capacitacion.hora_final));
                    cmd.Parameters.AddWithValue("@id_persona", capacitacion.id_persona);
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

        public bool registrarCapacitacion(Capacitacion capacitacion)
        {
            bool respuesta = false;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("[sp_registrarCapacitacion]", oConexion);
                    cmd.Parameters.AddWithValue("@id_tema_capacitacion", capacitacion.id_tema_capacitacion);
                    cmd.Parameters.AddWithValue("@fecha", DateTime.Parse(capacitacion.fecha));
                    cmd.Parameters.AddWithValue("@hora_inicio", TimeSpan.Parse(capacitacion.hora_inicio));
                    cmd.Parameters.AddWithValue("@hora_final", TimeSpan.Parse(capacitacion.hora_final));
                    cmd.Parameters.AddWithValue("@id_persona", capacitacion.id_persona);
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

        public Persona buscarPersonaPorDNI(int dni)
        {
            Persona persona = null;
            
            


                //sp_retornarPersonaPorDNI

                using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("[sp_retornarPersonaPorDNI]", oConexion);
                    cmd.Parameters.AddWithValue("@dni", dni);
                    cmd.CommandType = CommandType.StoredProcedure;
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        persona = new Persona()
                        {
                            id_persona = Convert.ToInt32(dr["ID_PERSONA"].ToString()),
                            nombre = dr["NOMBRE"].ToString(),
                            apellidos = dr["APELLIDOS"].ToString(),
                            dni = Convert.ToInt32(dr["DNI"].ToString())

                        };
                    }
                    dr.Close();
                    return persona;
                
                }
                catch (Exception)
                {
                    persona = null;
                    return persona;
                    throw;

                }

            }
                

            
            

        }
    }
}
