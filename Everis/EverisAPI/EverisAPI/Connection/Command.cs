using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EverisAPI.Connection
{
    public class Command :IDisposable
    {
        SqlCommand cmd;

        public Command(string commandText)
        {
            cmd = createCommand();
            cmd.CommandText = commandText;
        }

        public Command()
        {
            cmd = createCommand();
        }

        public void CommandText(string commandText)
        {
            cmd.CommandText = commandText;
        }

        public void clearParameter()
        {
            cmd.Parameters.Clear();
        }
        public void addParameter(string nome, SqlDbType tipo, object valor)
        {
            SqlParameter param = new SqlParameter();
            param.ParameterName = nome;
            param.Value = valor;
            param.SqlDbType = tipo;
            cmd.Parameters.Add(param);
        }

        public SqlCommand createCommand()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = new SqlConnection(ConfigurationManager.AppSettings["conexao"]);
            cmd.Connection.Open();
            return cmd;
        }

        public DataTable getDataTable()
        {
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            return dt;
        }

        public int getNroLinhas()
        {
            return cmd.ExecuteNonQuery();
        }

        public void Dispose()
        {
            cmd.Connection.Close();
            cmd.Connection.Dispose();
            cmd.Dispose();
        }
    }
}