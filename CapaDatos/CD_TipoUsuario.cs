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
    public class CD_TipoUsuario
    {
        public static CD_TipoUsuario _instancia = null;

        private CD_TipoUsuario()
        {

        }
        public static CD_TipoUsuario Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new CD_TipoUsuario();
                }
                return _instancia;
            }
        }

        public List<TipoUsuario> obtenerTipoUsuarios()
        {
            List<TipoUsuario> tipoUsuarios = new List<TipoUsuario>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("[sp_ListarTipoUsuario]", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        tipoUsuarios.Add(new TipoUsuario()
                        {
                            id_tipo_usuario = Convert.ToInt32(dr["ID_TIPO_USUARIO"].ToString()),
                            nombre_tipo_usuario = dr["NOMBRE_TIPO_USUARIO"].ToString(),
                            descripcion_tipo_usuario = dr["DESCRIPCION_TIPO_USUARIO"].ToString()
                        }) ;

                    }
                    dr.Close();
                    return tipoUsuarios;
                }
                catch (Exception)
                {
                    tipoUsuarios = null;
                    return tipoUsuarios;
                    throw;
                }
            }
        }
    }
}
