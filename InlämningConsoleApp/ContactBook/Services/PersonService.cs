
using ContactBook.Interfaces;
using ContactBook.Models;
using System.Collections.ObjectModel;

namespace ContactBook.Services;

public class PersonService 
{
    private List<Person> _listOfPersons = new List<Person>();

    public PersonService()
    {
        
    }

    public PersonService(List<Person> listFromFile)
    {
        _listOfPersons = listFromFile;
    }

    public void CreatePerson(Person person)
    {
        try
        {

            _listOfPersons.Add(person);

            FileService.WriteDataToFile(_listOfPersons);
            //_listOfPersons.Add(new Person()
            //{
            //    FirstName = person.FirstName,
            //    LastName = person.LastName,
            //    Email = person.Email,
            //});
        }
        catch { }
    }

    public List<Person> GetAll()
    {
        return _listOfPersons;
    }
    public Person SearchPerson(string email)
    {
        try
        {
            var person = _listOfPersons.FirstOrDefault(x => x.Email == email.Trim());
            return person!;
        }
        catch (Exception ex) { Console.WriteLine(ex.Message); }
        return null!;
    }
    public void RemovePerson(string email)
    {
        try
        {
            var person = SearchPerson(email);
            _listOfPersons.Remove(person);
            FileService.WriteDataToFile(_listOfPersons);
        }
        catch (Exception ex) { Console.WriteLine(ex.Message); }
        
    }

}
