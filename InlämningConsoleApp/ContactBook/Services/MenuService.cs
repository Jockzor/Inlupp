
using ContactBook.Interfaces;
using ContactBook.Models;

namespace ContactBook.Services;

public class MenuService
{
    
    static PersonService personService = new(FileService.ReadDataFromFile());
    
    public void MainMenu()
    {         
        while (true)
        {

            Console.WriteLine("1. Add Person\n2. Show all\n3. Search specific person" +
                "\n4. Remove person\n5. Exit");
            Console.Write("Enter an option: ");
            string option = Console.ReadLine()!;

            switch (option)
            {
                case "1":
                    AddPersonMenu();
                    break;
                case "2":
                    ShowAllMenu();
                    break;
                case "3":
                    SearchSpecificPersonMenu();
                    break;
                case "4":
                    RemovePerson();
                    break;
                case "5":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Wrong input.");
                    break;
            }
            Console.ReadKey();
            Console.Clear();
        }
    }
    public void AddPersonMenu()
    {
        Console.Clear();
        try
        {
            while (true)
            {
                Person iPerson = new Person();
                Console.Write("Firstname: ");
                iPerson.FirstName = Console.ReadLine()!;
                Console.Write("Lastname: ");
                iPerson.LastName = Console.ReadLine()!;
                Console.Write("Phonenumber: ");
                iPerson.PhoneNumber = Console.ReadLine()!;
                Console.Write("Email: ");
                iPerson.Email = Console.ReadLine()!;

                iPerson.Address = new Address();
                Console.Write("Streetname: ");
                iPerson.Address.StreetName = Console.ReadLine()!;
                Console.Write("Streetnumber: ");
                iPerson.Address.StreetNumber = Console.ReadLine()!;
                Console.Write("City: ");
                iPerson.Address.City = Console.ReadLine()!;
                Console.Write("Postalcode: ");
                iPerson.Address.PostalCode = Console.ReadLine()!;


                personService.CreatePerson(iPerson);
                Console.WriteLine("Person was created.");
                break;
            }

        }
        catch (Exception ex) { Console.WriteLine(ex.Message); }
    }

    public void ShowAllMenu()
    {
        Console.Clear();
        try
        {
            Console.WriteLine("All persons:\n-------------------");
            if (personService.GetAll().Count() is not 0)
            {
                foreach (var person in personService.GetAll())
                    Console.WriteLine(person.FullInfo + " " + person.Address.FullAddress);
            }
            else
                Console.WriteLine("No persons are added yet.");
        }
        catch (Exception ex) { Console.WriteLine(ex.Message); };
    }

    public void SearchSpecificPersonMenu()
    {
        Console.Clear();
        try
        {
            Console.Write("Enter email for the person you want to search for: ");
            string email = Console.ReadLine()!;
            var person = personService.SearchPerson(email);
            if (person is null)
                Console.WriteLine($"Could not find person with email <{email}>");
            else
                Console.WriteLine($"{person.FullInfo} {person.Address.FullAddress}");
        }
        catch (Exception ex) { Console.WriteLine( ex.Message); };
    }
    public void RemovePerson()
    {
        Console.Clear();
        try
        {

            Console.Write("Email: ");
            string email = Console.ReadLine()!;
            var person = personService.SearchPerson(email);
            if (person is null)
                Console.WriteLine($"Could not find person with email <{email}>");
            else
            {
                personService.RemovePerson(email);
                Console.WriteLine($"{person.FirstName} {person.LastName} was removed.");
            }
        }
        catch (Exception ex) { Console.WriteLine(ex.Message); };
    }

}
