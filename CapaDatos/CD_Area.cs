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
    public class CD_Area
    {
        public static CD_Area _instancia = null;

        private CD_Area()
        {

        }

        public static CD_Area Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new CD_Area();
                }
                return _instancia;
            }
        }

        public List<Area> obtenerAreas()
        {
            List<Area> areas = new List<Area>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("[sp_listarArea]", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        areas.Add(new Area()
                        {
                            ID_AREA = Convert.ToInt32(dr["ID_AREA"].ToString()),
                            NOMBRE_AREA = dr["NOMBRE_AREA"].ToString()

                        });
                    }
                    dr.Close();
                    return areas;
                }
                catch (Exception)
                {
                    areas = null;
                    return areas;
                    throw;

                }

            }
        }

    }
}
