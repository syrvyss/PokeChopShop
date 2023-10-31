using System.Runtime.InteropServices.JavaScript;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Data.Utility;

public static class Sprite
{
    public static async Task<string?> GetSprite(string url)
    {
        using var client = new HttpClient();
        var response = await client.GetAsync(url);

        if (!response.IsSuccessStatusCode)
            return "";

        var content = await response.Content.ReadAsStringAsync();
        var img = JsonNode.Parse(content)!;

        return (string)img!["sprites"]!["front_default"];
    }
}