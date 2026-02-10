using Microsoft.AspNetCore.Mvc;
using TIENDAAPI.Services;
using TIENDAAPI.Models;
using System.ComponentModel.DataAnnotations;
using TIENDAAPI.Controllers;
using TIENDAAPI.Dtos;

namespace TIENDAAPI.Dtos
{
    public class CrearTicketDto
    {
        public string Titulo {get; set;} = null!;
        public string Descripcion {get; set;} = null!;
        public string  Area {get; set;} = null!;

    }
}