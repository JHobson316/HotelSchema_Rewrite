using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelSchema_Rewrite.Models.DTO
{
  public class RegisterUserDto
  {
        [Key]
    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; }
  }
}
