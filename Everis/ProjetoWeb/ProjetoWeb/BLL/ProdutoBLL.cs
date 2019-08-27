using Newtonsoft.Json;
using ProjetoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoWeb.BLL
{
    public class ProdutoBLL
    {
        public Retorno Cadastrar(Produto produto)
        {
            Retorno retorno = new Retorno();
            retorno.sucesso = false;

            UtilBLL util = new UtilBLL();
            string metodo = util.getConfig("produtoCreate");
            RetornoString rs = util.realizaRequisicaoComPmt(produto, metodo, TipoRequisicao.POST);
            if (rs.sucesso.Equals(true))
            {
                retorno = JsonConvert.DeserializeObject<Retorno>(rs.resposta);
            }
            RetornoProduto retEmp = BuscarTodos();
            if (retorno.sucesso.Equals(false))
            {
                retEmp.sucesso = false;
                retEmp.erro = retorno.erro;
            }
            return retEmp;
        }

        public Retorno Update(Produto produto)
        {
            Retorno retorno = new Retorno();
            retorno.sucesso = false;

            UtilBLL util = new UtilBLL();
            string metodo = util.getConfig("produtoUpdate");
            RetornoString rs = util.realizaRequisicaoComPmt(produto, metodo, TipoRequisicao.POST);
            if (rs.sucesso.Equals(true))
            {
                retorno = JsonConvert.DeserializeObject<Retorno>(rs.resposta);
            }
            RetornoProduto retEmp = BuscarTodos();
            if (retorno.sucesso.Equals(false))
            {
                retEmp.sucesso = false;
                retEmp.erro = retorno.erro;
            }
            return retEmp;
        }

        public RetornoProduto BuscarTodos()
        {
            RetornoProduto retorno = new RetornoProduto();
            retorno.sucesso = false;

            UtilBLL util = new UtilBLL();
            string metodo = util.getConfig("getTodosProdutos");
            RetornoString rs = util.realizaRequisicaoSemPmt(metodo, TipoRequisicao.GET);
            if (rs.sucesso.Equals(true))
            {
                retorno = JsonConvert.DeserializeObject<RetornoProduto>(rs.resposta);
            }
            else
            {
                retorno.sucesso = false;
                retorno.erro = "Não foi possível estabelecer uma conexão com o banco de dados";
                retorno.listProdutos = new List<Produto>();
            }
            return retorno;
        }

        public Retorno produtoDelete(int id)
        {
            Retorno ret = new Retorno();
            try
            {
                UtilBLL util = new UtilBLL();
                string metodo = util.getConfig("produtoDelete");
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