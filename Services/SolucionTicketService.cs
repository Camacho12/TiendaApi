using Microsoft.AspNetCore.Mvc;
using TIENDAAPI.Models;
using TIENDAAPI.Dtos;
using TIENDAAPI.Controllers;
using TIENDAAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace TIENDAAPI.Services
{
    public class SolucionTicketService
    {
        
        private readonly AppDbContext _context;
        public SolucionTicketService(AppDbContext context)
        {
            _context = context;
        }

//SERVICE/SolucionTicketService.cs
        public async Task<bool> SolucionTicket(int id, SolucionTicketDto dto)
        {
            var solucionado = await _context.Tickets.FindAsync(id);
            if(solucionado.Estatus != "Resuelto")
                solucionado.Solucion = dto.Solucion;
                solucionado.Estatus = "Resuelto";
                await _context.SaveChangesAsync();
                return true;

            return false;
        }

    }
}