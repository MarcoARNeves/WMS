using EverisAPI.BLL;
using EverisAPI.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace EverisAPI.Controllers
{
    public class EmpresaController : ApiController
    {
        [HttpPost]
        [Route("api/empresa/empresaCreate")]
        public IHttpActionResult empresaCreate(Empresa empresa)
        {
            try
            {
                EmpresaBLL bll = new EmpresaBLL();
                return Ok(bll.createEmpresa(empresa));
            }catch (Exception ex)
            {
                UtilBLL util = new UtilBLL();
                return Ok(util.getRetornoException(ex));
            }
        }

        [HttpDelete]
        [Route("api/empresa/empresaDelete")]
        public IHttpActionResult empresaDelete([FromBody]int id)
        {
            try
            {
                EmpresaBLL bll = new EmpresaBLL();
                return Ok(bll.deleteEmpresa(Convert.ToInt32(id)));
            }
            catch (Exception ex)
            {
                UtilBLL util = new UtilBLL();
                return Ok(util.getRetornoException(ex));
            }
        }

        [HttpPost]
        [Route("api/empresa/empresaUpdate")]
        public IHttpActionResult empresaUpdate(Empresa empresa)
        {
            try
            {
                EmpresaBLL bll = new EmpresaBLL();
                return Ok(bll.updateEmpresa(empresa));
            }
            catch (Exception ex)
            {
                UtilBLL util = new UtilBLL();
                return Ok(util.getRetornoException(ex));
            }
        }

        [HttpGet]
        [Route("api/empresa/getEmpresaByName")]
        public IHttpActionResult getEmpresaByName(string nome)
        {
            try
            {
                EmpresaBLL bll = new EmpresaBLL();
                return Ok(bll.getEmpresaByName(nome));
            }catch(Exception ex)
            {
                UtilBLL util = new UtilBLL();
                return Ok(util.getRetornoEmpresaException(ex));
            }
        }

        [HttpGet]
        [Route("api/empresa/getEmpresas")]
        public IHttpActionResult getEmpresas()
        {
            try
            {
                EmpresaBLL bll = new EmpresaBLL();
                return Ok(bll.GetEmpresas());
            }
            catch (Exception ex)
            {
                UtilBLL util = new UtilBLL();
                return Ok(util.getRetornoEmpresaException(ex));
            }
        }
    }
}
