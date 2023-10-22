
using ContactBook.Models;

namespace ContactBook.Interfaces;

public interface IPerson
{
    string Email { get; set; }
    string FirstName { get; set; }
    string LastName { get; set; }
    
    IAddress Address { get; set; }
    string PhoneNumber { get; set; }
    string FullInfo { get; }
}
