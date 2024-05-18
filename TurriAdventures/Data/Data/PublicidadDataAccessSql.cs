using Entities.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TurriAdventures.Entities;

namespace Data.Data
{
    public class PublicidadDataAccessSql
    {
        HotelTurriAdventuresContext dbContext = new HotelTurriAdventuresContext();

        #region CRUDPublicidad
        public async Task<List<Publicidad>> ListarPublicidades()
        {
            var publicidades = await dbContext.Publicidad.FromSqlInterpolated($"exec listarPublicidades").ToListAsync();
            return publicidades;
        }//ListarPublicidades

        public bool CrearPublicidad(Publicidad publicidad)
        {
            try
            {
                var parameters = new[]
                {
                new SqlParameter("@nombrePublicidad", publicidad.NombrePublicidad),
                new SqlParameter("@imagenPublicidad", publicidad.ImagenPublicidad),
                new SqlParameter("@linkPublicidad", publicidad.LinkPublicidad)
                };

                // Ejecutar un comando SQL personalizado
                dbContext.Database.ExecuteSqlRawAsync("exec crearPublicidad @nombrePublicidad, @imagenPublicidad, @linkPublicidad", parameters);

                return true; // Operación exitosa
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir
                return false; // Operación fallida
            }
        }//CrearPublicidad

        public Publicidad BuscarPublicidad(int idPublicidad)
        {
            var parameters = new[]
            {
                new SqlParameter("@idPublicidad", idPublicidad)
            };

            var publicidad = dbContext.Publicidad.FromSqlRaw("exec buscarPublicidad @idPublicidad", parameters).AsEnumerable().FirstOrDefault();

            if (publicidad == null)
            {
                // Manejar el caso donde no se encontró ninguna 
                return null;
            }

            // Crear una nueva instancia de Publicidad y asignarle las propiedades conocidas
            var Publicidad = new Publicidad
            {
                IdPublicidad = publicidad.IdPublicidad,
                NombrePublicidad = publicidad.NombrePublicidad,
                ImagenPublicidad = publicidad.ImagenPublicidad,
                LinkPublicidad = publicidad.LinkPublicidad
            };

            return Publicidad;
        }//BuscarPublicidad

        public Publicidad BuscarPublicidadPorNombre(String nombrePublicidad)
        {
            var parameters = new[]
            {
                new SqlParameter("@nombrePublicidad", nombrePublicidad)
            };

            var publicidad = dbContext.Publicidad.FromSqlRaw("exec buscarPublicidadPorNombre @nombrePublicidad", parameters).AsEnumerable().FirstOrDefault();

            if (publicidad == null)
            {
                // Manejar el caso donde no se encontró ninguna 
                return null;
            }

            // Crear una nueva instancia de Publicidad y asignarle las propiedades conocidas
            var Publicidad = new Publicidad
            {
                IdPublicidad = publicidad.IdPublicidad,
                NombrePublicidad = publicidad.NombrePublicidad,
                ImagenPublicidad = publicidad.ImagenPublicidad,
                LinkPublicidad = publicidad.LinkPublicidad
            };

            return Publicidad;
        }//BuscarPublicidad

        public bool ModificarPublicidad(Publicidad publicidad)
        {
            try
            {
                var parameters = new[]
                {
                new SqlParameter("@idPublicidad", publicidad.IdPublicidad),
                new SqlParameter("@nombrePublicidad", publicidad.NombrePublicidad),
                new SqlParameter("@imagenPublicidad", publicidad.ImagenPublicidad),
                new SqlParameter("@linkPublicidad", publicidad.LinkPublicidad)
                };

                // Ejecutar un comando SQL personalizado
                dbContext.Database.ExecuteSqlRawAsync("exec modificarPublicidad @idPublicidad,@nombrePublicidad, @imagenPublicidad, @linkPublicidad ", parameters);

                return true; // Operación exitosa
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir
                return false; // Operación fallida
            }
        }//ModificarPublicidad

        public bool EliminarPublicidad(int idPublicidad)
        {
            try
            {
                var parameters = new[]
                {
                     new SqlParameter("@idPublicidad", idPublicidad)
                 };

                dbContext.Database.ExecuteSqlRawAsync("exec eliminarPublicidad @idPublicidad", parameters);

                return true; // Operación exitosa
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir
                return false; // Operación fallida
            }

        }//EliminarPublicidad
        #endregion

    }
}
