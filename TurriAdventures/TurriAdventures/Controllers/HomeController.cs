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
    public class HomeController : ControllerBase
    {

        private readonly HotelTurriAdventuresContext _context = new HotelTurriAdventuresContext();
        private readonly HomeBusinessSql _businessSql = new HomeBusinessSql();

        private readonly string _imageFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");

        public HomeController(){
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

        [HttpGet("ListarHomes")]
        public Task<List<Home>> ListarHomes()
        {
            return _businessSql.ListarHomes();
        }

        [HttpGet("BuscarHome/{idHome}")]
        public async Task<Home> BuscarHome(int idHome)
        {
            return _businessSql.BuscarHome(idHome);
        }

        [HttpPost("CrearHome")]
        public bool CrearHome(Home home)
        {
            return _businessSql.CrearHome(home);
        }

        [HttpPut("EditarHome")]
        public bool EditarHome(Home home)
        {
            return _businessSql.modificarHome(home);
        }

        [HttpDelete("EliminarHome/{idHome}")]
        public bool EliminarHome(int idHome)
        {
            return _businessSql.EliminarHome(idHome);
        }
    }
}
