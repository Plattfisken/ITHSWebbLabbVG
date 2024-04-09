using System.Net.Http.Json;
using labbVG.Client.Interfaces;
using labbVG.Client.Models;

namespace labbVG.Client.Classes;
public class DataAccessCall : IDataAccess
{   
    private readonly HttpClient _httpClient;
    public DataAccessCall(HttpClient httpClient)
    {
        _httpClient = httpClient;   
    }
    public async Task<List<Product>> GetUserCart(string userId)
    {
        var response = await _httpClient.GetFromJsonAsync<List<Product>>($"/fetch-cart/{userId}");
        return response;
    }
}
