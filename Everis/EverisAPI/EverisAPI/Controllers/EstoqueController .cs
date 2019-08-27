using EverisAPI.BLL;
using EverisAPI.Models;
using System;
using System.Web.Http;

namespace EverisAPI.Controllers
{
    public class EstoqueController : ApiController
    {
        [HttpGet]
        [Route("api/estoque/getEstoques")]
        public IHttpActionResult getEstoque()
        {
            try
            {
                EstoqueBLL bll = new EstoqueBLL();
                return Ok(bll.getEstoque());
            }catch (Exception ex)
            {
                UtilBLL util = new UtilBLL();
                return Ok(util.getRetornoEstoqueException(ex));
            }
        }

        [HttpGet]
        [Route("api/estoque/getEmpresaContemEstoque")]
        public IHttpActionResult getEmpresaContemEstoque()
        {
            try
            {
                EstoqueBLL bll = new EstoqueBLL();
                return Ok(bll.getEmpresaContemEstoque());
            }
            catch (Exception ex)
            {
                UtilBLL util = new UtilBLL();
                return Ok(util.getRetornoEmpresaException(ex));
            }
        }

        [HttpPost]
        [Route("api/estoque/getProdutoByEmpresaContemEstoque")]
        public IHttpActionResult getProdutoByEmpresaContemEstoque([FromBody] int idEmpresa)
        {
            try
            {
                EstoqueBLL bll = new EstoqueBLL();
                return Ok(bll.getProdutoByIdEmpresaEstoque(idEmpresa));
            }
            catch (Exception ex)
            {
                UtilBLL util = new UtilBLL();
                return Ok(util.getRetornoProdutoException(ex));
            }
        }

        [HttpGet]
        [Route("api/estoque/getProdutoContemEstoque")]
        public IHttpActionResult getProdutoContemEstoque()
        {
            try
            {
                EstoqueBLL bll = new EstoqueBLL();
                return Ok(bll.getProdutoContemEstoque());
            }
            catch (Exception ex)
            {
                UtilBLL util = new UtilBLL();
                return Ok(util.getRetornoProdutoException(ex));
            }
        }

        [HttpPost]
        [Route("api/estoque/getEstoqueByEmpresa")]
        public IHttpActionResult getEstoqueByEmpresa([FromBody]int idEmpresa)
        {
            try
            {
                EstoqueBLL bll = new EstoqueBLL();
                return Ok(bll.getEstoqueByEmpresa(idEmpresa));
            }
            catch (Exception ex)
            {
                UtilBLL util = new UtilBLL();
                return Ok(util.getRetornoEstoqueException(ex));
            }
        }

        [HttpPost]
        [Route("api/estoque/getEstoqueByProduto")]
        public IHttpActionResult getEstoqueByProduto([FromBody]int idProduto)
        {
            try
            {
                EstoqueBLL bll = new EstoqueBLL();
                return Ok(bll.getEstoqueByProduto(idProduto));
            }
            catch (Exception ex)
            {
                UtilBLL util = new UtilBLL();
                return Ok(util.getRetornoEstoqueException(ex));
            }
        }
    }
}
