using ProjetoWeb.BLL;
using ProjetoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoWeb.Controllers
{
    public class EstoqueController : Controller
    {
        public ActionResult Index()
        {
            EstoqueBLL bll = new EstoqueBLL();
            return View(bll.BuscarEstoque());
        }

        public JsonResult getEmpresaContemEstoque()
        {
            EstoqueBLL bll = new EstoqueBLL();
            return Json(bll.getEmpresaContemEstoque(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult getProdutoByEmpresaContemEstoque(int idEmpresa)
        {
            EstoqueBLL bll = new EstoqueBLL();
            return Json(bll.getProdutoByEmpresaContemEstoque(idEmpresa), JsonRequestBehavior.AllowGet);
        }

        public JsonResult getProdutoContemEstoque()
        {
            EstoqueBLL bll = new EstoqueBLL();
            return Json(bll.getProdutoContemEstoque(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult getEstoqueByProduto(int idProduto)
        {
            EstoqueBLL bll = new EstoqueBLL();
            return Json(bll.getEstoqueByProduto(idProduto), JsonRequestBehavior.AllowGet);
        }

        public JsonResult getEstoqueByEmpresa(int idEmpresa)
        {
            EstoqueBLL bll = new EstoqueBLL();
            return Json(bll.getEstoqueByEmpresa(idEmpresa), JsonRequestBehavior.AllowGet);
        }

    }
}