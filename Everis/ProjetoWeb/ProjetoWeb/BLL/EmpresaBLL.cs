using Newtonsoft.Json;
using ProjetoWeb.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ProjetoWeb.BLL
{
    public class EmpresaBLL
    {
        public Retorno Cadastrar(Empresa empresa)
        {
            Retorno retorno = new Retorno();
            retorno.sucesso = false;

            UtilBLL util = new UtilBLL();
            string metodo = util.getConfig("empresaCreate");
            RetornoString rs = util.realizaRequisicaoComPmt(empresa, metodo, TipoRequisicao.POST);
            if (rs.sucesso.Equals(true))
            {
                retorno = JsonConvert.DeserializeObject<Retorno>(rs.resposta);
            }
            RetornoEmpresa retEmp = BuscarTodos();
            if (retorno.sucesso.Equals(false))
            {
                retEmp.sucesso = false;
                retEmp.erro = retorno.erro;
            }
            return retEmp;
        }

        public Retorno Update(Empresa empresa)
        {
            Retorno retorno = new Retorno();
            retorno.sucesso = false;

            UtilBLL util = new UtilBLL();
            string metodo = util.getConfig("empresaUpdate");
            RetornoString rs = util.realizaRequisicaoComPmt(empresa, metodo, TipoRequisicao.POST);
            if (rs.sucesso.Equals(true))
            {
                retorno = JsonConvert.DeserializeObject<Retorno>(rs.resposta);
            }
            RetornoEmpresa retEmp = BuscarTodos();
            if (retorno.sucesso.Equals(false))
            {
                retEmp.sucesso = false;
                retEmp.erro = retorno.erro;
            }
            return retEmp;
        }

        public RetornoEmpresa BuscarTodos()
        {
            RetornoEmpresa retorno = new RetornoEmpresa();
            retorno.sucesso = false;

            UtilBLL util = new UtilBLL();
            string metodo = util.getConfig("getTodasEmpresas");
            RetornoString rs = util.realizaRequisicaoSemPmt(metodo, TipoRequisicao.GET);
            if (rs.sucesso.Equals(true))
            {
                retorno = JsonConvert.DeserializeObject<RetornoEmpresa>(rs.resposta);
            }
            else
            {
                retorno.sucesso = false;
                retorno.erro = "Não foi possível estabelecer uma conexão com o banco de dados";
                retorno.listEmpresas = new List<Empresa>();
            }
            return retorno;
        }

        public Retorno empresaDelete(int id)
        {
            Retorno ret = new Retorno();
            try
            {
                UtilBLL util = new UtilBLL();
                string metodo = util.getConfig("empresaDelete");
                RetornoString rs = util.realizaRequisicaoComPmt(id, metodo, TipoRequisicao.DELETE);
                ret = JsonConvert.DeserializeObject<Retorno>(rs.resposta);
                return ret;
            }
            catch (Exception ex)
            {
                ret.erro = ex.Message;
                ret.sucesso = false;
                return ret;
            }
        }
    }
}