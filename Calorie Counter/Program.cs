using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

public class Food
{
    public string? Description { get; set; }
    public string? PortionSize { get; set; }
    public int Calories { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        string fileName = "fooddata.json";
        List<Food>? foods = new List<Food>();
        if (File.Exists(fileName))
        {
            string jsonText = File.ReadAllText(fileName);
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            foods = JsonSerializer.Deserialize<List<Food>>(jsonText, options);
        }
        else Console.WriteLine("Database not found!");

        Console.WriteLine("Hello, search for any food you'd like! Type 'exit' to exit the program.");
        Console.Write("Search: ");
        string? search = SearchInput();
        do
        {



        } while (search?.ToLower() != "exit");
    }

    public static string? SearchInput()
    {
        Console.Write("Insert the food you want: ");
        string? food = Console.ReadLine();
        while (float.TryParse(food, out float i) || string.IsNullOrWhiteSpace(food))
        {
            Console.Write("Input cant be null or a number. Try again: ");
            food = Console.ReadLine();
        }
        return food;
    }
}
