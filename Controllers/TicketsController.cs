using Microsoft.AspNetCore.Mvc;
using TIENDAAPI.Services;
using TIENDAAPI.Models;
using  TIENDAAPI.Dtos;
using TIENDAAPI.Controllers;

namespace TIENDAAPI.Controllers

{
    [ApiController]
    [Route("api/tickets")]
    public class TicketsController : ControllerBase
    {
        private readonly TicketService _service;
        public  TicketsController(TicketService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Crear([FromBody] CrearTicketDto dto)
        {
            var ticket = _service.Crear(dto);
            return CreatedAtAction(nameof(Crear), ticket);
        }
    }
}
   