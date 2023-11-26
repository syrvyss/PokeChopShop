using System.Text;
using System.Text.Json;

namespace WebAppBlazor.Services;

public class HttpHelper
{
    private readonly HttpClient _httpClient;

    public HttpHelper(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<T> GetAsync<T>(string url)
    {
        var response = await _httpClient.GetAsync(url);

        if (!response.IsSuccessStatusCode) response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();

        var result = JsonSerializer.Deserialize<T>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        return result;
    }

    public async Task PutAsync<T>(string url, T data)
    {
        var jsonData = JsonSerializer.Serialize(data);
        var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

        var response = await _httpClient.PutAsync(url, content);
        if (!response.IsSuccessStatusCode) response.EnsureSuccessStatusCode();
    }

    public async Task PostAsync<T>(string url, T data)
    {
        var jsonData = JsonSerializer.Serialize(data);
        var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync(url, content);

        if (!response.IsSuccessStatusCode) response.EnsureSuccessStatusCode();
    }

    public async Task DeleteAsync(string url)
    {
        var response = await _httpClient.DeleteAsync(url);

        if (!response.IsSuccessStatusCode) response.EnsureSuccessStatusCode();
    }
}