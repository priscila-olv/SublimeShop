using SublimeShop.Models.DTOs;
using System.Net;
using System.Net.Http.Json;

namespace SublimeShop.Web.Services
{
    public class CarrinhoService : ICarrinhoService
    {
        private readonly HttpClient httpClient;

        public CarrinhoService()
        {
            this.httpClient = httpClient;
        }
        public async Task<CarrinhoProdutoDTO> AdicionaItens(CarrinhoProdutoAdicionaDto carrinhoProdutoAdicionaDto)
        {
            try
            {
                var response = await httpClient
                    .PostAsJsonAsync<CarrinhoProdutoAdicionaDto>("api/CarrinhoCompra", carrinhoProdutoAdicionaDto);
                if (response.IsSuccessStatusCode)
                {
                    if(response.StatusCode == HttpStatusCode.NoContent)
                    {
                        return default(CarrinhoProdutoDTO);
                    }
                    return await response.Content.ReadFromJsonAsync<CarrinhoProdutoDTO>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"{ response.StatusCode } Mensagem: { message }");
                }
              
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<List<CarrinhoProdutoDTO>> GetItens(string usuarioId)
        {
            try
            {
                var response = await httpClient.GetAsync($"api/Carrinho/{usuarioId}/GetProdutos");

                if (response.IsSuccessStatusCode)
                {
                    if(response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<CarrinhoProdutoDTO>().ToList();
                    }
                    return await response.Content.ReadFromJsonAsync<List<CarrinhoProdutoDTO>>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http Status Code: {response.StatusCode} Mensagem: {message}");
                }
            }
            catch(Exception ex)
            {
                throw;
            }
        }

       
    }
}
