using Microsoft.AspNetCore.Mvc;
using TIENDAAPI.Services;
using TIENDAAPI.Models;
using  TIENDAAPI.Dtos;

namespace TIENDAAPI.Controllers{

[ApiController]
[Route("api/[controller]")]

public class ProductosController : ControllerBase
{
    private readonly ProductoService _service;

    public ProductosController(ProductoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var producto = await _service.ObtenerTodos();
            
            return Ok(producto);
        }
    /*    public IActionResult ObtenerTodos()
        {
            return  Ok(_service.ObtenerTodos());
        }
    */
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var producto = await _service.ObtenerPorId(id);
            
            if (producto == null)
                return NotFound();

            return Ok(producto);
        }



    /*    public IActionResult ObtenerPorId(int id)
        {
            if(id <= 0)
                return  BadRequest("Id invalido");

            var producto = _service.ObtenerPorId(id);

            if (producto == null)
                return NotFound();
            
            return Ok(producto);
    
        }
    */ 
        [HttpPost]
        public async Task<IActionResult> Post(CrearProductoDto dto)
        {
            await _service.Crear(dto);
            
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ActualizarProductoDto dto)
        {
            var actualizado = await _service.Actualizar(id, dto);
            if(!actualizado)
                return NotFound();

            return Ok("Prodcuto actualizado correctamente");
        }
             
        
          
    /*    public IActionResult Crear(CrearProductoDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Name))
                return BadRequest("Nombre obligatorio");

            if (dto.Precio <= 0)
                return BadRequest("Precio invalido");

            _service.Crear(dto);

            return Ok();

        }

    */
    /*    [HttpPut]
        public IActionResult Actualizar(int id, ActualizarProductoDto dto)
        {
            if(id <= 0)
                return BadRequest("ID INVALIDO");

            var Actualizado = _service.Actualizar(id, dto);
            if(!Actualizado)
                return NotFound();

            return Ok();

        }
    */
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
         var eliminado = await
         _service.Eliminar(id);
         if(!eliminado)
            return NotFound();

        return Ok();   
        }
    /*    public IActionResult Eliminar(int id)
        {
            if(id <= 0)
                return BadRequest("id invalido");

            var Eliminado = _service.Eliminar(id);
            if(!Eliminado)
                return NotFound();

            return Ok();
        }
    */

}
}