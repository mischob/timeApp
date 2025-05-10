using System.Net.Http.Json;

namespace TimeTracker.Client.Services;

public class HttpClientService
{
    private readonly string _baseUrl;
    private readonly HttpClient _httpClient;

    public HttpClientService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _baseUrl = configuration["ApiUrl"] ?? "http://localhost:5000";
    }

    public async Task<T?> GetAsync<T>(string endpoint)
    {
        var response = await _httpClient.GetAsync($"{_baseUrl}/{endpoint}");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<T>();
    }

    public async Task<T?> PostAsync<T>(string endpoint, object data)
    {
        var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}/{endpoint}", data);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<T>();
    }

    public async Task PutAsync(string endpoint, object data)
    {
        var response = await _httpClient.PutAsJsonAsync($"{_baseUrl}/{endpoint}", data);
        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteAsync(string endpoint)
    {
        var response = await _httpClient.DeleteAsync($"{_baseUrl}/{endpoint}");
        response.EnsureSuccessStatusCode();
    }
}