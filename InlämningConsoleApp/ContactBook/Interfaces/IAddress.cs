
namespace ContactBook.Interfaces;

public interface IAddress
{
    string? StreetName { get; set; }
    string? StreetNumber { get; set; }
    string? City { get; set; }
    string? PostalCode { get; set; }
    


    string? FullAddress { get; }
}
