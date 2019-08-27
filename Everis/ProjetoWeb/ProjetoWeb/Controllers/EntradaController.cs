using ProjetoWeb.BLL;
using ProjetoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoWeb.Controllers
{
    public class EntradaController : Controller
    {

        public ActionResult Entrada()
        {
            EntradaBLL bll = new EntradaBLL();
            return View(bll.BuscarEntradas());
        }

        public JsonResult Cadastrar(Entrada entrada)
        {
            EntradaBLL bll = new EntradaBLL();
            return Json(bll.Cadastrar(entrada), JsonRequestBehavior.AllowGet);
        }
    }
}