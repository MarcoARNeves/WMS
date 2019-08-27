using EverisAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace EverisAPI.BLL
{
    public class UtilBLL
    {
        public Retorno getRetornoException(Exception ex)
        {
            Retorno ret = new Retorno();
            ret.sucesso = false;
            ret.erro = ex.Message;
            return ret;
        }

        public RetornoSaida getRetornoSaidaException(Exception ex)
        {
            RetornoSaida ret = new RetornoSaida();
            ret.sucesso = false;
            ret.erro = ex.Message;
            ret.listSaidas = new List<Saida>();
            return ret;
        }

        public RetornoEntrada getRetornoEntradaException(Exception ex)
        {
            RetornoEntrada ret = new RetornoEntrada();
            ret.sucesso = false;
            ret.erro = ex.Message;
            ret.listEntradas = new List<Entrada>();
            return ret;
        }

        public RetornoEstoque getRetornoEstoqueException(Exception ex)
        {
            RetornoEstoque ret = new RetornoEstoque();
            ret.sucesso = false;
            ret.erro = ex.Message;
            ret.listEstoque = new List<Estoque>();
            return ret;
        }

        public RetornoProduto getRetornoProdutoException(Exception ex)
        {
            RetornoProduto ret = new RetornoProduto();
            ret.sucesso = false;
            ret.erro = ex.Message;
            ret.listProdutos = new List<Produto>();
            return ret;
        }

        public RetornoEmpresa getRetornoEmpresaException(Exception ex)
        {
            RetornoEmpresa ret = new RetornoEmpresa();
            ret.sucesso = false;
            ret.erro = ex.Message;
            ret.listEmpresas = new List<Empresa>();
            return ret;
        }
    }
}