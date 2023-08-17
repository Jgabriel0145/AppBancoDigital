using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

using AppBancoDigital.Model;

namespace AppBancoDigital.Service
{
    public class DataServiceChavePix : DataService
    {
        public static async Task<ChavePix> CadastrarCHavePix(ChavePix chave)
        {
            var json_para_enviar = JsonConvert.SerializeObject(chave);

            string json = await PostDataToService(json_para_enviar, "/chavepix/salvar");

            return JsonConvert.DeserializeObject<ChavePix>(json);
        }

        public static async Task<List<ChavePix>> ListarChavePix()
        {
            string json = await GetDataFromService("/chavepix/listar");

            List<ChavePix> list_chaves = JsonConvert.DeserializeObject<List<ChavePix>>(json);

            return list_chaves;
        }

        public static async Task<List<ChavePix>> ExcluirChavePix(ChavePix chave)
        {
            var json_para_enviar = JsonConvert.SerializeObject(chave);

            string json = await PostDataToService(json_para_enviar, "/chavepix/excluir");

            List<ChavePix> list_chaves = JsonConvert.DeserializeObject<List<ChavePix>>(json);

            return list_chaves;
        }
    }
}
