

using ContactBook.Models;
using ContactBook.Services;
using Xunit;
using Moq;

namespace ContactBook.Tests;

public class PersonServiceTest
{
    [Fact]
    public void CreatePerson_ShouldAddPersonToList()
    {
        // Arrange
        var persons = new List<Person>();
        var personService = new PersonService(persons);

        var newPerson = new Person
        {
            FirstName = "Kalle",
            LastName = "Karlsson",
            Email = "kalle@domain.com",
            PhoneNumber = "1234567890",          
        };

        // Act
        personService.CreatePerson(newPerson);

        // Assert
        Assert.Single(persons);
        Assert.Equal(newPerson, persons[0]);
    }

}
