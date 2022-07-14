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
    public class CD_Regimen
    {
        public static CD_Regimen _instancia = null;

        private CD_Regimen()
        {

        }

        public static CD_Regimen Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new CD_Regimen();
                }
                return _instancia;
            }
        }
        public List<Regimen> obtenerRegimenes()
        {
            List<Regimen> listRegimen = new List<Regimen>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("[sp_listarRegimen]", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        listRegimen.Add(new Regimen()
                        {
                            ID_REGIMEN = Convert.ToInt32(dr["ID_REGIMEN"].ToString()),
                            NOMBRE_REGIMEN = dr["NOMBRE_REGIMEN"].ToString()


                        });
                    }
                    dr.Close();
                    return listRegimen;


                }
                catch (Exception)
                {
                    listRegimen = null;
                    return listRegimen;
                    throw;

                }
            }
        }


    }
}
