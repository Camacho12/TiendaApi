using Microsoft.AspNetCore.Mvc;
using TIENDAAPI.Models;
using TIENDAAPI.Dtos;
using TIENDAAPI.Controllers;
using TIENDAAPI.Data;
using Microsoft.EntityFrameworkCore;
using TIENDAAPI.Services;

namespace TIENDAAPI.Services
{
    public class TicketService
    {
        private readonly AppDbContext _context;
        public TicketService(AppDbContext context)
        {
            _context = context;
        }

        public TicketDto Crear(CrearTicketDto dto)
        {
            var ticket = new Ticket
            {
                Titulo = dto.Titulo,
                Descripcion = dto.Descripcion,
                Area = dto.Area,
                FechaSolicitud = DateTime.Now
            };

            _context.Tickets.Add(ticket);
            _context.SaveChanges();
            return new TicketDto
            {
                Id = ticket.Id,
                Titulo = ticket.Titulo,
                Descripcion = ticket.Descripcion,
                Area = ticket.Area,
                FechaSolicitud = ticket.FechaSolicitud
            };
        }

        public List<TicketDto> ObtenerTodos()
        {
            return _context.Tickets.Select(t => new TicketDto
            {
                Id = t.Id,
                Titulo = t.Titulo,
                Descripcion = t.Descripcion,
                FechaSolicitud = t.FechaSolicitud,
                Area = t.Area
            }).ToList();
        }
    }
}