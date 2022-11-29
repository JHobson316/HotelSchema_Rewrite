﻿using Microsoft.AspNetCore.Mvc.ModelBinding;
using HotelSchema_Rewrite.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelSchema_Rewrite.Models.Interfaces
{
  public interface IUser
  {
    public Task<UserDto> Register(RegisterUserDto data, ModelStateDictionary modelState);
    public Task<UserDto> Authenticate(string username, string password);
  }
}
