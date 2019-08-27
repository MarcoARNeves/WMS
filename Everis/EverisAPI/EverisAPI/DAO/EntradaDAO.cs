using EverisAPI.Connection;
using EverisAPI.Models;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace EverisAPI.DAO
{
    public class EntradaDAO
    {
        public DataTable getQtdEntradaByEmpresaProduto(int idEmpresa, int idProduto)
        {
            string commandText = @"SELECT SUM(quantidade) FROM tbControleEntrada WHERE idEmpresa = @idEmpresa
                AND idProduto = @idProduto";
            using(Command cmd = new Command(commandText))
            {
                cmd.addParameter("@idEmpresa", SqlDbType.Int, idEmpresa);
                cmd.addParameter("@idProduto", SqlDbType.Int, idProduto);
                return cmd.getDataTable();
            }
        }

        public int insereEntrada(Entrada entrada)
        {
            String commandText = @"INSERT INTO tbControleEntrada (idEmpresa, idProduto, quantidade) values (
            @idEmpresa, @idProduto, @quantidade)";
            using (Command cmd = new Command(commandText))
            {
                cmd.addParameter("@idEmpresa", SqlDbType.Int, entrada.idEmpresa);
                cmd.addParameter("@idProduto", SqlDbType.Int, entrada.idProduto);
                cmd.addParameter("@quantidade", SqlDbType.Int, entrada.quantidade);
                return cmd.getNroLinhas();
            }
        }

        public DataTable getEntradaByProduto(int idProd)
        {
            string commandText = @"SELECT * 
                                FROM tbControleEntrada AS CE 
                                JOIN tbProduto P
                                ON CE.idProduto = P.id
                                JOIN tbEmpresa E
                                ON CE.idEmpresa = E.id
                                WHERE CE.idProduto = @idProd";
            using (Command cmd = new Command(commandText))
            {
                cmd.addParameter("@idProd", SqlDbType.Int, idProd);
                return cmd.getDataTable();
            }
        }

        public DataTable getEntradaByEmpresa(int idEmpresa)
        {
            string commandText = @"SELECT * 
                                FROM tbControleEntrada AS CE 
                                JOIN tbProduto P
                                ON CE.idProduto = P.id
                                JOIN tbEmpresa E
                                ON CE.idEmpresa = E.id
                                WHERE CE.idEmpresa = @idEmpresa";
            using (Command cmd = new Command(commandText))
            {
                cmd.addParameter("@idEmpresa", SqlDbType.Int, idEmpresa);
                return cmd.getDataTable();
            }
        }

        public DataTable getTodasEntradas()
        {
            string commandText = @"SELECT * 
                                FROM tbControleEntrada AS CE 
                                JOIN tbProduto P
                                ON CE.idProduto = P.id
                                JOIN tbEmpresa E
                                ON CE.idEmpresa = E.id";
            using (Command cmd = new Command(commandText))
            {
                return cmd.getDataTable();
            }
        }
    }
}