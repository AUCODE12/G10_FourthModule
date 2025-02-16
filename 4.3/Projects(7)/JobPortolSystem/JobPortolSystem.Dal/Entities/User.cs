using JobPortolSystem.Dal.Enums;
using System.ComponentModel.DataAnnotations;

namespace JobPortolSystem.Dal.Entities;

public class User
{
    public long UserId { get; set; }
    public string Name { get; set; }
    [EmailAddress]
    public string Email { get; set; }
    public UserRole UserRole { get; set; }
}
