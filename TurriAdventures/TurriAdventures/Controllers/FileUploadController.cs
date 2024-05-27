using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;

namespace TurriAdventures.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        private readonly string _destinationFolderPath;

        public FileUploadController(IWebHostEnvironment hostingEnvironment)
        {
            _destinationFolderPath = Path.Combine(hostingEnvironment.ContentRootPath, "..", "..", "..", "..", "..", "Front_End_TurriAdventures", "TurriAdventures", "src", "assets", "Habitaciones");
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            try
            {
                if (file == null || file.Length == 0)
                {
                    return BadRequest("No se ha enviado ningún archivo o el archivo está vacío.");
                }

                // Combinar la ruta de destino con el nombre de archivo original
                var filePath = Path.Combine(_destinationFolderPath, file.FileName);

                // Copiar el archivo al destino
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                return Ok(new { message = "Archivo copiado con éxito." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
    }
}
