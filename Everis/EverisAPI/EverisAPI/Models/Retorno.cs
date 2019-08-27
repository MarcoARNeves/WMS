using System;
using System.Collections.Generic;

namespace EverisAPI.Models
{
    public class Retorno
    {
        public Boolean sucesso { get; set; }
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
}