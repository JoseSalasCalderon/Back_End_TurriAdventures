using Entities.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Data.Data
{
    public class TipoHabitacionDataAccessSql
    {
        HotelTurriAdventuresContext dbContext = new HotelTurriAdventuresContext();

      
        #region CRUDTipoHabitacion
        public async Task<List<TipoHabitacion>> ListarTipoHabitaciones()
        {
            var habitaciones = await dbContext.TipoHabitacion.FromSqlInterpolated($"exec listarTiposHabitacion").ToListAsync();
            return habitaciones;
        }//ListarTipoHabitaciones

        public bool CrearTipoHabitacion(String nombreTipoHabitacion, decimal precio, String descripcionTipoHabitacion,String imagenTipoHabitacion ,int idOferta,int idTemporada)
        {
            try
            {
                var parameters = new[]
                {
                new SqlParameter("@nombreTipoHabitacion", nombreTipoHabitacion),
                new SqlParameter("@precio", precio),
                new SqlParameter("@descripcionTipoHabitacion", descripcionTipoHabitacion),
                new SqlParameter("@imagenTipoHabitacion", imagenTipoHabitacion),
                new SqlParameter("@idOferta", idOferta),
                new SqlParameter("@idTemporada", idTemporada)
                };

                // Ejecutar un comando SQL personalizado
                dbContext.Database.ExecuteSqlRawAsync("exec crearTipoHabitacion @nombreTipoHabitacion, @precio, @descripcionTipoHabitacion, @imagenTipoHabitacion, @idOferta, @idOferta ", parameters);

                return true; // Operación exitosa
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir
                return false; // Operación fallida
            }
        }//CrearTipoHabitacion

        public TipoHabitacion BuscarTipoHabitacion(int idTipoHabitacion)
        {
            var parameters = new[]
            {
                new SqlParameter("@IdHabitacion", idTipoHabitacion)
            };

            // Ejecutar el procedimiento almacenado y obtener la habitacion
            var habitacionObtenida = dbContext.TipoHabitacion.FromSqlRaw("exec buscarTipoHabitacion @IdHabitacion", parameters).AsEnumerable().FirstOrDefault();

            if (habitacionObtenida == null)
            {
                // Manejar el caso donde no se encontró ninguna habitacion
                return null;
            }

            // Crear una nueva instancia de habitacion y asignarle las propiedades conocidas
            var tipoHabitacionCreada = new TipoHabitacion
            {
                IdTipoHabitacion = habitacionObtenida.IdTipoHabitacion, // Aquí puedes asignar el id que recibiste como parámetro
                NombreTipoHabitacion = habitacionObtenida.NombreTipoHabitacion,
                Precio = habitacionObtenida.Precio,
                DescripcionTipoHabitacion = habitacionObtenida.DescripcionTipoHabitacion,
                ImagenTipoHabitacion= habitacionObtenida.ImagenTipoHabitacion,
                IdOferta= habitacionObtenida.IdOferta,
                IdTemporada= habitacionObtenida.IdTemporada
            };

            return tipoHabitacionCreada;
        }//BuscarHabitacion

        public TipoHabitacion BuscarTipoHabitacionPorHabitacion(int idHabitacion)
        {
            var parameters = new[]
            {
                new SqlParameter("@IdHabitacion", idHabitacion)
            };

            // Ejecutar el procedimiento almacenado y obtener la habitacion
            var habitacionObtenida = dbContext.TipoHabitacion.FromSqlRaw("exec buscarTipoHabitacionPorIdHabitacion @IdHabitacion", parameters).AsEnumerable().FirstOrDefault();

            if (habitacionObtenida == null)
            {
                // Manejar el caso donde no se encontró ninguna habitacion
                return null;
            }

            // Crear una nueva instancia de habitacion y asignarle las propiedades conocidas
            var tipoHabitacionCreada = new TipoHabitacion
            {
                IdTipoHabitacion = habitacionObtenida.IdTipoHabitacion, // Aquí puedes asignar el id que recibiste como parámetro
                NombreTipoHabitacion = habitacionObtenida.NombreTipoHabitacion,
                Precio = habitacionObtenida.Precio,
                DescripcionTipoHabitacion = habitacionObtenida.DescripcionTipoHabitacion,
                ImagenTipoHabitacion = habitacionObtenida.ImagenTipoHabitacion,
                IdOferta = habitacionObtenida.IdOferta,
                IdTemporada = habitacionObtenida.IdTemporada
            };

            return tipoHabitacionCreada;
        }//BuscarHabitacion

        public bool EditarTipoHabitacion(TipoHabitacion tipoHabitacion)
        {
            try
            {
                var parameters = new[]
                {
                new SqlParameter("@idHabitacion", tipoHabitacion.IdTipoHabitacion),
                new SqlParameter("@nombreTipoHabitacion", tipoHabitacion.NombreTipoHabitacion),
                new SqlParameter("@precio", tipoHabitacion.Precio),
                new SqlParameter("@descripcionTipoHabitacion", tipoHabitacion.DescripcionTipoHabitacion),
                new SqlParameter("@imagenTipoHabitacion", tipoHabitacion.ImagenTipoHabitacion),
                new SqlParameter("@idOferta", tipoHabitacion.IdOferta),
                new SqlParameter("@idTemporada", tipoHabitacion.IdTemporada)
                };

                // Ejecutar un comando SQL personalizado
                dbContext.Database.ExecuteSqlRawAsync("exec modificarTipoHabitacion @idHabitacion, @nombreTipoHabitacion, @precio, @descripcionTipoHabitacion, @imagenTipoHabitacion,@idOferta,@idOferta ", parameters);

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
