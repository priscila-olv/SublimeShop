using SublimeShop.Models.DTOs;
using System.Net;
using System.Net.Http.Json;

namespace SublimeShop.Web.Services
{
    public class ProdutoService : IProdutoService
    {
        public HttpClient _httpClient { get; set; }
        public ILogger<ProdutoService> _logger;

        public ProdutoService(HttpClient httpClient, ILogger<ProdutoService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<IEnumerable<ProdutoDTO>> GetAll()
        {
            var produtosDto = await _httpClient.GetFromJsonAsync<IEnumerable<ProdutoDTO>>("api/produtos");

            return produtosDto;
        }

        public async Task<ProdutoDTO> GetById(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/produtos/{id}");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.NoContent)
                    {
                        return default(ProdutoDTO);
                    }
                    return await response.Content.ReadFromJsonAsync<ProdutoDTO>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    _logger.LogError($"Erro a obter produto pelo id= {id} - {message}");
                    throw new Exception($"Status Code : {response.StatusCode} - {message}");
                }
            }
            catch (Exception)
            {
                _logger.LogError($"Erro a obter produto pelo id={id}");
                throw;
            }
        }
    }
}
