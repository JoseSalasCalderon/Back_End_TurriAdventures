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
    public class DireccionDataAccessSql
    {
        HotelTurriAdventuresContext dbContext = new HotelTurriAdventuresContext();

        #region CRUDDireccion

        public async Task<List<Direccion>> ListarDirecciones()
        {
            var direcciones = await dbContext.Direccion.FromSqlInterpolated($"exec listarDirecciones").ToListAsync();
            return direcciones;
        }

        public bool CrearDireccion(Direccion direccion)
        {
            try
            {
                var parameters = new[]
                {
                    new SqlParameter("@InformacionDireccion", direccion.InformacionDireccion)
                };

                // Ejecutar un comando SQL personalizado
                dbContext.Database.ExecuteSqlRawAsync("exec crearDireccion @InformacionDireccion", parameters);

                return true; // Operación exitosa
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir
                return false; // Operación fallida
            }
        }

        public Direccion BuscarDireccion(int idDireccion)
        {
            var parameters = new[]
            {
                new SqlParameter("@IdDireccion", idDireccion)
            };

            // Ejecutar el procedimiento almacenado y obtener la dirección
            var direccion = dbContext.Direccion.FromSqlRaw("exec buscarDireccion @IdDireccion", parameters).AsEnumerable().FirstOrDefault();

            if (direccion == null)
            {
                // Manejar el caso donde no se encontró ninguna dirección
                return null;
            }

            return direccion;
        }

        public async Task<bool> EditarDireccion(int idDireccion, string informacionDireccion)
        {
            try
            {
                var parameters = new[]
                {
            new SqlParameter("@IdDireccion", idDireccion),
            new SqlParameter("@InformacionDireccion", informacionDireccion)
        };

                // Ejecutar el comando SQL de manera asincrónica y esperar el resultado
                var result = await dbContext.Database.ExecuteSqlRawAsync("exec modificarDireccion @IdDireccion, @InformacionDireccion", parameters);

                // Verificar si se afectaron filas en la base de datos
                return result > 0; // Retorna true si se afectaron filas en la base de datos
            }
            catch (Exception ex)
            {
                // Manejar la excepción de manera adecuada (registrarla, lanzarla nuevamente, etc.)
                Console.WriteLine($"Error al editar la dirección: {ex.Message}");
                return false; // Operación fallida
            }
        }


        //public bool EliminarDireccion(int idDireccion)
        //{
        //    try
        //    {
        //        var parameters = new[]
        //        {
        //            new SqlParameter("@IdDireccion", idDireccion)
        //        };

        //        // Ejecutar un comando SQL personalizado
        //        dbContext.Database.ExecuteSqlRawAsync("exec eliminarDireccion @IdDireccion", parameters);

        //        return true; // Operación exitosa
        //    }
        //    catch (Exception ex)
        //    {
        //        // Manejar cualquier excepción que pueda ocurrir
        //        return false; // Operación fallida
        //    }
        //}

        #endregion
    }
}
