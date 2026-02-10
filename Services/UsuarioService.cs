using Microsoft.AspNetCore.Mvc;
using TIENDAAPI.Models;
using TIENDAAPI.Dtos;
using TIENDAAPI.Controllers;
using TIENDAAPI.Data;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Identity;
using System.Runtime.Intrinsics.Arm;
using TIENDAAPI.Services;



namespace TIENDAAPI.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly AppDbContext _context;
        public UsuarioService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Usuario> CrearUsuarioAsync(CrearUsuarioDto dto)
        {
            if(await _context.Usuarios.AnyAsync(u=> u.Email == dto.Email))
                throw new Exception("El usuario ya existe");

            
            
            var usuario = new Usuario
            {
                Email = dto.Email,
                PasswordHash = HashPassword(dto.Password)
            };
        _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario?> LoginAsync(LoginDto dto)
        {
            var usuario =  await _context.Usuarios.SingleOrDefaultAsync(u=> u.Email == dto.Email);
            if(usuario == null)
                return null;

            
            return VerifyPassword(dto.Password, usuario.PasswordHash) 
                    ? usuario : null; 
            
        }
        
        private string HashPassword(string password)
        {
            using var sha = SHA256.Create();
            var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }

        private bool VerifyPassword(string password, string hash)
        {
            return HashPassword(password) == hash;
        }

    
    }
}