using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace AppBancoDigital.Service
{
    public abstract class DataService
    {
        private static readonly string servidor = "https://10.0.2.2:8000";

        private static string DecodeServerError(System.Net.HttpStatusCode status_code)
        {
            string msg_erro;

            switch(status_code)
            {
                case System.Net.HttpStatusCode.BadRequest:
                    msg_erro = "A requisição não pode ser atendida agora. Tente mais tarde.";
                    break;

                case System.Net.HttpStatusCode.NotFound:
                    msg_erro = "Recurso indisponível no momento. Tente mais tarde.";
                    break;

                case System.Net.HttpStatusCode.InternalServerError:
                    msg_erro = "Nosso banco de dados está indisponível. Tente mais tarde.";
                    break;

                case System.Net.HttpStatusCode.RequestTimeout:
                    msg_erro = "O servidor está demorando muito para responder. Tente novamente.";
                    break;

                case System.Net.HttpStatusCode.Forbidden:
                    msg_erro = "Recurso temporariamente indisponível. Tente mais tarde.";
                    break;

                default:
                    msg_erro = "Estamos com dificuldade para acessar nosso servidor. Tente mais tarde";
                    break;
            }

            return msg_erro;
        }

        protected static async Task<string> GetDataFromService(string rota)
        {
            string json_response;

            string uri = servidor + rota;

            var current = Connectivity.NetworkAccess;

            if (current != NetworkAccess.Internet)
            {
                throw new Exception("Por favor, conecte-se à internet!");
            }

            using (HttpClient client = new HttpClient()) 
            {
                HttpResponseMessage response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    json_response = response.Content.ReadAsStringAsync().Result;
                }
                else
                {
                    throw new Exception(DecodeServerError(response.StatusCode));
                }
            }

            return json_response;
        }
    }
}
