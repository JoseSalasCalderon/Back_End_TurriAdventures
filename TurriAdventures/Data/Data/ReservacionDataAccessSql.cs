using Entities.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TurriAdventures.Entities;

namespace Data.Data
{
    public class ReservacionDataAccessSql
    {
        HotelTurriAdventuresContext dbContext = new HotelTurriAdventuresContext();

        #region CRUDReservacion
        public async Task<List<Reservacion>> ListarReservas()
        {
            var reservas = await dbContext.Reservacion.FromSqlInterpolated($"exec listarReservaciones").ToListAsync();
            return reservas;
        }//ListarReservaciones

        public int CrearReserva(Reservacion reservacion)
        {
            try
            {
                var parameters = new[]
                {
               // new SqlParameter("@idReservacion", reservacion.IdReservacion),
                new SqlParameter("@fechaLlegada", reservacion.FechaLlegada),
                new SqlParameter("@fechaSalida", reservacion.FechaSalida),
                new SqlParameter("@estadoReservacion", reservacion.EstadoReservacion),
                new SqlParameter("@idHabitacion", reservacion.IdHabitacion),
                new SqlParameter ("@idCliente", reservacion.IdCliente)
                };

                var idReservacion = dbContext.Database.ExecuteSqlRawAsync(
                    "exec crearReservacion @fechaLlegada, @fechaSalida, @estadoReservacion, @idHabitacion, @idCliente", parameters).ToString;

                /*// Ejecutar un comando SQL personalizado
                var idReservacion = dbContext.Reservacion
            .FromSqlRaw("exec crearReservacion @fechaLlegada, @fechaSalida, @estadoReservacion, @idHabitacion, @idCliente; SELECT SCOPE_IDENTITY();", parameters)
            .AsEnumerable()
            .FirstOrDefault();*/

                return Convert.ToInt32(idReservacion); // Operación exitosa
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir
                return -1; // Operación fallida
            }
        }//CrearReserva

        public Reservacion BuscarReservaPorIdCliente(String idCliente)
        {
            var parameters = new[]
            {
                new SqlParameter("@idCliente", idCliente)
            };

            // Ejecutar el procedimiento almacenado y obtener la habitacion
            var reserva = dbContext.Reservacion.FromSqlRaw("exec buscarReservacionIdCliente @idCliente", parameters).AsEnumerable().FirstOrDefault();

            if (reserva == null)
            {
                // Manejar el caso donde no se encontró ninguna habitacion
                return null;
            }

            // Crear una nueva instancia de habitacion y asignarle las propiedades conocidas
            var reservacion = new Reservacion
            {
                IdHabitacion = reserva.IdHabitacion,
                EstadoReservacion = reserva.EstadoReservacion,
                FechaLlegada = reserva.FechaLlegada,
                FechaSalida = reserva.FechaSalida,
                IdCliente = reserva.IdCliente,
                IdReservacion = reserva.IdReservacion

            };

            return reservacion;
        }//Temporada

        public bool modificarReserva(Reservacion reservacion)
        {
            try
            {
                var parameters = new[]
                {
                new SqlParameter("@fechaLlegada", reservacion.FechaLlegada),
                new SqlParameter("@fechaSalida", reservacion.FechaSalida),
                new SqlParameter("@estadoReservacion", reservacion.EstadoReservacion),
                new SqlParameter("id", reservacion.IdHabitacion),
                };

                // Ejecutar un comando SQL personalizado
                dbContext.Database.ExecuteSqlRawAsync("exec crearReservacion @fechaLlegada, @fechaSalida, @estadoReservacion, @id", parameters);

                return true; // Operación exitosa
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir
                return false; // Operación fallida
            }
        }//EditarHabitacion

        public bool EliminarReserva(int idReserva)
        {
            try
            {
                var parameters = new[]
                {
                    new SqlParameter("@IdOferta", idReserva)
                };

                dbContext.Database.ExecuteSqlRawAsync("exec eliminarReservacion @IdOferta", parameters);

                return true; // Operación exitosa
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir
                return false; // Operación fallida
            }

        }//EliminarOferta

        #endregion

      }
}
