using EverisAPI.BLL;
using EverisAPI.Models;
using System;
using System.Web.Http;

namespace EverisAPI.Controllers
{
    public class EntradaController : ApiController
    {
        [HttpPost]
        [Route("api/entrada/insereEntrada")]
        public IHttpActionResult insereEntrada(Entrada entrada)
        {
            try
            {
                EntradaBLL bll = new EntradaBLL();
                return Ok(bll.insereEntrada(entrada));

            }catch (Exception ex)
            {
                UtilBLL util = new UtilBLL();
                return Ok(util.getRetornoException(ex));
            }
        }

        [HttpPost]
        [Route("api/entrada/buscaEntradaPorIdProd")]
        public IHttpActionResult buscaEntradaPorIdProd(int idProd)
        {
            try
            {
                EntradaBLL bll = new EntradaBLL();
                return Ok(bll.getEntradaByProduto(idProd));
            }
            catch (Exception ex)
            {
                UtilBLL util = new UtilBLL();
                return Ok(util.getRetornoEntradaException(ex));
            }
        }

        [HttpGet]
        [Route("api/entrada/buscaTodasEntradas")]
        public IHttpActionResult buscaTodasEntradas()
        {
            try
            {
                EntradaBLL bll = new EntradaBLL();
                return Ok(bll.getTodasEntradas());
            }
            catch (Exception ex)
            {
                UtilBLL util = new UtilBLL();
                return Ok(util.getRetornoEntradaException(ex));
            }
        }

        [HttpPost]
        [Route("api/entrada/buscaEntradaPorIdEmpresa")]
        public IHttpActionResult buscaEntradaPorIdEmpresa(int idEmpresa)
        {
            try
            {
                EntradaBLL bll = new EntradaBLL();
                return Ok(bll.getEntradaByEmpresa(idEmpresa));
            }
            catch (Exception ex)
            {
                UtilBLL util = new UtilBLL();
                return Ok(util.getRetornoEntradaException(ex));
            }
        }
    }
}
