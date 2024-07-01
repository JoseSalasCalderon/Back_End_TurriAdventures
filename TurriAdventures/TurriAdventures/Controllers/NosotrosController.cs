
using Microsoft.AspNetCore.Mvc;
using Entities.Entities;
using Business.Business;

namespace TurriAdventures.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class NosotrosController : ControllerBase
    {

        private readonly HotelTurriAdventuresContext _context = new HotelTurriAdventuresContext();
        private readonly NosotrosBusinessSql _businessSql = new NosotrosBusinessSql();

        [HttpGet("ListarNosotros")]
        public Task<List<Nosotros>> ListarNosotros()
        {
            return _businessSql.ListarNosotros();
        }

        [HttpGet("BuscarNosotros/{id}")]
        public async Task<Nosotros> BuscarNosotros(int id)
        {
            return _businessSql.BuscarNosotros(id);
        }

        [HttpPost("CrearNosotros")]
        public bool CrearNosotros(Nosotros nosotros)
        {
            return _businessSql.CrearNosotros(nosotros);
        }

        [HttpPut("EditarNosotros")]
        public bool EditarNosotros(Nosotros nosotros)
        {
            return _businessSql.modificarNosotros(nosotros);
        }

        [HttpDelete("EliminarNosotros/{id}")]
        public bool EliminarNosotros(int id)
        {
            return _businessSql.EliminarNosotros(id);
        }
    }
}