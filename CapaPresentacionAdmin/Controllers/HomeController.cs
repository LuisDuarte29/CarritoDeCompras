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
        }
    }
}