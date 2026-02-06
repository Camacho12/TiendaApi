using Microsoft.AspNetCore.Mvc;
using TIENDAAPI.Services;
using TIENDAAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace TIENDAAPI.Dtos;
public class CrearProductoDto
{
    [Required]
    public string Name {get; set;} = null!;
    [Range(1, 100000)]
    public decimal? Precio {get; set;}


}

