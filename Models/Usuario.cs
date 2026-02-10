using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using TIENDAAPI.Dtos;
using TIENDAAPI.Data;
using TIENDAAPI.Services;

namespace TIENDAAPI.Models
{
    public class Usuario
    {
        public int Id {get; set;}
        public string Email {get; set;} = null!;
        public string PasswordHash {get; set;} = null!;
        public string Rol {get; set;} = "User";
    }
}