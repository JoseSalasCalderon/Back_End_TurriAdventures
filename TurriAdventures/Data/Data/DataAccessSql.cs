using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurriAdventures.Entities;

namespace Data.Data
{
    public class DataAccessSql
    {
        HotelTurriAdventuresContext dbContext = new HotelTurriAdventuresContext();

        #region CRUDOferta
        public async Task<List<Oferta>> ListarOfertas()
        {
            var ofertas = await dbContext.Oferta.FromSqlInterpolated($"exec listarOfertas").ToListAsync();
            return ofertas;
        }



        #endregion
    }
}
