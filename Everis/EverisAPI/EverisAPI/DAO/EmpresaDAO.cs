using EverisAPI.Connection;
using EverisAPI.Models;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace EverisAPI.DAO
{
    public class EmpresaDAO
    {

        public DataTable getEmpresaByName(string nome)
        {
            string commandText = "SELECT * FROM tbEmpresa WHERE nomeEmpresa LIKE '@nome%'";
            using (Command cmd = new Command(commandText))
            {
                cmd.addParameter("@nome", SqlDbType.VarChar, nome);
                return cmd.getDataTable();
            }
        }

        public DataTable getTodasEmpresas()
        {
            string commandText = "SELECT * FROM tbEmpresa";
            using (Command cmd = new Command(commandText))
            {
                return cmd.getDataTable();
            }
        }

        public DataTable selectEmpresaNotIn(string campo, string campoValor, int idIn)
        {
            string commandText = "SELECT * FROM tbEmpresa WHERE " + campo + " = @campoValor AND id not in(@idIn)";
            using (Command cmd = new Command(commandText))
            {
                cmd.addParameter("@campoValor", SqlDbType.VarChar, campoValor);
                cmd.addParameter("@idIn", SqlDbType.Int, idIn);
                return cmd.getDataTable();
            }
        }

        public int createEmpresa(Empresa empresa)
        {
            string commandText = @"INSERT INTO tbEmpresa (nomeEmpresa, cnpj) values (@nomeEmpresa, @cnpj)";
            using (Command cmd = new Command(commandText))
            {
                cmd.addParameter("@nomeEmpresa", SqlDbType.VarChar, empresa.nome);
                cmd.addParameter("@cnpj", SqlDbType.VarChar, empresa.CNPJ);
                return cmd.getNroLinhas();
            }
        }

        public int deleteEmpresa(int id)
        {
            string commandText = "DELETE FROM tbEmpresa WHERE id = @id";
            using (Command cmd = new Command(commandText))
            {
                cmd.addParameter("@id", SqlDbType.Int, id);
                return cmd.getNroLinhas();
            }
        }

        public int updateEmpresa(Empresa empresa)
        {
            string commandText = @"UPDATE tbEmpresa SET nomeEmpresa = @nomeEmpresa, cnpj = @cnpj WHERE id = @id";
            using (Command cmd = new Command(commandText))
            {
                cmd.addParameter("@nomeEmpresa", SqlDbType.VarChar, empresa.nome);
                cmd.addParameter("@cnpj", SqlDbType.VarChar, empresa.CNPJ);
                cmd.addParameter("@id", SqlDbType.Int, empresa.id);
                return cmd.getNroLinhas();
            }
        }
    }
}