using System.ComponentModel.DataAnnotations;

public class AddressBook
{
    
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Street {get ; set;}
    [Required]
    public int StreetNo { get; set; }
    [Required]
    public string City { get; set; }
    [Required]
    [EmailAddress]
    public string Email {get; set;}
    public string? PhoneNumber { get; set; }
}