using Entities.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Data.Data
{
    public class ContactoDataAccessSql
    {
        HotelTurriAdventuresContext dbContext = new HotelTurriAdventuresContext();

        #region CRUDContacto
        public async Task<List<Contacto>> ListarContactos()
        {
            var contactos = await dbContext.Contactos.FromSqlInterpolated($"exec listarContactos").ToListAsync();
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
