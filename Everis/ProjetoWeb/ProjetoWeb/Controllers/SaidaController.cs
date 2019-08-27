using ProjetoWeb.BLL;
using ProjetoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoWeb.Controllers
{
    public class SaidaController : Controller
    {

        public ActionResult Saida()
        {
            SaidaBLL bll = new SaidaBLL();
            return View(bll.BuscarEntradas());
        }

        public JsonResult Cadastrar(Saida saida)
        {
            SaidaBLL bll = new SaidaBLL();
            return Json(bll.Cadastrar(saida), JsonRequestBehavior.AllowGet);
        }
    }
}