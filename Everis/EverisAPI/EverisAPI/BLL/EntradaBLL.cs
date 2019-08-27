using EverisAPI.DAO;
using EverisAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace EverisAPI.BLL
{
    public class EntradaBLL
    {
        public Retorno insereEntrada(Entrada entrada)
        {
            Retorno ret = new Retorno();
            try
            {
                if (entrada.quantidade < 1)
                    throw new Exception("Quantidade incorreta.");

                EntradaDAO DAO = new EntradaDAO();
                int sucesso = DAO.insereEntrada(entrada);
                EstoqueBLL estoqueBLL = new EstoqueBLL();
                estoqueBLL.AtualizaEstoque(entrada.idEmpresa, entrada.idProduto);

                if (sucesso > 0)
                {
                    ret.sucesso = true;
                    ret.erro = String.Empty;
                }
                else
                {
                    ret.sucesso = false;
                    ret.erro = "Não foi possível inserir essa entrada.";
                }

                return ret;
            }catch (Exception ex)
            {
                ret.erro = ex.Message;
                ret.sucesso = false;
                return ret;
            }
        }

        public RetornoEntrada getEntradaByProduto(int idProd)
        {
            RetornoEntrada ret = new RetornoEntrada();
            try
            {
                EntradaDAO DAO = new EntradaDAO();
                DataTable dt = DAO.getEntradaByProduto(idProd);
                List<Entrada> listEntradas = new List<Entrada>();
                if (dt.Rows.Count.Equals(0))
                {
                    ret.listEntradas = new List<Entrada>();
                    ret.erro = "Não há entradas cadastradas com esse produto.";
                    ret.sucesso = false;
                    return ret;
                }

                foreach (DataRow row in dt.Rows)
                {
                    listEntradas.Add(montarEntrada(row));
                }

                return ret;
            }
            catch (Exception ex)
            {
                ret.erro = ex.Message;
                ret.sucesso = false;
                ret.listEntradas = new List<Entrada>();
                return ret;
            }
        }

        public RetornoEntrada getTodasEntradas()
        {
            RetornoEntrada ret = new RetornoEntrada();
            try
            {
                EntradaDAO DAO = new EntradaDAO();
                DataTable dt = DAO.getTodasEntradas();
                List<Entrada> listEntradas = new List<Entrada>();
                if (dt.Rows.Count.Equals(0))
                {
                    ret.listEntradas = new List<Entrada>();
                    ret.erro = "0 entradas cadastradas.";
                    ret.sucesso = false;
                    return ret;
                }

                foreach (DataRow row in dt.Rows)
                {
                    listEntradas.Add(montarEntrada(row));
                }
                ret.listEntradas = listEntradas;
                return ret;
            }
            catch (Exception ex)
            {
                ret.erro = ex.Message;
                ret.sucesso = false;
                ret.listEntradas = new List<Entrada>();
                return ret;
            }
        }

        public RetornoEntrada getEntradaByEmpresa(int idEmpresa)
        {
            RetornoEntrada ret = new RetornoEntrada();
            try
            {
                EntradaDAO DAO = new EntradaDAO();
                DataTable dt = DAO.getEntradaByEmpresa(idEmpresa);
                List<Entrada> listEntradas = new List<Entrada>();
                if (dt.Rows.Count.Equals(0))
                {
                    ret.listEntradas = new List<Entrada>();
                    ret.erro = "Não há entradas cadastradas com essa empresa.";
                    ret.sucesso = false;
                    return ret;
                }

                foreach (DataRow row in dt.Rows)
                {
                    listEntradas.Add(montarEntrada(row));
                }

                return ret;
            }
            catch (Exception ex)
            {
                ret.erro = ex.Message;
                ret.sucesso = false;
                ret.listEntradas = new List<Entrada>();
                return ret;
            }
        }

        public Entrada montarEntrada(DataRow row)
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

            Entrada ent = new Entrada();
            ent.id = Convert.ToInt32(row["id"]);
            ent.produto = prod;
            ent.empresa = emp;
            ent.quantidade = Convert.ToInt32(row["quantidade"]);
            return ent;
        }
    }
}