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
        public JsonResult Listar() {

        List<Usuario> listaUsuarios = new List<Usuario>();

            listaUsuarios = new CN_Usuario().Listar();
            return Json(listaUsuarios, JsonRequestBehavior.AllowGet);
        }
    }
}