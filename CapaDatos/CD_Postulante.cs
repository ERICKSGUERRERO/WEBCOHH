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
    public class CD_Postulante
    {
        public static CD_Postulante _instancia = null;

        private CD_Postulante()
        {

        }
        public static CD_Postulante Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new CD_Postulante();
                }
                return _instancia;
            }
        }

        public List<Postulante> obtenerPostulantesConvocatoria(int idConvocatoria)
        {
            List<Postulante> rptListaPostulantesConvocatoria = new List<Postulante>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                //sp_ObtenerPostulantesConvocatoria
                SqlCommand cmd = new SqlCommand("[sp_ObtenerPostulantesConvocatoria]", oConexion);
                cmd.Parameters.AddWithValue("@idConvocatoria", idConvocatoria);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        rptListaPostulantesConvocatoria.Add(new Postulante()
                        {
                            ID_POSTULANTE = Convert.ToInt32(dr["ID_POSTULANTE"].ToString()),
                            NOMBRE = dr["NOMBRE"].ToString(),
                            APELLIDOS = dr["APELLIDOS"].ToString(),
                            GENERO = Convert.ToChar(dr["GENERO"].ToString()),
                            DNI = Convert.ToInt32(dr["DNI"].ToString()),
                            NOMBRE_DIRECCION = dr["NOMBRE_DIRECCION"].ToString(),
                            NUMERO = Convert.ToInt32(dr["NUMERO"].ToString())

                        }) ;
                    }
                    dr.Close();
                    return rptListaPostulantesConvocatoria;

                }
                catch (Exception)
                {
                    rptListaPostulantesConvocatoria = null;
                    return rptListaPostulantesConvocatoria;
                    throw;
                }
            }
        }

        public bool registrarPostulante(Postulante postulante)
        {

            bool respuesta = true;
            using (SqlConnection conexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("[sp_registrarPostulante]", conexion);
                    cmd.Parameters.AddWithValue("@id_convocatoria", postulante.ID_CONVOCATORIA);
                    cmd.Parameters.AddWithValue("@nombre", postulante.NOMBRE);
                    cmd.Parameters.AddWithValue("@apellidos", postulante.APELLIDOS);
                    cmd.Parameters.AddWithValue("@fecha_nacimiento", postulante.FECHA_NACIMIENTO);
                    cmd.Parameters.AddWithValue("@genero", postulante.GENERO);
                    cmd.Parameters.AddWithValue("@dni", postulante.DNI);
                    cmd.Parameters.AddWithValue("@numero", postulante.NUMERO);
                    cmd.Parameters.AddWithValue("@direccion", postulante.NOMBRE_DIRECCION);
                    cmd.Parameters.AddWithValue("@estado_postulante", 1);
                    cmd.CommandType = CommandType.StoredProcedure;
                    conexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = true;
                }
                catch (Exception ex)
                {
                    respuesta = false;
                }
            }

            return respuesta;
        }

        public bool registrarPostulanteTrabajador(Contrato contrato)
        {
            bool respuesta = true;
            using (SqlConnection conexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("[sp_RegistrarTrabajadorPostulante]", conexion);
                    cmd.Parameters.AddWithValue("@id_postulante", contrato.ID_POSTULANTE);
                    cmd.Parameters.AddWithValue("@id_area", contrato.ID_AREA);
                    cmd.Parameters.AddWithValue("@id_puestoTrabajo", contrato.ID_PUESTO_TRABAJO);
                    cmd.Parameters.AddWithValue("@fecha_inicio", DateTime.Now);
                    cmd.Parameters.AddWithValue("@fecha_final", contrato.FECHA_FINAL);
                    cmd.Parameters.AddWithValue("@id_horario", contrato.ID_HORARIO);
                    cmd.Parameters.AddWithValue("@id_regimen", contrato.ID_REGIMEN);
                    cmd.Parameters.AddWithValue("@sueldo", contrato.SUELDO);
                    cmd.Parameters.AddWithValue("@estado_contrato", 1);
                    cmd.CommandType = CommandType.StoredProcedure;
                    conexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = true;
                }
                catch (Exception)
                {
                    respuesta = false;

                }
            }
            return respuesta;
        }



    }
}
