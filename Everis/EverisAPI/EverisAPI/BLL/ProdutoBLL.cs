using EverisAPI.DAO;
using EverisAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace EverisAPI.BLL
{
    public class ProdutoBLL
    {
        public Retorno validaCampos(Produto produto)
        {
            try
            {
                Retorno ret = new Retorno();
                ret.sucesso = true;
                DataTable dt;
                ProdutoDAO DAO = new ProdutoDAO();
                dt = DAO.getProdutoNotIn("codProduto", produto.codProduto, produto.id);
                if (dt.Rows.Count > 0)
                {
                    ret.sucesso = false;
                    ret.erro = "Já existe um produto cadastrado utilizando esse código.";
                    return ret;
                }
                else
                {
                    dt = DAO.getProdutoNotIn("Nr_EAN", produto.nr_EAN, produto.id);
                    if (dt.Rows.Count > 0)
                    {
                        ret.sucesso = false;
                        ret.erro = "Já existe um produto cadastrado utilizando esse EAN.";
                        return ret;
                    }
                }
                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public String verificaPreenchido(Produto produto)
        {
            String resposta = String.Empty;
            if (produto.codProduto == null || produto.nr_EAN == null || produto.nomeProduto == null)
                resposta = "Preencha todos os campos do produto.";
            else if (produto.codProduto == String.Empty || produto.nr_EAN == String.Empty ||
                produto.nomeProduto == String.Empty)
                resposta = "Preencha todos os campos do produto.";

            return resposta;
        }

        public Produto removerEspacos(Produto produto)
        {
            produto.codProduto = produto.codProduto.Trim();
            produto.nomeProduto = produto.nomeProduto.Trim();
            produto.nr_EAN = produto.nr_EAN.Trim();
            return produto;
        }

        public Retorno createProduto(Produto produto)
        {
            try
            {
                string parametroPreenchido = verificaPreenchido(produto);
                if (!parametroPreenchido.Equals(String.Empty))
                    throw new Exception(parametroPreenchido);

                produto = removerEspacos(produto);

                Retorno ret = validaCampos(produto);

                if (ret.sucesso.Equals(false))
                    return ret;

                ProdutoDAO DAO = new ProdutoDAO();
                int sucesso = DAO.createProduto(produto);

                if(sucesso > 0)
                {
                    ret.sucesso = true;
                    ret.erro = String.Empty;
                } else
                {
                    ret.sucesso = false;
                    ret.erro = "Não foi possível cadastrar esse produto.";
                }

                return ret;
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public Retorno updateProduto(Produto produto)
        {
            try
            {
                string parametroPreenchido = verificaPreenchido(produto);
                if (!parametroPreenchido.Equals(String.Empty))
                    throw new Exception(parametroPreenchido);

                produto = removerEspacos(produto);

                ProdutoDAO DAO = new ProdutoDAO();
                Retorno ret = validaCampos(produto);
                if (ret.sucesso.Equals(false))
                    return ret;

                int sucesso = DAO.updateProduto(produto);
                if (sucesso > 0)
                {
                    ret.sucesso = true;
                    ret.erro = String.Empty;
                } else
                {
                    ret.sucesso = false;
                    ret.erro = "Não foi possível atualizar as informações referentes a esse produto.";
                }

                return ret;
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public Retorno deleteProduto(int id)
        {
            try
            {
                Retorno ret = new Retorno();
                ProdutoDAO DAO = new ProdutoDAO();
                EstoqueDAO estoqueDAO = new EstoqueDAO();
                DataTable dt = estoqueDAO.getEstoqueByIdProduto(id);

                if(dt.Rows.Count > 0)
                {
                    ret.sucesso = false;
                    ret.erro = "Não foi possível excluir essa mercadoria pois existem entradas dessa mercadoria no estoque.";
                    return ret;
                }

                int sucesso = DAO.deleteProduto(id);
                if (sucesso > 0)
                {
                    ret.sucesso = true;
                    ret.erro = String.Empty;
                } else
                {
                    ret.sucesso = false;
                    ret.erro = "Não foi possível excluir esse produto.";
                }

                return ret;
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public RetornoProduto getProdutos()
        {
            try
            {
                RetornoProduto ret = new RetornoProduto();
                ProdutoDAO DAO = new ProdutoDAO();
                DataTable dt = DAO.getProdutos();
                List<Produto> listProdutos = new List<Produto>();

                foreach (DataRow row in dt.Rows)
                {
                    listProdutos.Add(montaProduto(row));
                }

                if (listProdutos.Count.Equals(0))
                {
                    ret.sucesso = false;
                    ret.erro = "0 produtos cadastrados.";
					ret.listProdutos = new List<Produto>();
                    return ret;
                }
                
                ret.sucesso = true;
                ret.erro = String.Empty;
                ret.listProdutos = listProdutos;
                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Produto montaProduto(DataRow row)
        {
            Produto prod = new Produto();
            prod.codProduto = row["codProduto"].ToString();
            prod.nr_EAN = row["nr_EAN"].ToString();
            prod.nomeProduto = row["nomeProduto"].ToString();
            prod.id = Convert.ToInt32(row["id"]);
            return prod;
        }

        public RetornoProduto getProdutoByCod(String codProduto)
        {
            try
            {
                RetornoProduto ret = new RetornoProduto();
                ProdutoDAO DAO = new ProdutoDAO();
                DataTable dt = DAO.getProdutoByCod(codProduto);
                List<Produto> listProdutos = new List<Produto>();

                if (dt.Rows.Count.Equals(0))
                {
                    ret.sucesso = false;
                    ret.erro = "Não há nenhum produto com código semelhante a esse.";
                    return ret;
                }

                foreach (DataRow row in dt.Rows)
                {
                    listProdutos.Add(montaProduto(row));
                }

                ret.sucesso = true;
                ret.erro = String.Empty;
                ret.listProdutos = listProdutos;
                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public RetornoProduto getProdutoByEan(String codEAN)
        {
            try
            {
                RetornoProduto ret = new RetornoProduto();
                ProdutoDAO DAO = new ProdutoDAO();
                DataTable dt = DAO.getProdutoByEan(codEAN);
                List<Produto> listProdutos = new List<Produto>();

                if (dt.Rows.Count.Equals(0))
                {
                    ret.sucesso = false;
                    ret.erro = "Não há nenhum produto com EAN semelhante a esse.";
                    return ret;
                }

                foreach (DataRow row in dt.Rows)
                {
                    listProdutos.Add(montaProduto(row));
                }

                ret.sucesso = true;
                ret.erro = String.Empty;
                ret.listProdutos = listProdutos;
                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}