using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaDatos;

namespace CapaNegocios
{
   public  class CN_Usuario
    {
        private CD_Usuario objUsuario = new CD_Usuario();
        
        public List<Usuario> Listar()
        {
            return objUsuario.Listar();
        }
        public int Registrar(Usuario obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (string.IsNullOrEmpty(obj.Nombres) || string.IsNullOrWhiteSpace(obj.Nombres)){
                Mensaje = "El nombre del usuario no puede ser vacio";

            }
            if (string.IsNullOrEmpty(obj.Apellidos) || string.IsNullOrWhiteSpace(obj.Apellidos))
            {
                Mensaje = "El apellido del usuario no puede ser vacio";

            }
            if (string.IsNullOrEmpty(obj.Correo) || string.IsNullOrWhiteSpace(obj.Correo))
            {
                Mensaje = "El correo del usuario no puede ser vacio";

            }
            if (string.IsNullOrEmpty(Mensaje))
            {
                string clave = "test123";
                obj.Clave = CN_Recursos.ConvertSha256(clave);
                return objUsuario.Registrar(obj, out Mensaje);
            }
            else
            {
                return 0;
            }
            
        }
        public bool Editar(Usuario obj, out string Mensaje)
        {

            Mensaje = string.Empty;
            if (string.IsNullOrEmpty(obj.Nombres) || string.IsNullOrWhiteSpace(obj.Nombres))
            {
                Mensaje = "El nombre del usuario no puede ser vacio";

            }
            if (string.IsNullOrEmpty(obj.Apellidos) || string.IsNullOrWhiteSpace(obj.Apellidos))
            {
                Mensaje = "El apellido del usuario no puede ser vacio";

            }
            if (string.IsNullOrEmpty(obj.Correo) || string.IsNullOrWhiteSpace(obj.Correo))
            {
                Mensaje = "El correo del usuario no puede ser vacio";

            }
            if (string.IsNullOrEmpty(Mensaje))
            {
                
                return objUsuario.Editar(obj, out Mensaje);
            }
            else
            {
                return false;
            }
        }
        public bool Eliminar(int id, out string Mensaje)
        {
            return objUsuario.Eliminar(id, out Mensaje);
        }
    }
}
