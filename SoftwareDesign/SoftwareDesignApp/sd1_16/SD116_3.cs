namespace SoftwareDesign.sd1_16;

using System;
using System.Collections.Generic;
using System.Text.Json;


/// <summary>
/// result только внутри try блока
/// Строковые ключи напрямую зависят от формата json файла
/// </summary>
public class SD116_3
{
    public static void Run()
    {
        const string jsonString = """
                                  {
                                    "name": "John",
                                    "age": 30
                                  }
                                  """;

        try
        {
            var result = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(jsonString);

            if (result is null)
            {
                Console.WriteLine("JSON contains null.");
                return;
            }

            Console.WriteLine($"Name: {result["name"].GetString()}");

            var prettyJson = JsonSerializer.Serialize(result, new JsonSerializerOptions
                {
                    WriteIndented = true
                }
            );

            Console.WriteLine("Pretty JSON:");
            Console.WriteLine(prettyJson);
        }
        catch (JsonException exception)
        {
            Console.WriteLine($"JSON parsing error: {exception.Message}");
        }
    }
}