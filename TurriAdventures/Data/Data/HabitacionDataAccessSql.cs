using Entities.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TurriAdventures.Entities;

namespace Data.Data
{
    public class HabitacionDataAccessSql
    {
        HotelTurriAdventuresContext dbContext = new HotelTurriAdventuresContext();

       
        #region CRUDHabitacion
        public async Task<List<Habitacion>> ListarHabitaciones()
        {
            var habitaciones = await dbContext.Habitacion.FromSqlInterpolated($"exec listarHabitacion").ToListAsync();
            return habitaciones;
        }//ListarHabitaciones

        public bool CrearHabitacion(int estadoHabitacion, int numeroHabitacion, int capacidadMaxima, int idTipoHabitacion)
        {
            try
            {
                var parameters = new[]
                {
                new SqlParameter("@estadoHabitacion", estadoHabitacion),
                new SqlParameter("@numeroHabitacion", numeroHabitacion),
                new SqlParameter("@capacidadMaxima", capacidadMaxima),
                new SqlParameter("@idTipoHabitacion", idTipoHabitacion)
                };

                // Ejecutar un comando SQL personalizado
                dbContext.Database.ExecuteSqlRawAsync("exec crearHabitacion @estadoHabitacion, @numeroHabitacion, @capacidadMaxima, @idTipoHabitacion", parameters);

                return true; // Operación exitosa
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir
                return false; // Operación fallida
            }
        }//CrearHabitacion

        public Habitacion BuscarHabitacion(int idHabitacion)
        {
            var parameters = new[]
            {
                new SqlParameter("@IdHabitacion", idHabitacion)
            };

            // Ejecutar el procedimiento almacenado y obtener la habitacion
            var habitacionObtenida = dbContext.Habitacion.FromSqlRaw("exec buscarHabitacionPorID @IdHabitacion", parameters).AsEnumerable().FirstOrDefault();

            if (habitacionObtenida == null)
            {
                // Manejar el caso donde no se encontró ninguna habitacion
                return null;
            }

            // Crear una nueva instancia de habitacion y asignarle las propiedades conocidas
            var habitacionCreada = new Habitacion
            {
                IdHabitacion = habitacionObtenida.IdHabitacion, 
                EstadoHabitacion = habitacionObtenida.EstadoHabitacion,
                NumeroHabitacion = habitacionObtenida.NumeroHabitacion,
                CapacidadMaxima = habitacionObtenida.CapacidadMaxima,
                IdTipoHabitacion = habitacionObtenida.IdTipoHabitacion,
            };

            return habitacionCreada;
        }//BuscarHabitacion

        public Habitacion BuscarHabitacionPorIdReserva(int idReserva)
        {
            var parameters = new[]
            {
                new SqlParameter("@IdReserva", idReserva)
            };

            // Ejecutar el procedimiento almacenado y obtener la habitacion
            var habitacionObtenida = dbContext.Habitacion.FromSqlRaw("exec buscarHabitacionPorReserva @IdReserva", parameters).AsEnumerable().FirstOrDefault();

            if (habitacionObtenida == null)
            {
                // Manejar el caso donde no se encontró ninguna habitacion
                return null;
            }

            // Crear una nueva instancia de habitacion y asignarle las propiedades conocidas
            var habitacionCreada = new Habitacion
            {
                IdHabitacion = habitacionObtenida.IdHabitacion,
                EstadoHabitacion = habitacionObtenida.EstadoHabitacion,
                NumeroHabitacion = habitacionObtenida.NumeroHabitacion,
                CapacidadMaxima = habitacionObtenida.CapacidadMaxima,
                IdTipoHabitacion = habitacionObtenida.IdTipoHabitacion,
            };

            return habitacionCreada;
        }//BuscarHabitacion        

        public List<Habitacion> ConsultarDisponibilidadHabitaciones(string fechaLlegada, string fechaSalida, int tipo_habitacion_id)
        {
            var parameters = new[]
            {
        new SqlParameter("@tipo_habitacion_id", tipo_habitacion_id),
        new SqlParameter("@fechaLlegada", fechaLlegada),
        new SqlParameter("@fechaSalida", fechaSalida)
    };

            // Ejecutar el procedimiento almacenado y obtener la lista de habitaciones
            var habitacionesObtenidas = dbContext.Habitacion
                .FromSqlRaw("exec consultarDisponibilidadHabitaciones @fechaLlegada, @fechaSalida, @tipo_habitacion_id", parameters)
                .AsEnumerable()
                .Select(habitacionObtenida => new Habitacion
                {
                    IdHabitacion = habitacionObtenida.IdHabitacion,
                    EstadoHabitacion = habitacionObtenida.EstadoHabitacion,
                    NumeroHabitacion = habitacionObtenida.NumeroHabitacion,
                    CapacidadMaxima = habitacionObtenida.CapacidadMaxima,
                    IdTipoHabitacion = habitacionObtenida.IdTipoHabitacion,
                    
                })
                .ToList();

            return habitacionesObtenidas;
        }

        public bool EditarHabitacion(int idHabitacion, int estadoHabitacion, int numeroHabitacion, int capacidadMaxima, int idTipoHabitacion)
        {
            try
            {
                var parameters = new[]
                {
                    new SqlParameter("@idHabitacion", idHabitacion),
                    new SqlParameter("@estadoHabitacion", estadoHabitacion),
                    new SqlParameter("@numeroHabitacion", numeroHabitacion),
                    new SqlParameter("@capacidadMaxima", capacidadMaxima),
                    new SqlParameter("@idTipoHabitacion", idTipoHabitacion)
                };

                // Ejecutar un comando SQL personalizado
                dbContext.Database.ExecuteSqlRawAsync("exec modificarHabitacion @idHabitacion, @estadoHabitacion, @numeroHabitacion, @capacidadMaxima, @idTipoHabitacion", parameters);

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
