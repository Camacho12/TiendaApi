using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using TIENDAAPI.Dtos;
using TIENDAAPI.Data;

namespace TIENDAAPI.Models{
public class Producto
{
    public int Id {get; set;}
    public string Name {get; set;} = string.Empty;
    public decimal? Precio {get; set;} 

    public bool Activo {get; set;} = true;

}
}