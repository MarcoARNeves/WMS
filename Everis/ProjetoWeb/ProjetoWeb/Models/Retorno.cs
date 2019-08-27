using System;
using System.Collections.Generic;

namespace ProjetoWeb.Models
{
    public class Retorno
    {
        public bool? sucesso { get; set; }
        public String erro { get; set; }
    }

    public class RetornoEmpresa : Retorno
    {
        public List<Empresa> listEmpresas { get; set; }
    }
    
    public class RetornoProduto : Retorno
    {
        public List<Produto> listProdutos { get; set; }
    }

    public class RetornoEntrada : Retorno
    {
        public List<Entrada> listEntradas { get; set; }
    }

    public class RetornoSaida : Retorno
    {
        public List<Saida> listSaidas { get; set; }
    }

    public class RetornoEstoque : Retorno
    {
        public List<Estoque> listEstoque { get; set; }
    }

    public class RetornoString : Retorno
    {
        public String resposta { get; set; }
    }
}