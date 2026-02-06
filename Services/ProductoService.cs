using Microsoft.AspNetCore.Mvc;
using TIENDAAPI.Models;
using TIENDAAPI.Dtos;
using TIENDAAPI.Controllers;
using TIENDAAPI.Data;
using Microsoft.EntityFrameworkCore;


namespace TIENDAAPI.Services;
public class ProductoService
{

    private readonly AppDbContext _context;

    public ProductoService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<ProdcutoDto>> ObtenerTodos()
    {
        return await _context.Productos.Select(p => new ProdcutoDto
        {
            Id = p.Id,
            Name = p.Name,
            Precio = p.Precio,
            
        }).ToListAsync();
    }

    public async Task<ProdcutoDto?> ObtenerPorId(int id)
    {
        return await _context.Productos.Where(p => p.Id == id && p.Activo).Select(p => new ProdcutoDto
        {
            Id = p.Id,
            Name = p.Name,
            Precio = p.Precio
        }).FirstOrDefaultAsync();
        
    }

    public async Task<ProdcutoDto> Crear(CrearProductoDto dto)
    {
        var producto = new Producto
        {
            Name = dto.Name,
            Precio = dto.Precio

        };
        _context.Productos.Add(producto);
        await _context.SaveChangesAsync();

        return new ProdcutoDto
        {
             Name = dto.Name,
             Precio = dto.Precio
        };
        
    }

    public async Task<bool> Eliminar(int id)
    {
        var producto = await _context.Productos.FindAsync(id);
        if (producto == null || ! producto.Activo)
            return false;

        _context.Productos.Remove(producto);
        await _context.SaveChangesAsync();
        
        return true;
    }

    public async Task<bool> Actualizar(int id, ActualizarProductoDto dto)
    {
        var producto = await _context.Productos.FindAsync(id);
        if(producto == null)
            return false;

        if (dto.Name != null)
            producto.Name = dto.Name;

        if (dto.Precio.HasValue)
            producto.Precio = dto.Precio.Value;

        if(dto.Activo.HasValue)
            producto.Activo = dto.Activo.Value;

        await _context.SaveChangesAsync();
        return true;
    }
 /*   private readonly List<Producto> _productos = new();
    private int _id = 1;

    public List<ProdcutoDto> ObtenerTodos()
        {
            return _productos.Select(p => new ProdcutoDto
            {
                Id = p.Id,
                Name = p.Name,
                Precio = p.Precio
            }).ToList();
        }

        public  ProdcutoDto? ObtenerPorId(int id)
        {
            var producto = _productos.FirstOrDefault(p => p.Id == id);

            if (producto == null)
                return null;
            
            return new ProdcutoDto
            {
                Id = producto.Id,
                Name = producto.Name,
                Precio = producto.Precio
            };    
            
        }


        public void Crear(CrearProductoDto dto)
        {
            var producto = new Producto
            {
                Id = _id++,
                Name = dto.Name,
                Precio = dto.Precio
            };

            _productos.Add(producto);
        }

        public bool Actualizar(int id, ActualizarProductoDto dto)
        {
            var producto = _productos.FirstOrDefault(p => p.Id == id);

                if (producto == null)
                    return false;

                producto.Name = dto.Name;
                producto.Precio = dto.Precio;
                return true;
        }

        public bool Eliminar(int id)
        {
            var producto = _productos.FirstOrDefault(p => p.Id == id);

            if(producto == null)
                return false;

            _productos.Remove(producto);
            return true;
        }

        */
}
