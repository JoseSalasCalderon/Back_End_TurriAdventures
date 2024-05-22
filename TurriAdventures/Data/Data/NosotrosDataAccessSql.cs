using Entities.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TurriAdventures.Entities;

namespace Data.Data
{
    public class NosotrosDataAccessSql
    {
        HotelTurriAdventuresContext dbContext = new HotelTurriAdventuresContext();

        #region CRUDNosotros
        public async Task<List<Nosotros>> ListarNosotros()
        {
            var nosotros = await dbContext.Nosotros.FromSqlInterpolated($"exec listarNosotros").ToListAsync();
            return nosotros;
        }//ListarNosotros

        public bool CrearNosotros(Nosotros nosotros)
        {
            try
            {
                var parameters = new[]
                {
                new SqlParameter("@descripcionNosotros", nosotros.DescripcionNosotros),
                new SqlParameter("@imagenNosotros", nosotros.ImagenNosotros)
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

        public bool modificarNosotros(Nosotros nosotros)
        {
            try
            {
                var parameters = new[]
                {
                new SqlParameter("@idNosotros", nosotros.IdNosotros),
                new SqlParameter("@descripcionNosotros", nosotros.DescripcionNosotros),
                new SqlParameter("@imagenNosotros", nosotros.ImagenNosotros)
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

    }
}
