using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

using AppBancoDigital.Model;
using Newtonsoft.Json;

namespace AppBancoDigital.Service
{
    public class DataServiceConta : DataService
    {
        public static async Task<Conta> ProcurarContaCorrente(Model.Correntista correntista)
        {
            var post_json = JsonConvert.SerializeObject(correntista);

            Console.WriteLine("__________________________________________________________________");
            Console.WriteLine("ID_CORRENTISTA: ");
            Console.WriteLine(post_json);
            Console.WriteLine("__________________________________________________________________");

            string json = await DataService.PostDataToService(post_json, "/conta/searchcorrente");

            Conta conta = JsonConvert.DeserializeObject<Conta>(json);

            Console.WriteLine("__________________________________________________________________");
            Console.WriteLine("CONTA CORRENTE: ");
            Console.WriteLine(conta);
            Console.WriteLine("__________________________________________________________________");

            return conta;
        }

        public async static Task<Conta> ProcurarContaPoupanca(Model.Correntista correntista)
        {
            var post_json = JsonConvert.SerializeObject(correntista);

            Console.WriteLine("__________________________________________________________________");
            Console.WriteLine("Dados digitados em JSON: ");
            Console.WriteLine(post_json);
            Console.WriteLine("__________________________________________________________________");

            string json = await DataService.PostDataToService(post_json, "/conta/searchpoupanca");

            Conta conta = JsonConvert.DeserializeObject<Conta>(json);

            return conta;
        }

        public async static Task<List<Conta>> ProcurarContas(Model.Correntista correntista)
        {
            var post_json = JsonConvert.SerializeObject(correntista);

            string json = await DataService.PostDataToService(post_json, "/conta/searchcontas");

            Console.WriteLine("--------------------JSON DATASERVICECONTA ----------------------------");
            Console.WriteLine(json);
            Console.WriteLine("-------------------------------------------------------------------------");

            List<Conta> list_contas = JsonConvert.DeserializeObject<List<Conta>>(json);

            Console.WriteLine("--------------------LIST CONTAS DATASERVICE ----------------------------");
            Console.WriteLine(list_contas);
            Console.WriteLine("-------------------------------------------------------------------------");

            return list_contas;
        }
    }
}
