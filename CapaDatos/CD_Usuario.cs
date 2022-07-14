using System;
using System.Collections.Generic;
using CapaEntidad;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class CD_Usuario
    {
        public static CD_Usuario _instancia = null;

        private CD_Usuario()
        {

        }

        public static CD_Usuario Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new CD_Usuario();
                }
                return _instancia;
            }
        }
        public int LoginUsuario(string Usu, string pass)
        {
            int respuesta = 0;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("[sp_logearse]", oConexion);
                    cmd.Parameters.AddWithValue("@NOMBRE_USUARIO", Usu);
                    cmd.Parameters.AddWithValue("@PASSWORD_USUARIO", pass);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToInt32(cmd.Parameters["ID_USUARIO"].Value);


                }
                catch (Exception ex)
                {
                    respuesta = 0;
                }
            }

            return respuesta;

        }
        public bool eliminarUsuario(Usuario usuario)
        {
            bool respuesta = false;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("[sp_eliminarUsuario]", oConexion);
                    cmd.Parameters.AddWithValue("@id_usuario", usuario.id_usuario);
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


        public bool actualizarUsuario(Usuario usuario)
        {
            bool respuesta = false;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("[sp_actualizarUsuario]", oConexion);
                    cmd.Parameters.AddWithValue("@id_usuario", usuario.id_usuario);
                    cmd.Parameters.AddWithValue("@nombre_usuario", usuario.usuario);
                    cmd.Parameters.AddWithValue("@descripcion_usuario", usuario.descripcion);
                    cmd.Parameters.AddWithValue("@id_trabajador", usuario.id_trabajador);
                    cmd.Parameters.AddWithValue("@password_usuario", usuario.contrasenia);
                    cmd.Parameters.AddWithValue("@estado_usuario", usuario.estado);
                    cmd.Parameters.AddWithValue("@id_tipo_usuario", usuario.id_tipo_usuario);
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

        public bool registrarUsuario(Usuario usuario)
        {
            bool respuesta = false;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("[sp_registrarUsuario]", oConexion);
                    cmd.Parameters.AddWithValue("@nombre_usuario", usuario.usuario);
                    cmd.Parameters.AddWithValue("@descripcion_usuario", usuario.descripcion);
                    cmd.Parameters.AddWithValue("@id_trabajador", usuario.id_trabajador);
                    cmd.Parameters.AddWithValue("@password_usuario", usuario.contrasenia);
                    cmd.Parameters.AddWithValue("@estado_usuario", usuario.estado);
                    cmd.Parameters.AddWithValue("@id_tipo_usuario", usuario.id_tipo_usuario);
                    cmd.CommandType = CommandType.StoredProcedure;
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    respuesta=true;

                }
                catch (Exception)
                {
                    respuesta = false;
                    throw;
                }
            }
            return respuesta;
        }

        public List<Usuario> listadoUsuariosTrabajadores()
        {
            List<Usuario> lista = new List<Usuario>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("[sp_listadoTrabajadoresUsuarios]", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        lista.Add(new Usuario()
                        {
                            dni = Convert.ToInt32(dr["DNI"].ToString()),
                            id_trabajador = Convert.ToInt32(dr["ID_TRABAJADOR"].ToString()),
                            nombre = dr["NOMBRE"].ToString(),
                            apellidos = dr["APELLIDOS"].ToString(),
                            usuario = dr["USUARIO"].ToString(),
                            contrasenia = dr["CONTRASEÑA"].ToString(),
                            tipo_usuario = dr["TIPO_USUARIO"].ToString(),
                            descripcion = dr["DESCRIPCION"].ToString(),
                            estado = Convert.ToBoolean(dr["ESTADO"].ToString()),
                            id_usuario = Convert.ToInt32(dr["ID_USUARIO"].ToString()),
                            id_tipo_usuario = Convert.ToInt32(dr["ID_TIPO_USUARIO"].ToString())

                        }) ;
                    }
                    dr.Close();
                    return lista;

                }
                catch (Exception)
                {
                    lista = null;
                    return lista;
                    throw;
                }

            }
        }


        public List<Usuario> obtenerUsuarios()
        {
            List<Usuario> rptListaUsuario = new List<Usuario>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                //[sp_listadoTrabajadoresUsuarios]
                SqlCommand cmd = new SqlCommand("[sp_listadoTrabajadoresUsuarios]", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();


                    while (dr.Read())
                    {
                        rptListaUsuario.Add(new Usuario()
                        {
                            id_usuario = Convert.ToInt32(dr["ID_USUARIO"].ToString()),
                            dni = Convert.ToInt32(dr["DNI"].ToString()),
                            id_trabajador = Convert.ToInt32(dr["ID_TRABAJADOR"].ToString()),
                            nombre = dr["NOMBRE"].ToString(),
                            apellidos = dr["APELLIDOS"].ToString(),
                            usuario = dr["USUARIO"].ToString(),
                            contrasenia = dr["CONTRASEÑA"].ToString(),
                            tipo_usuario = dr["TIPO_USUARIO"].ToString(),
                            descripcion = dr["DESCRIPCION"].ToString()

                        });

                    }
                    dr.Close();
                    return rptListaUsuario;



                }
                catch (Exception)
                {
                    rptListaUsuario = null;
                    return rptListaUsuario;
                    throw;
                }

            }

        }
    }
}
