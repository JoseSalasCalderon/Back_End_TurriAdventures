using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data
{
    public class TemporadaDataAccessSql
    {
        HotelTurriAdventuresContext dbContext = new HotelTurriAdventuresContext();

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
                IdTemporada = temporada.IdTemporada,
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
                dbContext.Database.ExecuteSqlRawAsync("exec modificarTemporada @idTemporada, @descripcionTemporada, @fechaInicioTemporada, @fechaFinalTemporada, @precioTemporada ", parameters);

                return true; // Operación exitosa
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir
                return false; // Operación fallida
            }

        }//EditarHabitacion

        public async Task<Temporada> eliminarTemporada(int id)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@Id", id));
            Temporada Reporte1 = dbContext.Temporada.FromSqlRaw(@"exec eliminarTemporada Id", parameter.ToArray()).ToList().FirstOrDefault();
            dbContext.Remove(Reporte1);
            return Reporte1;
        }

        #endregion

       







    }
}
