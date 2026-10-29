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

    public void PrintFood()
    {
        Console.WriteLine($"{Description} | {PortionSize} | {Calories} calories");
    }
}

class Program
{
    static void Main(string[] args)
    {
        string fileName = "fooddata.json";
        string? search;
        int counter = 0;
        List<Food>? foods = new List<Food>();

        if (File.Exists(fileName))
        {
            string jsonText = File.ReadAllText(fileName);
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            foods = JsonSerializer.Deserialize<List<Food>>(jsonText, options);
        }
        else
        {
            Console.WriteLine("Database not found!");
            return;
        }

        Console.WriteLine("Hello, search for any food you'd like! Type 'exit' to exit the program.");
        do
        {
            search = SearchInput();
            foreach(var food in foods)
            {
                if (food.Description.ToLower().Contains(search.ToLower()))
                {
                    counter++;
                    Console.Write($"{counter}. ");
                    food.PrintFood();
                    if (counter % 25 == 0)
                    {
                        Console.Write("Press 'M' to show other results: ");
                        string? choice = SearchInput();
                        if (choice?.ToLower() == "m") continue;
                        else break;
                    }
                }
            }
            if(search.ToLower() == "exit")
            {
                Console.WriteLine("Exiting the program...");
                return;
            }
            if (counter == 0) Console.WriteLine("No food found");

            counter = 0;
            
        } while (search?.ToLower() != "exit");
    }

    public static string? SearchInput()
    {
        Console.Write("Search: ");
        string? food = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(food))
        {
            Console.Write("Input cant be empty. Try again: ");
            food = Console.ReadLine();
        }
        return food;
    }
}
