using Newtonsoft.Json;
using ProjetoWeb.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace ProjetoWeb.BLL
{
    public class UtilBLL
    {
        public string getConfig(string key)
        {
            return ConfigurationManager.AppSettings.Get(key);
        }

        public RetornoString realizaRequisicaoSemPmt(string metodo, TipoRequisicao tipoRequisicao)
        {
            RetornoString ret = new RetornoString();
            string URL = getConfig("urlApiEveris");
            URL = URL + metodo;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
            request.Method = tipoRequisicao.ToString();
            request.ContentType = "application/json";
            request.Accept = "application/json";

            try
            {
                WebResponse webResponse = request.GetResponse();
                HttpStatusCode response_code = ((HttpWebResponse)webResponse).StatusCode;

                if (response_code.Equals(HttpStatusCode.OK))
                {
                    ret.resposta = new StreamReader(webResponse.GetResponseStream()).ReadToEnd();
                    ret.sucesso = true;
                    ret.erro = string.Empty;
                }
                else
                {
                    Exception ex = new Exception("Não foi possível estabelecer uma conexão com o banco de dados.");
                }

                return ret;
            }
            catch (Exception ex)
            {
                ret.erro = ex.Message;
                ret.sucesso = false;
                ret.resposta = ex.Message;
                return ret;
            }
        }

        public RetornoString realizaRequisicaoComPmt(object obj, string metodo, TipoRequisicao tipoRequisicao)
        {
            RetornoString ret = new RetornoString();
            string DATA = JsonConvert.SerializeObject(obj);
            string URL = getConfig("urlApiEveris");
            URL = URL + metodo;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
            request.Method = tipoRequisicao.ToString();
            request.ContentType = "application/json";
            request.Accept = "application/json";
            request.ContentLength = DATA.Length;

            try
            {
                using (Stream webStream = request.GetRequestStream())
                using (StreamWriter requestWriter = new StreamWriter(webStream, System.Text.Encoding.ASCII))
                {
                    requestWriter.Write(DATA);
                }

                WebResponse webResponse = request.GetResponse();

                var resp = new StreamReader(webResponse.GetResponseStream()).ReadToEnd();
                HttpStatusCode response_code = ((HttpWebResponse)webResponse).StatusCode;

                if (response_code.Equals(HttpStatusCode.OK))
                {
                    ret.resposta = resp;
                    ret.sucesso = true;
                    ret.erro = string.Empty;
                }
                else
                {
                    Exception ex = new Exception("Não foi possível estabelecer uma conexão com o banco de dados.");
                }
                return ret;

            }
            catch (Exception ex)
            {
                ret.erro = ex.Message;
                ret.sucesso = false;
                ret.resposta = ex.Message;
                return ret;
            }
        }
    }
}