using EverisAPI.DAO;
using EverisAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace EverisAPI.BLL
{
    public class EmpresaBLL
    {
        public Retorno validaCampos(Empresa empresa)
        {
            try
            {
                Retorno ret = new Retorno();
                ret.sucesso = true;
                DataTable dt;
                EmpresaDAO DAO = new EmpresaDAO();
                dt = DAO.selectEmpresaNotIn("nomeEmpresa", empresa.nome, empresa.id);
                if (dt.Rows.Count > 0)
                {
                    ret.sucesso = false;
                    ret.erro = "Já existe uma empresa cadastrada utilizando esse nome.";
                    return ret;
                }
                else
                {
                    dt = DAO.selectEmpresaNotIn("cnpj", empresa.CNPJ, empresa.id);
                    if (dt.Rows.Count > 0)
                    {
                        ret.sucesso = false;
                        ret.erro = "Já existe uma empresa cadastrada utilizando esse CNPJ.";
                        return ret;
                    }
                }
                return ret;
            }catch (Exception ex)
            {
                throw ex;
            }
        }

        public Empresa removeEspacos(Empresa empresa)
        {
            empresa.nome = empresa.nome.Trim();
            empresa.CNPJ = empresa.CNPJ.Trim();
            return empresa;
        }

        public Retorno createEmpresa(Empresa empresa)
        {
            try
            {
                string parametroPreenchido = verificaPreenchido(empresa);
                if (!parametroPreenchido.Equals(string.Empty))
                    throw new Exception(parametroPreenchido);

                empresa = removeEspacos(empresa);

                Retorno ret = new Retorno();
                bool cnpjNumero = Int32.TryParse(empresa.CNPJ, out int result);
                if (cnpjNumero.Equals(false))
                {
                    ret.sucesso = false;
                    ret.erro = "O CNPJ deve conter apenas números.";
                    return ret;
                }

                string camposPreenchidos = verificaPreenchido(empresa);
                if (!camposPreenchidos.Equals(String.Empty))
                    throw new Exception(camposPreenchidos);

                EmpresaDAO DAO = new EmpresaDAO();
                ret = validaCampos(empresa);

                if (ret.sucesso.Equals(false))
                    return ret;

                int sucesso = DAO.createEmpresa(empresa);
                if (sucesso > 0)
                {
                    ret.sucesso = true;
                    ret.erro = String.Empty;
                }
                else
                {
                    ret.sucesso = false;
                    ret.erro = "Não foi possível cadastrar essa empresa.";
                }

                return ret;
            } catch (Exception ex)
            {
                throw ex;
            }
        }

        public Retorno updateEmpresa(Empresa empresa)
        {
            try
            {
                string parametroPreenchido = verificaPreenchido(empresa);
                if (!parametroPreenchido.Equals(String.Empty))
                    throw new Exception(parametroPreenchido);

                empresa = removeEspacos(empresa);

                EmpresaDAO DAO = new EmpresaDAO();
                Retorno ret = validaCampos(empresa);

                if (ret.sucesso.Equals(false))
                    return ret;
                int sucesso = DAO.updateEmpresa(empresa);
                if (sucesso > 0)
                {
                    ret.sucesso = true;
                    ret.erro = string.Empty;
                }
                else
                {
                    ret.sucesso = false;
                    ret.erro = "Não foi possível editar essa empresa.";
                }

                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Retorno deleteEmpresa(int id)
        {
            try
            {
                Retorno ret = new Retorno();
                EmpresaDAO DAO = new EmpresaDAO();
                EstoqueDAO estoqueDAO = new EstoqueDAO();
                DataTable dt = estoqueDAO.getEstoqueByIdEmpresa(id);
                if (dt.Rows.Count > 0)
                {
                    ret.sucesso = false;
                    ret.erro = "Existem entradas de mercadoria relacionadas a está empresa, portanto ela não pode ser excluida.";
                    return ret;
                }

                int sucesso = DAO.deleteEmpresa(id);
                if (sucesso > 0)
                {
                    ret.sucesso = true;
                    ret.erro = String.Empty;
                }
                else
                {
                    ret.sucesso = false;
                    ret.erro = "Não foi possível excluir essa empresa";
                }
                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public String verificaPreenchido(Empresa empresa)
        {
            String resposta = String.Empty;
            if (empresa.CNPJ == null || empresa.nome == null)
                resposta = "Preencha todos os campos da empresa.";
            else if (empresa.CNPJ == String.Empty || empresa.nome == String.Empty)
                resposta = "Preencha todos os campos da empresa.";

            return resposta;
        }

        public RetornoEmpresa GetEmpresas()
        {
            try
            {
                EmpresaDAO DAO = new EmpresaDAO();
                DataTable dt = DAO.getTodasEmpresas();
                RetornoEmpresa ret = new RetornoEmpresa();
                List<Empresa> listEmpresa = new List<Empresa>();
                if (dt.Rows.Count.Equals(0))
                {
                    ret.erro = "0 empresas cadastradas.";
                    ret.sucesso = false;
                    ret.listEmpresas = new List<Empresa>();
                    return ret;
                }
                foreach (DataRow row in dt.Rows)
                {
                    listEmpresa.Add(montaEmpresa(row));
                }

                ret.sucesso = true;
                ret.erro = String.Empty;
                ret.listEmpresas = listEmpresa;
                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Empresa montaEmpresa(DataRow row)
        {
            Empresa empresa = new Empresa();
            empresa.nome = row["nomeEmpresa"].ToString();
            empresa.CNPJ = row["cnpj"].ToString();
            empresa.id = Convert.ToInt32(row["id"]);
            return empresa;
        }

        public RetornoEmpresa getEmpresaByName(String nome)
        {
            try
            {
                EmpresaDAO DAO = new EmpresaDAO();
                DataTable dt = DAO.getEmpresaByName( nome);
                RetornoEmpresa ret = new RetornoEmpresa();
                List<Empresa> listEmpresa = new List<Empresa>();
                foreach (DataRow row in dt.Rows)
                {
                    listEmpresa.Add(montaEmpresa(row));
                }

                ret.sucesso = true;
                ret.erro = String.Empty;
                ret.listEmpresas = listEmpresa;
                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}