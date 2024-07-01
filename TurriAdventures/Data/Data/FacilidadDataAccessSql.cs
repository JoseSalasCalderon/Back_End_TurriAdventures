using Entities.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Data.Data
{
    public class FacilidadDataAccessSql
    {
        HotelTurriAdventuresContext dbContext = new HotelTurriAdventuresContext();

        #region CRUDFacilidad
        public async Task<List<Facilidad>> ListarFacilidades()
        {
            var facilidades = await dbContext.Facilidad.FromSqlInterpolated($"exec listarFacilidades").ToListAsync();
            return facilidades;
        }//ListarTipoHabitaciones

        public bool CrearFacilidad(Facilidad facilidad)
        {
            try
            {
                var parameters = new[]
                {
                new SqlParameter("@descripcionFacilidad", facilidad.DescripcionFacilidad),
                new SqlParameter("@imagenFacilidad", facilidad.ImagenFacilidad)
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

        public Facilidad BuscarFacilidad(int idFacilidad)
        {
            var parameters = new[]
            {
                new SqlParameter("@idFacilidad", idFacilidad)
            };

            // Ejecutar el procedimiento almacenado y obtener la habitacion
            var facilidad = dbContext.Facilidad.FromSqlRaw("exec buscarFacilidad @idFacilidad", parameters).AsEnumerable().FirstOrDefault();

            if (facilidad == null)
            {
                // Manejar el caso donde no se encontró ninguna habitacion
                return null;
            }

            // Crear una nueva instancia de habitacion y asignarle las propiedades conocidas
            var Facilidad = new Facilidad
            {
                DescripcionFacilidad = facilidad.DescripcionFacilidad,
                ImagenFacilidad = facilidad.ImagenFacilidad
            };

            return Facilidad;
        }//Temporada

        public bool modificarFacilidad(Facilidad facilidad)
        {
            try
            {
                var parameters = new[]
                {
                    new SqlParameter("@id", facilidad.IdFacilidad),
                    new SqlParameter("@descripcionFacilidad", facilidad.DescripcionFacilidad),
                    new SqlParameter("@imagenFacilidad", facilidad.ImagenFacilidad)
                };

                // Ejecutar un comando SQL personalizado
                dbContext.Database.ExecuteSqlRawAsync("exec modificarFacilidad @id, @descripcionFacilidad, @imagenFacilidad ", parameters);

                return true; // Operación exitosa
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir
                return false; // Operación fallida
            }
        }//EditarHabitacion

        public bool EliminarFacilidad(int idFacilidad)
        {
            try
            {
                var parameters = new[]
                {
                    new SqlParameter("@idFacilidad", idFacilidad)
                };

                dbContext.Database.ExecuteSqlRawAsync("exec eliminarFacilidad @idFacilidad", parameters);

                return true; // Operación exitosa
            }
            catch (Exception ex)
            {
                return false; // Operación fallida
            }
        }//EliminarFacilidad


        #endregion

    }
}
