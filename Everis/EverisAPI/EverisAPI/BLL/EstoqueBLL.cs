using EverisAPI.DAO;
using EverisAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace EverisAPI.BLL
{
    public class EstoqueBLL
    {
        public Estoque montaEstoque(DataRow row)
        {
            try
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

                Estoque est = new Estoque();
                est.id = Convert.ToInt32(row["id"]);
                est.produto = prod;
                est.empresa = emp;
                est.quantidade = Convert.ToInt32(row["quantidade"]);
                return est;
            } catch (Exception ex)
            {
                throw ex;
            }
        }

        public RetornoEstoque getEstoque()
        {
            RetornoEstoque ret = new RetornoEstoque();
            try
            {
                EstoqueDAO DAO = new EstoqueDAO();
                DataTable dt = DAO.getEstoque();

                if (dt.Rows.Count.Equals(0))
                {
                    ret.erro = "0 entradas de mercadoria cadastradas.";
                    ret.sucesso = false;
                    ret.listEstoque = new List<Estoque>();
                    return ret;
                }

                List<Estoque> listEstoque = new List<Estoque>();
                foreach(DataRow row in dt.Rows)
                {
                    listEstoque.Add(montaEstoque(row));
                }

                ret.erro = string.Empty;
                ret.sucesso = true;
                ret.listEstoque = listEstoque;
                return ret;

            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public Retorno getEmpresaContemEstoque()
        {
            RetornoEmpresa retEmp = new RetornoEmpresa();
            try
            {
                EmpresaBLL bll = new EmpresaBLL();
                EstoqueDAO DAO = new EstoqueDAO();
                DataTable dt = DAO.getEstoqueDistinctEmpresa();

                if (dt.Rows.Count.Equals(0))
                {
                    retEmp.erro = "0 entradas de mercadoria cadastradas.";
                    retEmp.sucesso = false;
                    retEmp.listEmpresas = new List<Empresa>();
                    return retEmp;
                }

                List<Empresa> listEmpresa = new List<Empresa>();
                foreach (DataRow row in dt.Rows)
                {
                    listEmpresa.Add(bll.montaEmpresa(row));
                }

                retEmp.erro = String.Empty;
                retEmp.sucesso = true;
                retEmp.listEmpresas = listEmpresa;

                return retEmp;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Retorno getProdutoContemEstoque()
        {
            RetornoProduto retProd = new RetornoProduto();
            try
            {
                ProdutoBLL bll = new ProdutoBLL();
                EstoqueDAO DAO = new EstoqueDAO();
                DataTable dt = DAO.getEstoqueDistinctProduto();

                if (dt.Rows.Count.Equals(0))
                {
                    retProd.erro = "0 entradas de mercadoria cadastradas.";
                    retProd.sucesso = false;
                    retProd.listProdutos = new List<Produto>();
                    return retProd;
                }

                List<Produto> listProduto = new List<Produto>();
                foreach (DataRow row in dt.Rows)
                {
                    listProduto.Add(bll.montaProduto(row));
                }

                retProd.erro = String.Empty;
                retProd.sucesso = true;
                retProd.listProdutos = listProduto;

                return retProd;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Retorno getProdutoByIdEmpresaEstoque(int idEmpresa)
        {
            RetornoProduto retEmp = new RetornoProduto();
            try
            {
                EstoqueDAO DAO = new EstoqueDAO();
                DataTable dt = DAO.getEstoqueByIdEmpresa(idEmpresa);

                if (dt.Rows.Count.Equals(0))
                {
                    retEmp.erro = "0 entradas de mercadoria cadastradas.";
                    retEmp.sucesso = false;
                    retEmp.listProdutos = new List<Produto>();
                    return retEmp;
                }

                List<Estoque> listEstoque = new List<Estoque>();
                foreach (DataRow row in dt.Rows)
                {
                    listEstoque.Add(montaEstoque(row));
                }

                retEmp.erro = String.Empty;
                retEmp.sucesso = true;
                retEmp.listProdutos = new List<Produto>();
                foreach (Estoque estoque in listEstoque)
                {
                    retEmp.listProdutos.Add(estoque.produto);
                }
                return retEmp;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
     

        public RetornoEstoque getEstoqueByEmpresa(int idEmpresa)
        {
            RetornoEstoque ret = new RetornoEstoque();
            try
            {
                EstoqueDAO DAO = new EstoqueDAO();
                DataTable dt = DAO.getEstoqueByIdEmpresa(idEmpresa);

                if (dt.Rows.Count.Equals(0))
                {
                    ret.erro = "Ainda não foi cadastrado entradas de mercadoria para essa empresa.";
                    ret.sucesso = false;
                    ret.listEstoque = new List<Estoque>();
                }

                List<Estoque> listEstoque = new List<Estoque>();
                foreach (DataRow row in dt.Rows)
                {
                    listEstoque.Add(montaEstoque(row));
                }

                ret.erro = string.Empty;
                ret.sucesso = true;
                ret.listEstoque = listEstoque;
                return ret;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public RetornoEstoque getEstoqueByProduto(int idProduto)
        {
            RetornoEstoque ret = new RetornoEstoque();
            try
            {
                EstoqueDAO DAO = new EstoqueDAO();
                DataTable dt = DAO.getEstoqueByIdProduto(idProduto);

                if (dt.Rows.Count.Equals(0))
                {
                    ret.erro = "Ainda não foi cadastrado entradas dessa mercadoria para essa empresa.";
                    ret.sucesso = false;
                    ret.listEstoque = new List<Estoque>();
                }

                List<Estoque> listEstoque = new List<Estoque>();
                foreach (DataRow row in dt.Rows)
                {
                    listEstoque.Add(montaEstoque(row));
                }

                ret.erro = string.Empty;
                ret.sucesso = true;
                ret.listEstoque = listEstoque;
                return ret;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AtualizaEstoque(int idEmpresa, int idProduto)
        {
            EntradaDAO entradaDAO = new EntradaDAO();
            SaidaDAO saidaDAO = new SaidaDAO();
            EstoqueDAO estoqueDAO = new EstoqueDAO();

            DataTable dt = estoqueDAO.getQtdRegistrosByEmpresaProduto(idEmpresa, idProduto);
            int qtdRegistros = Convert.ToInt32(dt.Rows[0][0]);

            if (qtdRegistros.Equals(0)) {
                dt = entradaDAO.getQtdEntradaByEmpresaProduto(idEmpresa, idProduto);
                int qtdEntrada = Convert.ToInt32(dt.Rows[0][0]);
                estoqueDAO.createEstoque(idEmpresa, idProduto, qtdEntrada);
            } else
            {
                dt = entradaDAO.getQtdEntradaByEmpresaProduto(idEmpresa, idProduto);
                int qtdEntrada = Convert.ToInt32(dt.Rows[0][0]);
                dt = saidaDAO.getQtdSaidaByEmpresaProduto(idEmpresa, idProduto);
                int qtdSaida = 0;
                if (dt.Rows.Count > 0)
                {
                    if (!dt.Rows[0][0].Equals(DBNull.Value)){
                        qtdSaida = Convert.ToInt32(dt.Rows[0][0]);
                    }
                }
                int quantidade = qtdEntrada - qtdSaida;

                estoqueDAO.updateEstoque(idEmpresa, idProduto, quantidade);
            }

        }
    }
}