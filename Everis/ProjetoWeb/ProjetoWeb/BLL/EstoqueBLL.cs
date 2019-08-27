using Newtonsoft.Json;
using ProjetoWeb.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ProjetoWeb.BLL
{
    public class EstoqueBLL
    {
        public RetornoEstoque BuscarEstoque()
        {
            UtilBLL util = new UtilBLL();
            String metodo = ConfigurationManager.AppSettings.Get("getTodoEstoque");
            RetornoString rs = util.realizaRequisicaoSemPmt(metodo, TipoRequisicao.GET);
            RetornoEstoque re = new RetornoEstoque();
            if (rs.sucesso.Equals(true))
                re = JsonConvert.DeserializeObject<RetornoEstoque>(rs.resposta);
            else
            {
                re.sucesso = false;
                re.erro = "Não foi possível conectar ao banco de dados.";
                re.listEstoque = new List<Estoque>();
            }

            return re;
        }

        public Retorno getEmpresaContemEstoque()
        {
            UtilBLL util = new UtilBLL();
            String metodo = ConfigurationManager.AppSettings.Get("getEmpresaContemEstoque");
            RetornoString rs = util.realizaRequisicaoSemPmt(metodo, TipoRequisicao.GET);
            RetornoEmpresa re = new RetornoEmpresa();
            if (rs.sucesso.Equals(true))
                re = JsonConvert.DeserializeObject<RetornoEmpresa>(rs.resposta);
            else
            {
                re.sucesso = false;
                re.erro = "Não foi possível conectar ao banco de dados.";
                re.listEmpresas = new List<Empresa>();
            }

            return re;
        }

        public Retorno getProdutoContemEstoque()
        {
            UtilBLL util = new UtilBLL();
            String metodo = ConfigurationManager.AppSettings.Get("getProdutoContemEstoque");
            RetornoString rs = util.realizaRequisicaoSemPmt(metodo, TipoRequisicao.GET);
            RetornoProduto rp = new RetornoProduto();
            if (rs.sucesso.Equals(true))
                rp = JsonConvert.DeserializeObject<RetornoProduto>(rs.resposta);
            else
            {
                rp.sucesso = false;
                rp.erro = "Não foi possível conectar ao banco de dados.";
                rp.listProdutos = new List<Produto>();
            }

            return rp;
        }

        public Retorno getEstoqueByProduto(int idProduto)
        {
            UtilBLL util = new UtilBLL();
            String metodo = ConfigurationManager.AppSettings.Get("getEstoqueByProduto");
            RetornoString rs = util.realizaRequisicaoComPmt(idProduto, metodo, TipoRequisicao.POST);
            RetornoEstoque re = new RetornoEstoque();
            if (rs.sucesso.Equals(true))
                re = JsonConvert.DeserializeObject<RetornoEstoque>(rs.resposta);
            else
            {
                re.sucesso = false;
                re.erro = "Não foi possível conectar ao banco de dados.";
                re.listEstoque = new List<Estoque>();
            }

            return re;
        }

        public Retorno getEstoqueByEmpresa(int idEmpresa)
        {
            UtilBLL util = new UtilBLL();
            String metodo = ConfigurationManager.AppSettings.Get("getEstoqueByEmpresa");
            RetornoString rs = util.realizaRequisicaoComPmt(idEmpresa, metodo, TipoRequisicao.POST);
            RetornoEstoque re = new RetornoEstoque();
            if (rs.sucesso.Equals(true))
                re = JsonConvert.DeserializeObject<RetornoEstoque>(rs.resposta);
            else
            {
                re.sucesso = false;
                re.erro = "Não foi possível conectar ao banco de dados.";
                re.listEstoque = new List<Estoque>();
            }

            return re;
        }

        public Retorno getProdutoByEmpresaContemEstoque(int idEmpresa)
        {
            UtilBLL util = new UtilBLL();
            String metodo = ConfigurationManager.AppSettings.Get("getProdutoByEmpresaContemEstoque");
            RetornoString rs = util.realizaRequisicaoComPmt(idEmpresa, metodo, TipoRequisicao.POST);
            RetornoProduto rp = new RetornoProduto();
            if (rs.sucesso.Equals(true))
                rp = JsonConvert.DeserializeObject<RetornoProduto>(rs.resposta);
            else
            {
                rp.sucesso = false;
                rp.erro = "Não foi possível conectar ao banco de dados.";
                rp.listProdutos = new List<Produto>();
            }

            return rp;
        }
    }
}