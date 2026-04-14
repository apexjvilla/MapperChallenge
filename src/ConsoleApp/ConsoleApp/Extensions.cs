using System.Text.Json;

namespace ConsoleApp
{
    public static class Extensions
    {
        // Create method to serialize objects to json format with identation
        public static string ToJson(this Object obj) =>
            JsonSerializer.Serialize(obj, new System.Text.Json.JsonSerializerOptions
            {
                WriteIndented = true
            });
    }
}
