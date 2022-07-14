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
    public class CD_TemaCapacitacion
    {
        public static CD_TemaCapacitacion _instancia = null;

        private CD_TemaCapacitacion()
        {

        }

        public static CD_TemaCapacitacion Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new CD_TemaCapacitacion();
                }
                return _instancia;
            }
        }

        public List<TemaCapacitacion> obtenerTemaCapacitacion()
        {
            List<TemaCapacitacion> temaCapacitacions = new List<TemaCapacitacion>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("[sp_listarTemaCapacitacion]", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        temaCapacitacions.Add(new TemaCapacitacion()
                        {
                            id_tema_capacitacion = Convert.ToInt32(dr["ID_TEMA_CAPACITACION"].ToString()),
                            nombre_tema = dr["NOMBRE_TEMA"].ToString()
                        }) ;
                    }
                    dr.Close();
                    return temaCapacitacions;
                }
                catch (Exception)
                {
                    temaCapacitacions = null;
                    return temaCapacitacions;
                    throw;
                }
            }
        }

    }
}
