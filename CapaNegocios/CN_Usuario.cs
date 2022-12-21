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

    }
}
