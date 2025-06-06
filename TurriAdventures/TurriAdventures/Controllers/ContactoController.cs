﻿using Business;
using Business.Business;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace TurriAdventures.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class ContactoController : ControllerBase
        {

            private readonly HotelTurriAdventuresContext _context = new HotelTurriAdventuresContext();
            private readonly ContactoBusinessAccessSql _businessSql = new ContactoBusinessAccessSql();

            [HttpGet("ListarContactos")]
            public Task<List<Contacto>> ListarContactos()
            {
                return _businessSql.ListarContactos();
            }

            [HttpPost("CrearContacto")]
            public bool CrearContacto(String telefono1, String telefono2, String apartadoPostal, String email)
            {
                return _businessSql.CrearContacto(telefono1, telefono2, apartadoPostal, email);
            }

            [HttpPut("EditarContacto")]
            public bool EditarContacto(Contacto contacto)
            {
                return _businessSql.modificarContacto(contacto);
            }

            [HttpDelete("EliminarContacto")]
            public bool EliminarContacto(int id)
            {
                return _businessSql.EliminarContacto(id);
            }
        }
    }