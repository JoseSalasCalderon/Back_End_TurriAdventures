using Entities.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Data.Data
{
    public class ClienteDataAccessSql
    {
        HotelTurriAdventuresContext dbContext = new HotelTurriAdventuresContext();

        #region CRUDCliente
        public async Task<List<Cliente>> ListarClientes()
        {
            var habitaciones = await dbContext.Cliente.FromSqlInterpolated($"exec listarClientes").ToListAsync();
            return habitaciones;
        }//ListarClientes

        public bool CrearCliente(Cliente cliente )
        {
            try
            {
                var parameters = new[]
                {
                new SqlParameter("@idCliente", cliente.IdCliente),
                new SqlParameter("@nombre", cliente.Nombre),
                new SqlParameter("@apellidos", cliente.Apellidos),
                new SqlParameter("@email", cliente.Email)
                };

                // Ejecutar un comando SQL personalizado
                dbContext.Database.ExecuteSqlRawAsync("exec crearCliente @idCliente, @nombre, @apellidos, @email", parameters);

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
        }//BuscarCliente

        public Cliente BuscarClientePorIdReserva(int idReserva)
        {
            var parameters = new[]
            {
                new SqlParameter("@IdReserva", idReserva)
            };

            // Ejecutar el procedimiento almacenado y obtener la habitacion
            var cliente = dbContext.Cliente.FromSqlRaw("exec buscarClientePorIdReservacion @IdReserva", parameters).AsEnumerable().FirstOrDefault();

            if (cliente == null)
            {
                // Manejar el caso donde no se encontró ninguna habitacion
                return null;
            }

            // Crear una nueva instancia de habitacion y asignarle las propiedades conocidas
            var clienteCreado = new Cliente
            {
                IdCliente = cliente.IdCliente,
                Nombre = cliente.Nombre,
                Apellidos = cliente.Apellidos,
                Email = cliente.Email
            };

            return clienteCreado;
        }//BuscarClientePorIdReserva

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
        }//EditarCliente


        #endregion

    }
}
