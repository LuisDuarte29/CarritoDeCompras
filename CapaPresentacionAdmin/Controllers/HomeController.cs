using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaNegocios;
using CapaEntidad;

namespace CapaPresentacionAdmin.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Usuario()
        {
            return View();
        }
        [HttpGet]
        public JsonResult Listar() {

        List<Usuario> listaUsuarios = new List<Usuario>();

            listaUsuarios = new CN_Usuario().Listar();
            return Json(new { data=listaUsuarios }, JsonRequestBehavior.AllowGet);
            Console.WriteLine("este es la rama master");
            Console.WriteLine("Este es la rama lucia");
        }
        [HttpPost]
        public JsonResult GuardarUsuario(Usuario usuarios)
        {
            object resultado;
            string mensaje = "";
            if (usuarios.IdUsuario == 0)
            {
                resultado = new CN_Usuario().Registrar(usuarios, out mensaje);
            }else
            {
                resultado = new CN_Usuario().Editar(usuarios, out mensaje);
            }
            return Json(new { resultado=resultado,mensaje=mensaje },JsonRequestBehavior.AllowGet) ;
        }
    }
}