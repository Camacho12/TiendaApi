using Microsoft.AspNetCore.Mvc;
using TIENDAAPI.Services;
using TIENDAAPI.Models;
using System.ComponentModel.DataAnnotations;
using TIENDAAPI.Controllers;

namespace TIENDAAPI.Dtos
{
    public class CrearUsuarioDto
    {
        public string Email {get; set;}= null!;
        public string Password{get; set;}= null!;
    }
}