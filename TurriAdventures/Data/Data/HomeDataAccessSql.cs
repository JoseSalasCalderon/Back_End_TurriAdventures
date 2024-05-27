using Entities.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Data.Data
{
    public class HomeDataAccessSql
    {
        HotelTurriAdventuresContext dbContext = new HotelTurriAdventuresContext();

        #region CRUDHome
        public async Task<List<Home>> ListarHomes()
        {
            var homes = await dbContext.Home.FromSqlInterpolated($"exec listarHomes").ToListAsync();
            return homes;
        }//ListarHomes

        public bool CrearHome(Home home)
        {
            try
            {
                var parameters = new[]
                {
                new SqlParameter("@imagenHome", home.ImagenHome),
                new SqlParameter("@descripcionHome", home.DescripcionHome)
                };

                // Ejecutar un comando SQL personalizado
                dbContext.Database.ExecuteSqlRawAsync("exec crearHome @imagenHome, @descripcionHome", parameters);

                return true; // Operación exitosa
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir
                return false; // Operación fallida
            }
        }//CrearHome

        public Home BuscarHome(int idHome)
        {
            var parameters = new[]
            {
                new SqlParameter("@idHome", idHome)
            };

            var home = dbContext.Home.FromSqlRaw("exec buscarHome @idHome", parameters).AsEnumerable().FirstOrDefault();

            if (home == null)
            {
                // Manejar el caso donde no se encontró ninguna 
                return null;
            }

            // Crear una nueva instancia de Home y asignarle las propiedades conocidas
            var Home = new Home
            {
                IdHome = home.IdHome,
                ImagenHome = home.ImagenHome,
                DescripcionHome = home.DescripcionHome
            };

            return Home;
        }//BuscarHome

        public bool ModificarHome(Home home)
        {
            try
            {
                var parameters = new[]
                {
                new SqlParameter("@idHome", home.IdHome),
                new SqlParameter("@imagenHome", home.ImagenHome),
                new SqlParameter("@descripcionHome", home.DescripcionHome)
                };

                // Ejecutar un comando SQL personalizado
                dbContext.Database.ExecuteSqlRawAsync("exec modificarHome @idHome, @imagenHome, @descripcionHome ", parameters);

                return true; // Operación exitosa
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir
                return false; // Operación fallida
            }
        }//ModificarHome

        public bool EliminarHome(int idHome)
        {
            try
            {
                var parameters = new[]
                {
                     new SqlParameter("@idHome", idHome)
                 };

                dbContext.Database.ExecuteSqlRawAsync("exec eliminarHome @idHome", parameters);

                return true; // Operación exitosa
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir
                return false; // Operación fallida
            }

        }//EliminarHome
        #endregion

    }
}
