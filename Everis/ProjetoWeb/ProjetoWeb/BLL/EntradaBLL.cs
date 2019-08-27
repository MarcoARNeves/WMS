using Newtonsoft.Json;
using ProjetoWeb.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ProjetoWeb.BLL
{
    public class EntradaBLL
    {
        public RetornoEntrada BuscarEntradas()
        {
            UtilBLL util = new UtilBLL();
            String metodo = ConfigurationManager.AppSettings.Get("getTodasEntradas");
            RetornoString rs = util.realizaRequisicaoSemPmt(metodo, TipoRequisicao.GET);
            RetornoEntrada re = new RetornoEntrada();
            if (rs.sucesso.Equals(true))
                re = JsonConvert.DeserializeObject<RetornoEntrada>(rs.resposta);
            else
            {
                re.sucesso = false;
                re.erro = "Não foi possível conectar ao banco de dados.";
                re.listEntradas = new List<Entrada>();
            }

            return re;
        }

        public Retorno Cadastrar(Entrada entrada)
        {
            Retorno retorno = new Retorno();
            retorno.sucesso = false;

            UtilBLL util = new UtilBLL();
            string metodo = util.getConfig("entradaCreate");
            RetornoString rs = util.realizaRequisicaoComPmt(entrada, metodo, TipoRequisicao.POST);
            if (rs.sucesso.Equals(true))
            {
                retorno = JsonConvert.DeserializeObject<Retorno>(rs.resposta);
            }
            return retorno;
        }
    }
}