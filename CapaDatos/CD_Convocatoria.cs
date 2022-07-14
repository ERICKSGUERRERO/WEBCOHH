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
    public class CD_Convocatoria
    {
        public static CD_Convocatoria _instancia = null;

        private CD_Convocatoria()
        {

        }
        public static CD_Convocatoria Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new CD_Convocatoria();
                }
                return _instancia;
            }
        }

        public List<Convocatoria> obtenerConvocatorias()
        {
            List<Convocatoria> conocatorias = new List<Convocatoria>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("[sp_listarConvocatoria]", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        conocatorias.Add(new Convocatoria()
                        {
                            id_convocatoria = Convert.ToInt32(dr["ID_CONVOCATORIA"].ToString()),
                            descripcion = dr["DESCRIPCION"].ToString()
                        });

                    }
                    dr.Close();
                    return conocatorias;

                }
                catch (Exception)
                {
                    conocatorias = null;
                    return conocatorias;
                    throw;
                }

            }
        }
    }
}
