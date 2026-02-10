using Microsoft.AspNetCore.Mvc;
using TIENDAAPI.Services;
using TIENDAAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace TIENDAAPI.Dtos
{
    public class LoginDto
    {
        public string Email{get; set;}= null!;
        public string Password{get; set;}= null!;
    }
}