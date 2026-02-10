using Microsoft.AspNetCore.Mvc;
using TIENDAAPI.Models;
using TIENDAAPI.Dtos;
using TIENDAAPI.Controllers;
using TIENDAAPI.Data;
using Microsoft.EntityFrameworkCore;
using TIENDAAPI.Services;

namespace TIENDAAPI.Services
{
    public interface IUsuarioService
    {
        Task<Usuario> CrearUsuarioAsync(CrearUsuarioDto dto);
        Task<Usuario?> LoginAsync(LoginDto dto);
    }
}