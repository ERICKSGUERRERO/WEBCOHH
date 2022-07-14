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
    public class CD_PuestoTrabajo
    {
        public static CD_PuestoTrabajo _instancia = null;
        private CD_PuestoTrabajo()
        {

        }
        public static CD_PuestoTrabajo Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new CD_PuestoTrabajo();
                }
                return _instancia;
            }
        }

        public List<PuestoTrabajo> obtenerPuestoTrabajo()
        {
            List<PuestoTrabajo> listPuestoTrabajo = new List<PuestoTrabajo>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("[sp_listarPuestoTrabajo]", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        listPuestoTrabajo.Add(new PuestoTrabajo()
                        {
                            ID_PUESTO_TRABAJO = Convert.ToInt32(dr["ID_PUESTO_TRABAJO"].ToString()),
                            NOMBRE_PUESTO_TRABAJO = dr["NOMBRE_PUESTO_TRABAJO"].ToString()
                        });
                    }
                    dr.Close();
                    return listPuestoTrabajo;

                }
                catch (Exception)
                {
                    listPuestoTrabajo = null;
                    return listPuestoTrabajo;
                    throw;

                }
            }
        }


    }
}
