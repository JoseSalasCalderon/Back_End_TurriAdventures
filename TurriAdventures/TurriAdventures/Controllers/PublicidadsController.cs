using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Entities.Entities;
using Business.Business;

namespace TurriAdventures.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicidadsController : ControllerBase
    {

        private readonly HotelTurriAdventuresContext _context = new HotelTurriAdventuresContext();
        private readonly PublicidadBusinessSql _businessSql = new PublicidadBusinessSql();

        private readonly string _imageFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");

        public PublicidadsController(){
            if (!Directory.Exists(_imageFolderPath))
            {
                Directory.CreateDirectory(_imageFolderPath);
            }
        }
        [HttpPost("SubirImagen")]
        public async Task<IActionResult> SubirImagen(IFormFile imagen)
        {
            if (imagen == null || imagen.Length == 0)
            {
                return BadRequest("No se ha proporcionado una imagen.");
            }

            var fileName = Path.GetRandomFileName() + Path.GetExtension(imagen.FileName);
            var filePath = Path.Combine(_imageFolderPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await imagen.CopyToAsync(stream);
            }

            var imageUrl = $"/images/{fileName}";
            return Ok(new { nombreImagen = fileName, urlImagen = imageUrl });
        }

        [HttpGet("ListarPublicidades")]
        public Task<List<Publicidad>> ListarPublicidades()
        {
            return _businessSql.ListarPublicidades();
        }

        [HttpGet("BuscarPublicidad/{idPublicidad}")]
        public async Task<Publicidad> BuscarPublicidad(int idPublicidad)
        {
            return _businessSql.BuscarPublicidad(idPublicidad);
        }

        [HttpGet("BuscarPublicidadPorNombre/{nombrePublicidad}")]
        public async Task<Publicidad> BuscarPublicidadPorNombre(String nombrePublicidad)
        {
            return _businessSql.BuscarPublicidadPorNombre(nombrePublicidad);
        }

        [HttpPost("CrearPublicidad")]
        public bool CrearPublicidad(Publicidad publicidad)
        {
            return _businessSql.CrearPublicidad(publicidad);
        }

        [HttpPut("EditarPublicidad")]
        public bool EditarAdministrador(Publicidad publicidad)
        {
            return _businessSql.modificarPublicidad(publicidad);
        }

        [HttpDelete("EliminarPublicidad/{idPublicidad}")]
        public bool EliminarPublicidad(int idPublicidad)
        {
            return _businessSql.EliminarPublicidad(idPublicidad);
        }
    }
}
