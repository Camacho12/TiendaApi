using Microsoft.AspNetCore.Mvc;
using TIENDAAPI.Services;
using TIENDAAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace TIENDAAPI.Dtos;
public class ProdcutoDto
{
    public int Id {get; set;}
    public string Name {get; set;} = string.Empty;
    public decimal? Precio {get; set;}

    public bool? Activo{get; set;} 
}
