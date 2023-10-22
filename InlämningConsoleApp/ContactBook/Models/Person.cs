
using ContactBook.Interfaces;

namespace ContactBook.Models;

public class Person 
{
    private string firstName = null!;
    private string lastName = null!;
    private string email = null!;
    private string passWord = null!;
    private string phoneNumber = null!;

    public string FirstName { get => firstName; set => firstName = value.Trim(); }
    public string LastName { get => lastName; set => lastName = value.Trim(); }
    public string Email { get => email; set => email = value.Trim(); }
    public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
    public Address Address { get; set; } = null!;
    public string PassWord { get => passWord; set => passWord = value; }
    public string FullInfo { get => $"{FirstName} {LastName} {PhoneNumber} <{Email}>"; }

}
