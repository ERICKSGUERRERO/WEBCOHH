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
    public class CD_Trabajador
    {
        public static CD_Trabajador _instancia = null;

        private CD_Trabajador()
        {

        }

        public static CD_Trabajador Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new CD_Trabajador();
                }
                return _instancia;
            }
        }

        public List<Trabajador> obtenerTrabajadores()
        {
            List<Trabajador> trabajadors = new List<Trabajador>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("[sp_mostrarTrabajadores]", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        trabajadors.Add(new Trabajador()
                        {
                            id_trabajador = Convert.ToInt32(dr["ID_TRABAJADOR"].ToString()),
                            dni = Convert.ToInt32(dr["DNI"].ToString())
                        });
                    }
                    dr.Close();
                    return trabajadors;

                }
                catch(Exception ex)
                {
                    trabajadors = null;
                    return trabajadors;
                    throw;
                }
            }
        }

    }
}
