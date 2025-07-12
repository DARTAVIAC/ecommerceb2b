using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using EcommerceB2C.Data;

public class ProductService
{
    private readonly HttpClient _http;

    public ProductService(HttpClient http)
    {
        _http = http;

        if (!_http.DefaultRequestHeaders.UserAgent.Any())
        {
            _http.DefaultRequestHeaders.UserAgent.Add(
                new ProductInfoHeaderValue("EcommerceB2CApp", "1.0"));
        }
    }

    public async Task<List<Product>> GetProductsAsync()
    {
        return await _http.GetFromJsonAsync<List<Product>>("https://fakestoreapi.com/products");
    }
}
