using EverisAPI.Connection;
using EverisAPI.Models;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace EverisAPI.DAO
{
    public class ProdutoDAO
    {

        public DataTable getProdutoByCod(string codProd)
        {
           String commandText = "SELECT * FROM tbProduto WHERE codProduto LIKE '@codProd%'";
            using (Command cmd = new Command(commandText)) {
                cmd.addParameter("@codProd", SqlDbType.VarChar, codProd);
                return cmd.getDataTable();
            }
        }

        public DataTable getProdutoByEan(string nrEAN)
        {
            string commandText = "SELECT * FROM tbProduto WHERE Nr_EAN LIKE '@nrEAN%'";
            using (Command cmd = new Command(commandText))
            {
                cmd.addParameter("@nrEAN", SqlDbType.VarChar, nrEAN);
                return cmd.getDataTable();
            }
        }

        public DataTable getProdutoNotIn(string campo, string campoValor, int idIn)
        {
            string commandText = "SELECT * FROM tbProduto WHERE " + campo + " = @campoValor AND id not in(@idIn)";
            using (Command cmd = new Command(commandText))
            {
                cmd.addParameter("@campoValor", SqlDbType.VarChar, campoValor);
                cmd.addParameter("@idIn", SqlDbType.Int, idIn);
                return cmd.getDataTable();
            }
        }

        public int createProduto(Produto produto)
        {
            
            string commandText = @"INSERT INTO tbProduto (codProduto, nomeProduto, nr_EAN) values (@codProduto,
                @nomeProduto, @nr_EAN)";
            using (Command cmd = new Command(commandText))
            {
                cmd.addParameter("@codProduto", SqlDbType.VarChar, produto.codProduto);
                cmd.addParameter("@nomeProduto", SqlDbType.VarChar, produto.nomeProduto);
                cmd.addParameter("@nr_EAN", SqlDbType.VarChar, produto.nr_EAN);
                return cmd.getNroLinhas();
            }
        }

        public int updateProduto(Produto produto)
        {
            string commandText = @"UPDATE tbProduto set codProduto = @codProduto, nomeProduto = @nomeProduto,
                 nr_EAN = @nr_EAN WHERE id = @id";
            using (Command cmd = new Command(commandText))
            {
                cmd.addParameter("@codProduto", SqlDbType.VarChar, produto.codProduto);
                cmd.addParameter("@nomeProduto", SqlDbType.VarChar, produto.nomeProduto);
                cmd.addParameter("@nr_EAN", SqlDbType.VarChar, produto.nr_EAN);
                cmd.addParameter("@id", SqlDbType.Int, produto.id);
                return cmd.getNroLinhas();
            }
        }

        public int deleteProduto(int idProduto)
        {
            string commandText = "DELETE FROM tbProduto WHERE id = @idProduto";
            using(Command cmd = new Command(commandText))
            {
                cmd.addParameter("@idProduto", SqlDbType.Int, idProduto);
                return cmd.getNroLinhas();
            }
        }

        public DataTable getProdutos()
        {
            string commandText = "SELECT * FROM tbProduto";
            using(Command cmd = new Command(commandText))
            {
                return cmd.getDataTable();
            }
        }
    }
}