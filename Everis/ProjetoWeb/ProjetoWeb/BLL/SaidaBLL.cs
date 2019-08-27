using Newtonsoft.Json;
using ProjetoWeb.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ProjetoWeb.BLL
{
    public class SaidaBLL
    {
        public RetornoSaida BuscarEntradas()
        {
            UtilBLL util = new UtilBLL();
            String metodo = ConfigurationManager.AppSettings.Get("getTodasSaidas");
            RetornoString rs = util.realizaRequisicaoSemPmt(metodo, TipoRequisicao.GET);
            RetornoSaida rSaida = new RetornoSaida();
            if (rs.sucesso.Equals(true))
                rSaida = JsonConvert.DeserializeObject<RetornoSaida>(rs.resposta);
            else
            {
                rSaida.sucesso = false;
                rSaida.erro = "Não foi possível conectar ao banco de dados.";
                rSaida.listSaidas = new List<Saida>();
            }

            return rSaida;
        }

        public Retorno Cadastrar(Saida saida)
        {
            UtilBLL util = new UtilBLL();
            String metodo = ConfigurationManager.AppSettings.Get("saidaCreate");
            RetornoString rs = util.realizaRequisicaoComPmt(saida, metodo, TipoRequisicao.POST);
            Retorno ret = new Retorno();
            if (rs.sucesso.Equals(true))
                ret = JsonConvert.DeserializeObject<Retorno>(rs.resposta);
            else
            {
                ret.sucesso = false;
                ret.erro = "Não foi possível conectar ao banco de dados.";
            }

            return ret;
        }
    }
}