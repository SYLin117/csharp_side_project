using System.ComponentModel.DataAnnotations;

namespace Paring.Core.Entities;

public class User
{
    public int Id { get; set; }

    [MaxLength(50)] public string FirstName { get; set; }

    [MaxLength(50)] public string? MiddleName { get; set; }

    [MaxLength(50)] public string? LastName { get; set; }
    
    [MaxLength(50)] public string? PreferName { get; set; }

    [MaxLength(512)] public string Email { get; set; }
    
    public string Age { get; set; }
    
    [MaxLength(2048)] public string? ImageUrl { get; set; }

    public DateTime CreatedOn { get; set; }
    
    public DateTime? ClosedOn { get; set; }
}