using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaDatos;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
   public class CD_Usuario
    {
        public List<Usuario> Listar()
        {
            List<Usuario> lista = new List<Usuario>();
            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cn))
                {
                    string query = "SELECT IdUsuario,Nombres,Apellidos,Correo,Clave,Activo FROM USUARIO";
                    SqlCommand cmd = new SqlCommand(query, conexion);
                    cmd.CommandType = CommandType.Text;
                    conexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(
                                new Usuario
                                {
                                    IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                                    Nombres = dr["Nombres"].ToString(),
                                    Apellidos = dr["Apellidos"].ToString(),
                                    Correo = dr["Correo"].ToString(),
                                    Clave = dr["Clave"].ToString(),
                                    Activo = Convert.ToBoolean(dr["Activo"])


                                }


                                ) ;
                        }

                    }

                    return lista;


                }

            }
            catch (Exception)
            {
                return lista = new List<Usuario>();
                
            }
           


              


        }

        public int Registrar (Usuario obj, out string Mensaje)
        { int idGenerado = 0;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection())
                {
                    SqlCommand cmd = new SqlCommand("sp_RegistrarUsuario", oconexion);
                    cmd.Parameters.AddWithValue("Nombres", obj.Nombres);
                    cmd.Parameters.AddWithValue("Apellidos", obj.Apellidos);
                    cmd.Parameters.AddWithValue("Correo", obj.Correo);
                    cmd.Parameters.AddWithValue("Clave", obj.Clave);
                    cmd.Parameters.AddWithValue("Activo", obj.Activo);
                    cmd.Parameters.AddWithValue("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    oconexion.Open();
                    cmd.ExecuteNonQuery();
                    idGenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                idGenerado = 0;
                Mensaje = string.Empty;
            }

            return idGenerado;
        }
        public bool Editar(Usuario obj, out string Mensaje)
        {
            bool Resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection())
                {
                    SqlCommand cmd = new SqlCommand("sp_RegistrarUsuario", oconexion);
                    cmd.Parameters.AddWithValue("Nombres", obj.Nombres);
                    cmd.Parameters.AddWithValue("Apellidos", obj.Apellidos);
                    cmd.Parameters.AddWithValue("Correo", obj.Correo);
                    cmd.Parameters.AddWithValue("Clave", obj.Clave);
                    cmd.Parameters.AddWithValue("Activo", obj.Activo);
                    cmd.Parameters.AddWithValue("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    oconexion.Open();
                    cmd.ExecuteNonQuery();
                    Resultado = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                Resultado = false;
                Mensaje = string.Empty;
            }

            return Resultado ;
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            bool result = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion=new SqlConnection())
                {
                    SqlCommand cmd = new SqlCommand("delete top(1) from usuario where IdUsuario=@id", oconexion);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();
                    result = cmd.ExecuteNonQuery() > 0 ? true : false;
                    
                }
            }catch(Exception ex)
            {
                result = false;
                Mensaje = ex.Message;
            }
            return result;
        }

    }
}
