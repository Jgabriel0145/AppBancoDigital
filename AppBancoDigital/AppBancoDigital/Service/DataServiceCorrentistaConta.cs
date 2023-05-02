using AppBancoDigital.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppBancoDigital.Service
{
    public class DataServiceCorrentistaConta : DataService
    {
        /*public static async Task<Conta> CadastrarConta(CorrentistaConta c)
        {
            var json_para_enviar = JsonConvert.SerializeObject(c);

            string json = await PostDataToService(json_para_enviar, "/conta/cadastro");

            CorrentistaConta c2 = JsonConvert.DeserializeObject<Conta>(json);

            return c2;
        }*/
    }
}
