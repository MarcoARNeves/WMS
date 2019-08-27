using ProjetoWeb.BLL;
using ProjetoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoWeb.Controllers
{
    public class ProdutoController : Controller
    {
        [HttpGet]
        public ActionResult CadastrarProduto()
        {
            ProdutoBLL bll = new ProdutoBLL();
            RetornoProduto retEmp = bll.BuscarTodos();
            if (retEmp.sucesso == true)
            {
                retEmp.sucesso = null;
            }
            return View(retEmp);
        }

        [HttpPost]
        public JsonResult produtoDelete(string id)
        {
            ProdutoBLL bll = new ProdutoBLL();
            return Json(bll.produtoDelete(Convert.ToInt32(id)), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult CadastrarProduto(Produto produto)
        {
            ProdutoBLL bll = new ProdutoBLL();
            return View(bll.Cadastrar(produto));
        }

        [HttpPost]
        public JsonResult produtoUpdate(Produto produto)
        {
            ProdutoBLL bll = new ProdutoBLL();
            return Json(bll.Update(produto), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult produtoGet()
        {
            ProdutoBLL bll = new ProdutoBLL();
            RetornoProduto retEmp = bll.BuscarTodos();
            return Json(retEmp, JsonRequestBehavior.AllowGet);
        }
    }
}