
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
        public Task<List<Nosotro>> ListarNosotros()
        {
            return _businessSql.ListarNosotros();
        }

        [HttpGet("BuscarNosotros/{id}")]
        public async Task<Nosotro> BuscarNosotros(int id)
        {
            return _businessSql.BuscarNosotros(id);
        }

        [HttpPost("CrearNosotros")]
        public bool CrearNosotros(Nosotro nosotros)
        {
            return _businessSql.CrearNosotros(nosotros);
        }

        [HttpPut("EditarNosotros")]
        public bool EditarNosotros(Nosotro nosotros)
        {
            return _businessSql.modificarNosotros(nosotros);
        }

        //[HttpDelete("EliminarNosotros")]
        //public bool EliminarNosotros(int id)
        //{
        //    return _businessSql.EliminarNosotros(id);
        //}
    }
}