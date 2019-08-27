using EverisAPI.Connection;
using EverisAPI.Models;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace EverisAPI.DAO
{
    public class SaidaDAO
    {

        public DataTable getQtdSaidaByEmpresaProduto(int idEmpresa, int idProduto)
        {
            string commandText = @"SELECT SUM(quantidade) FROM tbControleSaida WHERE idEmpresa = @idEmpresa
                                AND idProduto = @idProduto";
            using (Command cmd = new Command(commandText))
            {
                cmd.addParameter("@idEmpresa", SqlDbType.Int, idEmpresa);
                cmd.addParameter("@idProduto", SqlDbType.Int, idProduto);
                return cmd.getDataTable();
            }
        }

        public int insereSaida(Saida saida)
        {
            string commandText = @"INSERT INTO tbControleSaida (idEmpresa, idProduto, quantidade) values (@idEmpresa,
                   @idProduto, @quantidade)";
            using(Command cmd = new Command(commandText))
            {
                cmd.addParameter("@idEmpresa", SqlDbType.Int, saida.idEmpresa);
                cmd.addParameter("@idProduto", SqlDbType.Int, saida.idProduto);
                cmd.addParameter("@quantidade", SqlDbType.Int, saida.quantidade);
                return cmd.getNroLinhas();
            }
        }

        public DataTable getSaidaByProduto(int idProd)
        {
            String commandText = @"SELECT * 
                                FROM tbControleSaida AS CS 
                                JOIN tbProduto P
                                ON CS.idProduto = P.id
                                JOIN tbEmpresa E
                                ON CS.idEmpresa = E.id
                                WHERE CS.idProduto = @idProd";
            using(Command cmd = new Command(commandText))
            {
                cmd.addParameter("@idProd", SqlDbType.Int, idProd);
                return cmd.getDataTable();
            }
        }

        public DataTable getSaidaByEmpresa(int idEmpresa)
        {
            String commandText = @"SELECT * 
                                FROM tbControleSaida AS CS 
                                JOIN tbProduto P
                                ON CS.idProduto = P.id
                                JOIN tbEmpresa E
                                ON CS.idEmpresa = E.id
                                WHERE CS.idEmpresa = @idEmpresa";
            using(Command cmd = new Command(commandText))
            {
                cmd.addParameter("@idEmpresa", SqlDbType.Int, idEmpresa);
                return cmd.getDataTable();
            }
        }

        public DataTable getTodasSaidas()
        {
            String commandText = @"SELECT * 
                                FROM tbControleSaida AS CS 
                                JOIN tbProduto P
                                ON CS.idProduto = P.id
                                JOIN tbEmpresa E
                                ON CS.idEmpresa = E.id";
            using (Command cmd = new Command(commandText))
            {
                return cmd.getDataTable();
            }
        }
    }
}