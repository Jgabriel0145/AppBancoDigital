using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

using AppBancoDigital.Model;

namespace AppBancoDigital.Service
{
    public class DataServiceCorrentista : DataService
    {
        public static async Task<List<Correntista>> GetCorrentistaAsync()
        {
            string json = await GetDataFromService("/correntista");

            List<Correntista> list_correntista = JsonConvert.DeserializeObject<List<Correntista>>(json);

            return list_correntista;
        }

        public static async Task<Correntista> CadastrarCorrentista(Correntista correntista)
        {
            var json_para_enviar = JsonConvert.SerializeObject(correntista);

            string json = await PostDataToService(json_para_enviar, "/correntista/save");

            Correntista correntista2 = JsonConvert.DeserializeObject<Correntista>(json);

            return correntista2;
        }

        public static async Task<List<Correntista>> SearchAsync(string query)
        {
            var json_para_enviar = JsonConvert.SerializeObject(query);

            string json = await PostDataToService(json_para_enviar, "/correntista/search");

            List<Correntista> list_correntista = JsonConvert.DeserializeObject<List<Correntista>>(json);

            return list_correntista;
        }

        public static async Task<List<Correntista>> DeleteAsync(int id)
        {
            var json_para_enviar = JsonConvert.SerializeObject(id);

            string json = await PostDataToService(json_para_enviar, "/correntista/delete");

            List<Correntista> list_correntista = JsonConvert.DeserializeObject<List<Correntista>>(json);

            return list_correntista;
        }
    }
}
