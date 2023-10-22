
using ContactBook.Interfaces;
using ContactBook.Models;
using Newtonsoft.Json;

namespace ContactBook.Services;

public class FileService
{
    private static readonly string filePath = @"C:\Nackademin\Inlämning-C#\persons.json";

    public static List<Person> ReadDataFromFile()
    {
        try
        {
            if (File.Exists(filePath))
            {
                string jsonData = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<List<Person>>(jsonData)!;             
            }
            else
            {
                return new List<Person>();           
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while reading data from file: " + ex.Message);
            return new List<Person>();
        }
    }

    public static void WriteDataToFile(List<Person> persons)
    {
        try
        {
            string jsonData = JsonConvert.SerializeObject(persons, Formatting.Indented);
            File.WriteAllText(filePath, jsonData);
            Console.WriteLine("Data written to file successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while writing data to file: " + ex.Message);
        }
    }
}
