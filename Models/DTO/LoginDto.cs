using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelSchema_Rewrite.Models.DTO
{
  public class LoginDto
  {
        [Key]
      [Required]
      public string Username { get; set; }

      [Required]
      public string Password { get; set; }
  }
}
