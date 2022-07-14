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
    public class CD_Horario
    {
        public static CD_Horario _instancia = null;

        private CD_Horario()
        {

        }

        public static CD_Horario Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new CD_Horario();
                }
                return _instancia;
            }
        }

        public List<Horario> obtenerHorario()
        {
            List<Horario> listaHorario = new List<Horario>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("[sp_listarHorario]", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        listaHorario.Add(new Horario()
                        {
                            ID_HORARIO = Convert.ToInt32(dr["ID_HORARIO"].ToString()),
                            HORARIO = dr["HORARIO"].ToString()

                        });
                    }
                    dr.Close();
                    return listaHorario;
                }
                catch (Exception)
                {
                    listaHorario = null;
                    return listaHorario;
                    throw;
                }

            }
        }
    }
}
