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
    public class OfertaDataAccessSql
    {
        HotelTurriAdventuresContext dbContext = new HotelTurriAdventuresContext();

        #region CRUDOferta
        public async Task<List<Oferta>> ListarOfertas()
        {
            var ofertas = await dbContext.Oferta.FromSqlInterpolated($"exec listarOfertas").ToListAsync();
            return ofertas;
        }//ListarOfertas




        public async Task<bool> CrearOferta(string descripcionOferta, DateTime fechaInicioOferta, DateTime fechaFinalOferta, decimal precioOferta)
        {
            try
            {
                var parameters = new[]
                {
                new SqlParameter("@DescripcionOferta", descripcionOferta),
                new SqlParameter("@FechaInicioOferta", fechaInicioOferta),
                new SqlParameter("@FechaFinalOferta", fechaFinalOferta),
                new SqlParameter("@PrecioOferta", precioOferta),
                new SqlParameter("@activo", 1)
                };

                // Ejecutar un comando SQL personalizado
                dbContext.Database.ExecuteSqlRawAsync("exec crearOferta @DescripcionOferta, @FechaInicioOferta, @FechaFinalOferta, @PrecioOferta, @activo", parameters);

                return true; // Operación exitosa
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir
                return false; // Operación fallida
            }
        }//CrearOferta

        public Oferta BuscarOferta(int idOferta)
        {
            var parameters = new[]
            {
                new SqlParameter("@IdOferta", idOferta)
            };

            // Ejecutar el procedimiento almacenado y obtener la oferta
            var ofertaObtenida = dbContext.Oferta.FromSqlRaw("exec buscarOferta @IdOferta", parameters).AsEnumerable().FirstOrDefault();

            if (ofertaObtenida == null)
            {
                // Manejar el caso donde no se encontró ninguna oferta
                return null;
            }

            // Crear una nueva instancia de Oferta y asignarle las propiedades conocidas
            var ofertaCreada = new Oferta
            {
                IdOferta = idOferta, // Aquí puedes asignar el id que recibiste como parámetro
                DescripcionOferta = ofertaObtenida.DescripcionOferta,
                FechaInicioOferta = ofertaObtenida.FechaInicioOferta,
                FechaFinalOferta = ofertaObtenida.FechaFinalOferta,
                PrecioOferta = ofertaObtenida.PrecioOferta
            };

            return ofertaCreada;
        }//BuscarOferta

        public async Task<bool> EditarOferta(int idOferta, string descripcionOferta, DateTime fechaInicioOferta, DateTime fechaFinalOferta, decimal precioOferta)
        {
            try
            {
                var parameters = new[]
                {
                new SqlParameter("@IdOferta", idOferta),
                new SqlParameter("@DescripcionOferta", descripcionOferta),
                new SqlParameter("@FechaInicioOferta", fechaInicioOferta),
                new SqlParameter("@FechaFinalOferta", fechaFinalOferta),
                new SqlParameter("@PrecioOferta", precioOferta),
                new SqlParameter("@activo", 1)
                };

                // Ejecutar un comando SQL personalizado
                dbContext.Database.ExecuteSqlRawAsync("exec modificarOferta @IdOferta, @DescripcionOferta, @FechaInicioOferta, @FechaFinalOferta, @PrecioOferta, @activo", parameters);

                return true; // Operación exitosa
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir
                return false; // Operación fallida
            }
        }//EditarOferta

        public bool EliminarOferta(int idOferta)
        {
            try
            {
                var parameters = new[]
                {
                    new SqlParameter("@IdOferta", idOferta)
                };

                dbContext.Database.ExecuteSqlRawAsync("exec eliminarOferta @IdOferta", parameters);

                return true; // Operación exitosa
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir
                return false; // Operación fallida
            }

        }//EliminarOferta

        #endregion
    }
}