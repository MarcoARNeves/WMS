using EverisAPI.Connection;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace EverisAPI.DAO
{
    public class EstoqueDAO
    {
        public int updateEstoque(int idEmpresa, int idProduto, int quantidade)
        {
            string commandText = @"UPDATE tbEstoque SET quantidade = @quantidade WHERE idEmpresa = @idEmpresa
                 AND idProduto = @idProduto";
            using (Command cmd = new Command(commandText))
            {
                cmd.addParameter("@quantidade", SqlDbType.Int, quantidade);
                cmd.addParameter("@idEmpresa", SqlDbType.Int, idEmpresa);
                cmd.addParameter("@idProduto", SqlDbType.Int, idProduto);
                return cmd.getNroLinhas();
            }
        }


        public DataTable getQtdRegistrosByEmpresaProduto(int idEmpresa, int idProduto)
        {
            string commandText = @"SELECT COUNT(*) FROM tbEstoque WHERE idEmpresa = @idEmpresa
                AND idProduto = @idProduto";
            using (Command cmd = new Command(commandText))
            {
                cmd.addParameter("@idEmpresa", SqlDbType.Int, idEmpresa);
                cmd.addParameter("@idProduto", SqlDbType.Int, idProduto);
                return cmd.getDataTable();
            }
        }

        public int createEstoque(int idEmpresa, int idProduto, int quantidade)
        {
            string commandText = @"INSERT INTO tbEstoque VALUES (@idEmpresa, @idProduto, @quantidade)";
            using (Command cmd = new Command(commandText))
            {
                cmd.addParameter("@quantidade", SqlDbType.Int, quantidade);
                cmd.addParameter("@idEmpresa", SqlDbType.Int, idEmpresa);
                cmd.addParameter("@idProduto", SqlDbType.Int, idProduto);
                return cmd.getNroLinhas();
            }
        }

        public DataTable getEstoqueByIdEmpresa(int idEmpresa)
        {
            string commandText = @"SELECT * 
                                FROM tbEstoque AS E
                                JOIN tbProduto AS P
                                ON E.idProduto = P.id
                                JOIN tbEmpresa AS EMP
                                ON E.idEmpresa = EMP.id
                                WHERE idEmpresa = @idEmpresa";
            using (Command cmd = new Command(commandText))
            {
                cmd.addParameter("@idEmpresa", SqlDbType.Int, idEmpresa);
                return cmd.getDataTable();
            }
        }

        public DataTable getEstoqueByIdProduto(int idProduto)
        {
            string commandText = @"SELECT * 
                                FROM tbEstoque AS E
                                JOIN tbProduto AS P
                                ON E.idProduto = P.id
                                JOIN tbEmpresa AS EMP
                                ON E.idEmpresa = EMP.id
                                WHERE idProduto = @idProduto";
            using (Command cmd = new Command(commandText))
            {
                cmd.addParameter("@idProduto", SqlDbType.Int, idProduto);
                return cmd.getDataTable();
            }
        }

        public DataTable getEstoque()
        {
            string commandText = @"SELECT * 
                                FROM tbEstoque AS E
                                JOIN tbProduto AS P
                                ON E.idProduto = P.id
                                JOIN tbEmpresa AS EMP
                                ON E.idEmpresa = EMP.id";
            using (Command cmd = new Command(commandText))
            {
                return cmd.getDataTable();
            }
        }

        public DataTable getEstoqueDistinctProduto()
        {
            string commandText = @"SELECT DISTINCT(P.id), 
                                P.codProduto, 
                                P.nr_EAN, 
                                P.nomeProduto
                                FROM tbEstoque AS E
                                JOIN tbProduto AS P
                                ON E.idProduto = P.id";
            using (Command cmd = new Command(commandText))
            {
                return cmd.getDataTable();
            }
        }

        public DataTable getEstoqueDistinctEmpresa()
        {
            string commandText = @"SELECT DISTINCT(EMP.id), 
                                EMP.nomeEmpresa, 
                                EMP.cnpj
                                FROM tbEstoque AS E
                                JOIN tbEmpresa AS EMP
                                ON E.idEmpresa = EMP.id";
            using (Command cmd = new Command(commandText))
            {
                return cmd.getDataTable();
            }
        }

        public DataTable getTotalEstoqueByEmpresaProduto(int idEmpresa, int idProduto)
        {
            string commandText = @"SELECT sum(quantidade) AS quantidade 
                                FROM tbEstoque 
                                WHERE idEmpresa = @idEmpresa
                                AND idProduto = @idProduto";
            using (Command cmd = new Command(commandText))
            {
                cmd.addParameter("@idEmpresa", SqlDbType.Int, idEmpresa);
                cmd.addParameter("@idProduto", SqlDbType.Int, idProduto);
                return cmd.getDataTable();
            }
        }
    }
}