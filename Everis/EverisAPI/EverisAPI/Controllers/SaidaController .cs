using EverisAPI.BLL;
using EverisAPI.Models;
using System;
using System.Web.Http;

namespace EverisAPI.Controllers
{
    public class SaidaController : ApiController
    {
        [HttpPost]
        [Route("api/saida/insereSaida")]
        public IHttpActionResult insereSaida(Saida saida)
        {
            try
            {
                SaidaBLL bll = new SaidaBLL();
                return Ok(bll.insereSaida(saida));
            }catch (Exception ex)
            {
                UtilBLL util = new UtilBLL();
                return Ok(util.getRetornoException(ex));
            }
        }

        [HttpGet]
        [Route("api/saida/buscaSaidaPorIdProd")]
        public IHttpActionResult buscaSaidaPorIdProd(int idProd)
        {
            try
            {
                SaidaBLL bll = new SaidaBLL();
                return Ok(bll.getSaidaByProduto(idProd));
            }
            catch (Exception ex)
            {
                UtilBLL util = new UtilBLL();
                return Ok(util.getRetornoSaidaException(ex));
            }
        }

        [HttpGet]
        [Route("api/saida/buscaTodasSaidas")]
        public IHttpActionResult buscaTodasSaidas()
        {
            try
            {
                SaidaBLL bll = new SaidaBLL();
                return Ok(bll.getTodasSaidas());
            }
            catch (Exception ex)
            {
                UtilBLL util = new UtilBLL();
                return Ok(util.getRetornoSaidaException(ex));
            }
        }

        [HttpGet]
        [Route("api/saida/buscaSaidaPorIdEmpresa")]
        public IHttpActionResult buscaSaidaPorIdEmpresa(int idEmpresa)
        {
            try
            {
                SaidaBLL bll = new SaidaBLL();
                return Ok(bll.getSaidaByEmpresa(idEmpresa));
            }
            catch (Exception ex)
            {
                UtilBLL util = new UtilBLL();
                return Ok(util.getRetornoSaidaException(ex));
            }
        }
    }
}
