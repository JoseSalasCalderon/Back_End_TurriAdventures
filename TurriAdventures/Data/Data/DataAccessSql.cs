using Entities.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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
        }//ListarOfertas

        public bool CrearOferta(string descripcionOferta, DateTime fechaInicioOferta, DateTime fechaFinalOferta, decimal precioOferta)
        {
            try
            {
                var parameters = new[]
                {
                new SqlParameter("@DescripcionOferta", descripcionOferta),
                new SqlParameter("@FechaInicioOferta", fechaInicioOferta),
                new SqlParameter("@FechaFinalOferta", fechaFinalOferta),
                new SqlParameter("@PrecioOferta", precioOferta)
                };

                // Ejecutar un comando SQL personalizado
                dbContext.Database.ExecuteSqlRawAsync("exec crearOferta @DescripcionOferta, @FechaInicioOferta, @FechaFinalOferta, @PrecioOferta", parameters);

                return true; // Operación exitosa
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir
                return false; // Operación fallida
            }
        }//CrearOferta

        public Oferta BuscarOferta(int idOferta)
        {
            var parameters = new[]
            {
                new SqlParameter("@IdOferta", idOferta)
            };

            // Ejecutar el procedimiento almacenado y obtener la oferta
            var ofertaObtenida = dbContext.Oferta.FromSqlRaw("exec buscarOferta @IdOferta", parameters).AsEnumerable().FirstOrDefault();

            if (ofertaObtenida == null)
            {
                // Manejar el caso donde no se encontró ninguna oferta
                return null;
            }

            // Crear una nueva instancia de Oferta y asignarle las propiedades conocidas
            var ofertaCreada = new Oferta
            {
                IdOferta = idOferta, // Aquí puedes asignar el id que recibiste como parámetro
                DescripcionOferta = ofertaObtenida.DescripcionOferta,
                FechaInicioOferta = ofertaObtenida.FechaInicioOferta,
                FechaFinalOferta = ofertaObtenida.FechaFinalOferta,
                PrecioOferta = ofertaObtenida.PrecioOferta
            };

            return ofertaCreada;
        }//BuscarOferta

        public bool EditarOferta(int idOferta, string descripcionOferta, DateTime fechaInicioOferta, DateTime fechaFinalOferta, decimal precioOferta)
        {
            try
            {
                var parameters = new[]
                {
                new SqlParameter("@IdOferta", idOferta),
                new SqlParameter("@DescripcionOferta", descripcionOferta),
                new SqlParameter("@FechaInicioOferta", fechaInicioOferta),
                new SqlParameter("@FechaFinalOferta", fechaFinalOferta),
                new SqlParameter("@PrecioOferta", precioOferta)
                };

                // Ejecutar un comando SQL personalizado
                dbContext.Database.ExecuteSqlRawAsync("exec modificarOferta @IdOferta, @DescripcionOferta, @FechaInicioOferta, @FechaFinalOferta, @PrecioOferta", parameters);

                return true; // Operación exitosa
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir
                return false; // Operación fallida
            }
        }//EditarOferta

        public bool EliminarOferta(int idOferta)
        {
            try
            {
                var parameters = new[]
                {
                    new SqlParameter("@IdOferta", idOferta)
                };

                dbContext.Database.ExecuteSqlRawAsync("exec eliminarOferta @IdOferta", parameters);

                return true; // Operación exitosa
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir
                return false; // Operación fallida
            }

        }//EliminarOferta

        #endregion
     

        #region CRUDTemporada
        public async Task<List<Temporada>> ListarTemporadas()
        {
            var habitaciones = await dbContext.Temporada.FromSqlInterpolated($"exec listarTemporadas").ToListAsync();
            return habitaciones;
        }//ListarTipoHabitaciones

        public bool CrearTemporada(String descripcionTemporada, DateTime fechaInicioTemporada, DateTime fechaFinalTemporada, decimal precioTemporada)
        {
            try
            {
                var parameters = new[]
                {
                new SqlParameter("@descripcionTemporada", descripcionTemporada),
                new SqlParameter("@fechaInicioTemporada", fechaInicioTemporada),
                new SqlParameter("@fechaFinalTemporada", fechaFinalTemporada),
                new SqlParameter("@precioTemporada", precioTemporada)
                };

                // Ejecutar un comando SQL personalizado
                dbContext.Database.ExecuteSqlRawAsync("exec crearTemporada @descripcionTemporada, @fechaInicioTemporada, @fechaFinalTemporada, @precioTemporada ", parameters);

                return true; // Operación exitosa
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir
                return false; // Operación fallida
            }
        }//CrearTemporada

        public Temporada BuscarTemporada(int idTemporada)
        {
            var parameters = new[]
            {
                new SqlParameter("@IdTemporada", idTemporada)
            };

            // Ejecutar el procedimiento almacenado y obtener la habitacion
            var temporada = dbContext.Temporada.FromSqlRaw("exec buscarTemporada @IdTemporada", parameters).AsEnumerable().FirstOrDefault();

            if (temporada == null)
            {
                // Manejar el caso donde no se encontró ninguna habitacion
                return null;
            }

            // Crear una nueva instancia de habitacion y asignarle las propiedades conocidas
            var TemporadaCreada = new Temporada
            {
                DescripcionTemporada= temporada.DescripcionTemporada,
                FechaInicioTemporada= temporada.FechaInicioTemporada,
                FechaFinalTemporada= temporada.FechaFinalTemporada,
                PrecioTemporada= temporada.PrecioTemporada
            };

            return TemporadaCreada;
        }//Temporada

        public bool EditarTemporada(int idTemporada,String descripcionTemporada, DateTime fechaInicioTemporada, DateTime fechaFinalTemporada, decimal precioTemporada)
        {
            try
            {
                var parameters = new[]
                {
                new SqlParameter("@idTemporada", idTemporada),
                new SqlParameter("@descripcionTemporada", descripcionTemporada),
                new SqlParameter("@fechaInicioTemporada", fechaInicioTemporada),
                new SqlParameter("@fechaFinalTemporada", fechaFinalTemporada),
                new SqlParameter("@precioTemporada", precioTemporada)
                };

                // Ejecutar un comando SQL personalizado
                dbContext.Database.ExecuteSqlRawAsync("exec modificarTemporada idTemporada, @descripcionTemporada, @fechaInicioTemporada, @fechaFinalTemporada, @precioTemporada ", parameters);

                return true; // Operación exitosa
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir
                return false; // Operación fallida
            }
        }//EditarHabitacion


        #endregion

    }
}
