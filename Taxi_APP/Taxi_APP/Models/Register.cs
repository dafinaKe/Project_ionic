using System.ComponentModel.DataAnnotations;

public class Register
{
    [Required]
    public string Email { get; set; }

    [Required]
    public string UserName { get; set; }

    [Required]
    public string PhoneNumber { get; set; }

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    public string City { get; set; }

    [Required]
    public string Country { get; set; }

    [Required]
    public DateTime? Birthday { get; set; }

    [Required]
    public string Address { get; set; }

    [Required, MinLength(6)]
    public string Password { get; set; }
}
