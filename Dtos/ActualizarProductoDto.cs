using Microsoft.AspNetCore.Mvc;
using TIENDAAPI.Services;
using TIENDAAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace TIENDAAPI.Dtos{

public class ActualizarProductoDto
{
    [Required]
    public string? Name {get; set;} = string.Empty;

    [Range(1, 100000)]
    public decimal? Precio {get; set;}

    public bool? Activo {get; set;}
}
}