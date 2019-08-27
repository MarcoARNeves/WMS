using EverisAPI.DAO;
using EverisAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace EverisAPI.BLL
{
    public class SaidaBLL
    {
        public Retorno insereSaida(Saida saida)
        {
            Retorno ret = new Retorno();
            try
            {
                if (saida.quantidade < 1)
                    throw new Exception("Quantidade incorreta.");

                SaidaDAO DAO = new SaidaDAO();
                EstoqueBLL estoqueBLL = new EstoqueBLL();
                EstoqueDAO estoqueDAO = new EstoqueDAO();

                estoqueBLL.AtualizaEstoque(saida.idEmpresa, saida.idProduto);
                DataTable dt = estoqueDAO.getTotalEstoqueByEmpresaProduto(saida.idEmpresa, saida.idProduto);

                if (dt.Rows.Count.Equals(0))
                {
                    throw new Exception("Essa empresa não contém esse item no estoque");
                }

                if (Convert.ToInt32(dt.Rows[0]["quantidade"]) < saida.quantidade)
                {
                    throw new Exception("Essa empresa não contém essa quantidade de mercadoria no estoque");
                }
                

                int sucesso = DAO.insereSaida(saida);
                estoqueBLL.AtualizaEstoque(saida.idEmpresa, saida.idProduto);

                if (sucesso > 0)
                {
                    ret.sucesso = true;
                    ret.erro = String.Empty;
                }
                else
                {
                    ret.sucesso = false;
                    throw new Exception("Não foi possível inserir essa saída.");
                }

                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public RetornoSaida getSaidaByProduto(int idProd)
        {
            RetornoSaida ret = new RetornoSaida();
            try
            {
                SaidaDAO DAO = new SaidaDAO();
                DataTable dt = DAO.getSaidaByProduto(idProd);
                List<Saida> listSaidas = new List<Saida>();
                if (dt.Rows.Count.Equals(0))
                {
                    throw new Exception("Não há saídas cadastradas com esse produto.");
                }

                foreach (DataRow row in dt.Rows)
                {
                    listSaidas.Add(montarSaida(row));
                }

                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public RetornoSaida getSaidaByEmpresa(int idEmpresa)
        {
            RetornoSaida ret = new RetornoSaida();
            try
            {
                SaidaDAO DAO = new SaidaDAO();
                DataTable dt = DAO.getSaidaByEmpresa(idEmpresa);
                List<Saida> listSaidas = new List<Saida>();
                if (dt.Rows.Count.Equals(0))
                {
                    throw new Exception("Não há saídas cadastradas com essa empresa.");
                }

                foreach (DataRow row in dt.Rows)
                {
                    listSaidas.Add(montarSaida(row));
                }

                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public RetornoSaida getTodasSaidas()
        {
            RetornoSaida ret = new RetornoSaida();
            try
            {
                SaidaDAO DAO = new SaidaDAO();
                DataTable dt = DAO.getTodasSaidas();
                List<Saida> listSaidas = new List<Saida>();
                if (dt.Rows.Count.Equals(0))
                {
                    throw new Exception("0 saídas cadastradas.");
                }

                foreach (DataRow row in dt.Rows)
                {
                    listSaidas.Add(montarSaida(row));
                }

                ret.sucesso = true;
                ret.erro = String.Empty;
                ret.listSaidas = listSaidas;

                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Saida montarSaida(DataRow row)
        {
            Produto prod = new Produto();
            prod.codProduto = row["codProduto"].ToString();
            prod.nr_EAN = row["nr_EAN"].ToString();
            prod.nomeProduto = row["nomeProduto"].ToString();
            prod.id = Convert.ToInt32(row["idProduto"]);

            Empresa emp = new Empresa();
            emp.CNPJ = row["CNPJ"].ToString();
            emp.nome = row["nomeEmpresa"].ToString();
            emp.id = Convert.ToInt32(row["idEmpresa"]);

            Saida sai = new Saida();
            sai.id = Convert.ToInt32(row["id"]);
            sai.produto = prod;
            sai.empresa = emp;
            sai.quantidade = Convert.ToInt32(row["quantidade"]);
            return sai;
        }
    }
}