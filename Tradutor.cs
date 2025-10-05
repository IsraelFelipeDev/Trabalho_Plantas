using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace App_Plantas.Services
{
    public class TradutorService
    {
        private const string API_URL = "https://api.mymemory.translated.net/get";

        public async Task<string> TraduzirAsync(string texto, string idiomaOrigem, string idiomaDestino)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // A MyMemory usa parâmetros na URL (GET)
                    string url = $"{API_URL}?q={Uri.EscapeDataString(texto)}&langpair={idiomaOrigem}|{idiomaDestino}";

                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();

                    string responseBody = await response.Content.ReadAsStringAsync();
                    dynamic jsonResponse = JsonConvert.DeserializeObject(responseBody);

                    // A resposta da MyMemory tem uma estrutura diferente
                    if (jsonResponse?.responseData?.translatedText != null)
                    {
                        return jsonResponse.responseData.translatedText;
                    }
                }
            }
            catch (HttpRequestException e)
            {
                // Se a API falhar, imprime o erro no console
                Console.WriteLine($"Erro na requisição HTTP: {e.Message}");
            }
            catch (Exception ex)
            {
                // Para outros erros (ex.: na desserialização do JSON)
                Console.WriteLine($"Erro ao processar a tradução: {ex.Message}");
            }

            // Em caso de falha, retorne o texto original
            return texto;
        }
    }
}
