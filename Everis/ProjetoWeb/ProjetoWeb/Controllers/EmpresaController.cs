using ProjetoWeb.BLL;
using ProjetoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoWeb.Controllers
{
    public class EmpresaController : Controller
    {
        [HttpGet]
        public ActionResult CadastrarEmpresa()
        {
            EmpresaBLL bll = new EmpresaBLL();
            RetornoEmpresa retEmp = bll.BuscarTodos();
            if (retEmp.sucesso == true)
            {
                retEmp.sucesso = null;
            }
            return View(retEmp);
        }

        [HttpPost]
        public JsonResult empresaDelete(string id)
        {
            EmpresaBLL bll = new EmpresaBLL();
            return Json(bll.empresaDelete(Convert.ToInt32(id)), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult empresaCreate(Empresa empresa)
        {
            EmpresaBLL bll = new EmpresaBLL();
            return Json(bll.Cadastrar(empresa), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult empresaUpdate(Empresa empresa)
        {
            EmpresaBLL bll = new EmpresaBLL();
            return Json(bll.Update(empresa), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult empresaGet()
        {
            EmpresaBLL bll = new EmpresaBLL();
            return Json(bll.BuscarTodos(), JsonRequestBehavior.AllowGet);
        }
    }
}