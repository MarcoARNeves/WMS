using EverisAPI.BLL;
using EverisAPI.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace EverisAPI.Controllers
{
    public class ProdutoController : ApiController
    {
        [HttpPost]
        [Route("api/produto/produtoCreate")]
        public IHttpActionResult produtoCreate(Produto produto)
        {
            try
            {

                ProdutoBLL bll = new ProdutoBLL();
                return Ok(bll.createProduto(produto));
            }
            catch (Exception ex)
            {
                UtilBLL util = new UtilBLL();
                return Ok(util.getRetornoException(ex));
            }
        }

        [HttpPost]
        [Route("api/produto/produtoUpdate")]
        public IHttpActionResult produtoUpdate(Produto produto)
        {
            try
            {
                ProdutoBLL bll = new ProdutoBLL();
                return Ok(bll.updateProduto(produto));
            }
            catch (Exception ex)
            {
                UtilBLL util = new UtilBLL();
                return Ok(util.getRetornoException(ex));
            }
        }
        
        [HttpDelete]
        [Route("api/produto/produtoDelete")]
        public IHttpActionResult produtoDelete([FromBody]int id)
        {
            try
            {
                ProdutoBLL bll = new ProdutoBLL();
                return Ok(bll.deleteProduto(id));
            }
            catch (Exception ex)
            {
                UtilBLL util = new UtilBLL();
                return Ok(util.getRetornoException(ex));
            }
        }

        [HttpGet]
        [Route("api/produto/getProdutos")]
        public IHttpActionResult getProdutos()
        {
            try
            {
                ProdutoBLL bll = new ProdutoBLL();
                return Ok(bll.getProdutos());
            }
            catch (Exception ex)
            {
                UtilBLL util = new UtilBLL();
                return Ok(util.getRetornoProdutoException(ex));
            }
        }

        [HttpGet]
        [Route("api/produto/getProdutoByCod")]
        public IHttpActionResult getProdutosByCod(string codProd)
        {
            try
            {
                ProdutoBLL bll = new ProdutoBLL();
                return Ok(bll.getProdutoByCod(codProd));
            }
            catch (Exception ex)
            {
                UtilBLL util = new UtilBLL();
                return Ok(util.getRetornoProdutoException(ex));
            }
        }

        [HttpGet]
        [Route("api/produto/getProdutoByEan")]
        public IHttpActionResult getProdutosByEan(string codProd)
        {
            try
            {
                ProdutoBLL bll = new ProdutoBLL();
                return Ok(bll.getProdutoByEan(codProd));
            }
            catch (Exception ex)
            {
                UtilBLL util = new UtilBLL();
                return Ok(util.getRetornoProdutoException(ex));
            }
        }
    }
}
