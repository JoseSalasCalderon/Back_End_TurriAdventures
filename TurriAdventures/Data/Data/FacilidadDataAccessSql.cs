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

    }
}
