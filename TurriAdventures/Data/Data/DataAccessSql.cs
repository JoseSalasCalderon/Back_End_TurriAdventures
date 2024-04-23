using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
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

        #region CRUDHabitacion
        public async Task<List<Habitacion>> ListarHabitaciones()
        {
            var habitaciones = await dbContext.Habitacion.FromSqlInterpolated($"exec listarHabitacion").ToListAsync();
            return habitaciones;
        }//ListarOfertas

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

        public bool EditarTipoHabitacion(int idHabitacion, String nombreTipoHabitacion, decimal precio, String descripcionTipoHabitacion, String imagenTipoHabitacion, int idOferta, int idTemporada)
        {
            try
            {
                var parameters = new[]
                {
                new SqlParameter("@idHabitacion", idHabitacion),
                new SqlParameter("@nombreTipoHabitacion", nombreTipoHabitacion),
                new SqlParameter("@precio", precio),
                new SqlParameter("@descripcionTipoHabitacion", descripcionTipoHabitacion),
                new SqlParameter("@imagenTipoHabitacion", imagenTipoHabitacion),
                new SqlParameter("@idOferta", idOferta),
                new SqlParameter("@idTemporada", idTemporada)
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

        #region CRUDCliente
        public async Task<List<Cliente>> ListarClientes()
        {
            var habitaciones = await dbContext.Cliente.FromSqlInterpolated($"exec listarClientes").ToListAsync();
            return habitaciones;
        }//ListarTipoHabitaciones

        public bool CrearClientes(String cedula,String nombre, String apellidos, String email)
        {
            try
            {
                var parameters = new[]
                {
                new SqlParameter("@cedula", cedula),
                new SqlParameter("@nombre", nombre),
                new SqlParameter("@apellidos", apellidos),
                new SqlParameter("@email", email)
                };

                // Ejecutar un comando SQL personalizado
                dbContext.Database.ExecuteSqlRawAsync("exec crearCliente @cedula, @nombre, @apellidos, @email", parameters);

                return true; // Operación exitosa
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir
                return false; // Operación fallida
            }
        }//CrearCliente

        public Cliente BuscarCliente(String idCliente)
        {
            var parameters = new[]
            {
                new SqlParameter("@IdCliente", idCliente)
            };

            // Ejecutar el procedimiento almacenado y obtener la habitacion
            var cliente = dbContext.Cliente.FromSqlRaw("exec buscarCliente @IdCliente", parameters).AsEnumerable().FirstOrDefault();

            if (cliente == null)
            {
                // Manejar el caso donde no se encontró ninguna habitacion
                return null;
            }

            // Crear una nueva instancia de habitacion y asignarle las propiedades conocidas
            var clienteCreado = new Cliente
            {
                IdCliente= cliente.IdCliente,  
                Nombre= cliente.Nombre,
                Apellidos= cliente.Apellidos,
                Email= cliente.Email
            };

            return clienteCreado;
        }//Temporada

        public bool EditarCliente(String id,String nombre, String apellidos, String email)
        {
            try
            {
                var parameters = new[]
                {
                new SqlParameter("@id", id),
                new SqlParameter("@nombre", nombre),
                new SqlParameter("@apellidos", apellidos),
                new SqlParameter("@email", email)
                };

                // Ejecutar un comando SQL personalizado
                dbContext.Database.ExecuteSqlRawAsync("exec modificarCliente @id, @nombre, @apellidos, @email ", parameters);

                return true; // Operación exitosa
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir
                return false; // Operación fallida
            }
        }//EditarHabitacion


        #endregion

        #region CRUDAdministrador
        public async Task<List<Administrador>> ListarAdministrador()
        {
            var habitaciones = await dbContext.Administrador.FromSqlInterpolated($"exec listarAdministradores").ToListAsync();
            return habitaciones;
        }//ListarTipoHabitaciones

        public bool CrearAdministrador(String usuario, String contrasena)
        {
            try
            {
                var parameters = new[]
                {
                new SqlParameter("@usuario", usuario),
                new SqlParameter("@contrasena", contrasena)
                };

                // Ejecutar un comando SQL personalizado
                dbContext.Database.ExecuteSqlRawAsync("exec crearAdministrador @usuario, @contrasena", parameters);

                return true; // Operación exitosa
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir
                return false; // Operación fallida
            }
        }//CrearAdministrador

        public Administrador BuscarAdministrador(int idAdministrador)
        {
            var parameters = new[]
            {
                new SqlParameter("@idAdministrador", idAdministrador)
            };

            // Ejecutar el procedimiento almacenado y obtener la habitacion
            var administrador = dbContext.Administrador.FromSqlRaw("exec buscarAdministradorPorID @@idAdministrador", parameters).AsEnumerable().FirstOrDefault();

            if (administrador == null)
            {
                // Manejar el caso donde no se encontró ninguna habitacion
                return null;
            }

            // Crear una nueva instancia de habitacion y asignarle las propiedades conocidas
            var Administrador = new Administrador
            {
                  IdAdministrador= administrador.IdAdministrador,
                  Usuario= administrador.Usuario,
                  Contrasena= administrador.Contrasena
            };

            return Administrador;
        }//Temporada

        public bool EditarAdministrador(String usuario, String contrasena)
        {
            try
            {
                var parameters = new[]
                {
                new SqlParameter("@usuario", usuario),
                new SqlParameter("@contrasena", contrasena)
                };

                // Ejecutar un comando SQL personalizado
                dbContext.Database.ExecuteSqlRawAsync("exec modificarAdministrador @usuario, @contrasena ", parameters);

                return true; // Operación exitosa
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir
                return false; // Operación fallida
            }
        }//EditarHabitacion


        #endregion

        #region CRUDFacilidad
        public async Task<List<Facilidad>> ListarFacilidades()
        {
            var facilidades = await dbContext.Facilidad.FromSqlInterpolated($"exec listarFacilidades").ToListAsync();
            return facilidades;
        }//ListarTipoHabitaciones

        public bool CrearFacilidad(String descripcionFacilidad, String imagenFacilidad)
        {
            try
            {
                var parameters = new[]
                {
                new SqlParameter("@descripcionFacilidad", descripcionFacilidad),
                new SqlParameter("@imagenFacilidad", imagenFacilidad)
                };

                // Ejecutar un comando SQL personalizado
                dbContext.Database.ExecuteSqlRawAsync("exec crearFacilidad @descripcionFacilidad, @imagenFacilidad", parameters);

                return true; // Operación exitosa
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir
                return false; // Operación fallida
            }
        }//CrearFacilidad

        public Facilidad BuscarFacilidad(int idAdministrador)
        {
            var parameters = new[]
            {
                new SqlParameter("@idAdministrador", idAdministrador)
            };

            // Ejecutar el procedimiento almacenado y obtener la habitacion
            var facilidad = dbContext.Facilidad.FromSqlRaw("exec buscarFacilidad @idAdministrador", parameters).AsEnumerable().FirstOrDefault();

            if (facilidad == null)
            {
                // Manejar el caso donde no se encontró ninguna habitacion
                return null;
            }

            // Crear una nueva instancia de habitacion y asignarle las propiedades conocidas
            var Administrador = new Facilidad
            {
                DescripcionFacilidad = facilidad.DescripcionFacilidad,
                ImagenFacilidad = facilidad.ImagenFacilidad
            };

            return Administrador;
        }//Temporada

        public bool modificarFacilidad(int idFacilidad, String descripcionFacilidad, String imagenFacilidad)
        {
            try
            {
                var parameters = new[]
                {
                    new SqlParameter("@id", idFacilidad),
                    new SqlParameter("@usuario", descripcionFacilidad),
                    new SqlParameter("@contrasena", imagenFacilidad)
                };

                // Ejecutar un comando SQL personalizado
                dbContext.Database.ExecuteSqlRawAsync("exec modificarFacilidad @id, @usuario, @contrasena ", parameters);

                return true; // Operación exitosa
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir
                return false; // Operación fallida
            }
        }//EditarHabitacion


        #endregion

        #region CRUDNosotros
        public async Task<List<Nosotros>> ListarNosotros()
        {
            var nosotros = await dbContext.Nosotros.FromSqlInterpolated($"exec listarNosotros").ToListAsync();
            return nosotros;
        }//ListarNosotros

        public bool CrearNosotros(String descripcionNosotros, String imagenNosotros)
        {
            try
            {
                var parameters = new[]
                {
                new SqlParameter("@descripcionNosotros", descripcionNosotros),
                new SqlParameter("@imagenNosotros", imagenNosotros)
                };

                // Ejecutar un comando SQL personalizado
                dbContext.Database.ExecuteSqlRawAsync("exec crearNosotros @descripcionNosotros, @imagenNosotros", parameters);

                return true; // Operación exitosa
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir
                return false; // Operación fallida
            }
        }//CrearNosotros

        public Nosotros BuscarNosotros(int idNosotros)
        {
            var parameters = new[]
            {
                new SqlParameter("@idNosotros", idNosotros)
            };

            // Ejecutar el procedimiento almacenado y obtener la habitacion
            var nosotros = dbContext.Nosotros.FromSqlRaw("exec buscarNosotros @idNosotros", parameters).AsEnumerable().FirstOrDefault();

            if (nosotros == null)
            {
                // Manejar el caso donde no se encontró ninguna habitacion
                return null;
            }

            // Crear una nueva instancia de habitacion y asignarle las propiedades conocidas
            var Administrador = new Nosotros
            {
                DescripcionNosotros = nosotros.DescripcionNosotros,
                ImagenNosotros = nosotros.ImagenNosotros
            };

            return Administrador;
        }//Temporada

        public bool modificarNosotros(int idNosotros, String descripcionNosotros, String imagenNosotros)
        {
            try
            {
                var parameters = new[]
                {
                new SqlParameter("@idNosotros", idNosotros),
                new SqlParameter("@descripcionNosotros", descripcionNosotros),
                new SqlParameter("@imagenNosotros", imagenNosotros)
                };

                // Ejecutar un comando SQL personalizado
                dbContext.Database.ExecuteSqlRawAsync("exec modificarNosotros @idNosotros, @descripcionNosotros, @imagenNosotros ", parameters);

                return true; // Operación exitosa
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir
                return false; // Operación fallida
            }
        }//EditarHabitacion

       /* public bool EliminarNosotros(int idNosotros)
        {
            try
            {
                var parameters = new[]
                {
                    new SqlParameter("@idNosotros", idNosotros)
                };

                dbContext.Database.ExecuteSqlRawAsync("exec eliminarNosotros @idNosotros", parameters);

                return true; // Operación exitosa
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir
                return false; // Operación fallida
            }

        }//EliminarNosotros*/

        #endregion

        #region CRUDReservacion
        public async Task<List<Reservacion>> ListarReservas()
        {
            var reservas = await dbContext.Reservacion.FromSqlInterpolated($"exec listarReservaciones").ToListAsync();
            return reservas;
        }//ListarReservaciones

        public bool CrearReserva(DateTime fechaLlegada, DateTime fechaSalida, String estadoReservacion, int idHabitacion, String idCliente)
        {
            try
            {
                var parameters = new[]
                {
                new SqlParameter("@fechaLlegada", fechaLlegada),
                new SqlParameter("@fechaSalida", fechaSalida),
                new SqlParameter("@estadoReservacion", estadoReservacion),
                new SqlParameter("id", idHabitacion),
                new SqlParameter ("idCliente", idCliente)
                };

                // Ejecutar un comando SQL personalizado
                dbContext.Database.ExecuteSqlRawAsync("exec crearReservacion @fechaLlegada, @fechaSalida, @estadoReservacion, @id, @idCliente", parameters);

                return true; // Operación exitosa
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir
                return false; // Operación fallida
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
            var Administrador = new Reservacion
            {
                IdHabitacion = reserva.IdHabitacion,
                EstadoReservacion = reserva.EstadoReservacion,
                FechaLlegada = reserva.FechaLlegada,
                FechaSalida = reserva.FechaSalida,
                IdCliente = reserva.IdCliente,
                IdReservacion = reserva.IdReservacion

            };

            return Administrador;
        }//Temporada

        public bool modificarReserva(DateTime fechaLlegada, DateTime fechaSalida, String estadoReservacion, int idHabitacion, String idCliente)
        {
            try
            {
                var parameters = new[]
                {
                new SqlParameter("@fechaLlegada", fechaLlegada),
                new SqlParameter("@fechaSalida", fechaSalida),
                new SqlParameter("@estadoReservacion", estadoReservacion),
                new SqlParameter("id", idHabitacion),
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

        #region CRUDContacto
        public async Task<List<Contacto>> ListarContactos()
        {
            var contactos = await dbContext.Contacto.FromSqlInterpolated($"exec listarContactos").ToListAsync();
            return contactos;
        }//listarContactos

        public bool CrearContacto(String telefono1, String telefono2, String apartadoPostal, String email)
        {
            try
            {
                var parameters = new[]
                {
                new SqlParameter("@telefono1", telefono1),
                new SqlParameter("@telefono2", telefono2),
                new SqlParameter("@apartadoPostal", apartadoPostal),
                new SqlParameter("@email", email)
                };

                // Ejecutar un comando SQL personalizado
                dbContext.Database.ExecuteSqlRawAsync("exec crearContacto @telefono1, @telefono2,@apartadoPostal, @email", parameters);

                return true; // Operación exitosa
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir
                return false; // Operación fallida
            }
        }//CrearContacto

        public bool modificarContacto(int idContacto, String telefono1, String telefono2, String apartadoPostal, String email)
        {
            try
            {
                var parameters = new[]
                {
                new SqlParameter("@idContacto", idContacto),
                new SqlParameter("@telefono1", telefono1),
                new SqlParameter("@telefono2", telefono2),
                new SqlParameter("@apartadoPostal", apartadoPostal),
                new SqlParameter("@email", email)
                };

                // Ejecutar un comando SQL personalizado
                dbContext.Database.ExecuteSqlRawAsync("exec modificarContacto @idContacto, @telefono1, @telefono2,@apartadoPostal, @email", parameters);

                return true; // Operación exitosa
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir
                return false; // Operación fallida
            }
        }//modificarContacto

        public bool EliminarContacto(int idContacto)
         {
             try
             {
                 var parameters = new[]
                 {
                     new SqlParameter("@idContacto", idContacto)
                 };

                 dbContext.Database.ExecuteSqlRawAsync("exec eliminarContacto @idContacto", parameters);

                 return true; // Operación exitosa
             }
             catch (Exception ex)
             {
                 // Manejar cualquier excepción que pueda ocurrir
                 return false; // Operación fallida
             }

        }//EliminarContacto

        #endregion



    }
}
