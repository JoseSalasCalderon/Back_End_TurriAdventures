using Entities.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Data.Data
{
    public class AdministradorDataAccessSql
    {
        HotelTurriAdventuresContext dbContext = new HotelTurriAdventuresContext();

        #region CRUDAdministrador
        public async Task<List<Administrador>> ListarAdministradores()
        {
            var habitaciones = await dbContext.Administrador.FromSqlInterpolated($"exec listarAdministradores").ToListAsync();
            return habitaciones;
        }//ListarAdministradores

        public bool CrearAdministrador(Administrador administrador)
        {
            try
            {
                var parameters = new[]
                {
                new SqlParameter("@usuario", administrador.Usuario),
                new SqlParameter("@contrasena", administrador.Contrasena)
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

        public Administrador BuscarAdministrador(String usuario)
        {
            var parameters = new[]
            {
                new SqlParameter("@usuario", usuario)
            };

            // Ejecutar el procedimiento almacenado y obtener la habitacion
            var administrador = dbContext.Administrador.FromSqlRaw("exec buscarAdministradorPorUsuario @usuario", parameters).AsEnumerable().FirstOrDefault();

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
        }//BuscarAdministrador

        public bool ModificarAdministrador(Administrador administrador)
        {
            try
            {
                var parameters = new[]
                {
                new SqlParameter("@idAdministrador", administrador.IdAdministrador),
                new SqlParameter("@usuario", administrador.Usuario),
                new SqlParameter("@contrasena", administrador.Contrasena)
                };

                // Ejecutar un comando SQL personalizado
                dbContext.Database.ExecuteSqlRawAsync("exec modificarAdministrador @idAdministrador, @usuario, @contrasena ", parameters);

                return true; // Operación exitosa
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir
                return false; // Operación fallida
            }
        }//ModificarAdministrador

        public bool EliminarAdministrador(int idAdministrador)
        {
            try
            {
                var parameters = new[]
                {
                     new SqlParameter("@idAdministrador", idAdministrador)
                 };

                dbContext.Database.ExecuteSqlRawAsync("exec eliminarAdministrador @idAdministrador", parameters);

                return true; // Operación exitosa
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir
                return false; // Operación fallida
            }

        }//EliminarAdministrador
        #endregion

        }
}
