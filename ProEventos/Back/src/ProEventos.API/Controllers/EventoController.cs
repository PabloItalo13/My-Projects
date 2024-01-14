using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        public EventoController()
        {
            
        }

        public IEnumerable<Evento> evento = new Evento[] 
            {
                new Evento() 
                {
                    EventoId    = 1,
                    Tema        = "Angular 11 e .NET 5",
                    Local       = "Belo Horizonte",
                    Lote        = "1º Lote",
                    QtdPessoas  = 250,
                    DataEvento  = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"),
                    ImagemURL    = "foto.png"
                },
                new Evento() 
                {
                    EventoId    = 2,
                    Tema        = "Angular 11 e suas novidades",
                    Local       = "São Paulo",
                    Lote        = "2º Lote",
                    QtdPessoas  = 350,
                    DataEvento  = DateTime.Now.AddDays(3).ToString("dd/MM/yyyy"),
                    ImagemURL    = "foto1.png"
                }
            };

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return this.evento;
        }

        [HttpGet("{id}")]
        public IEnumerable<Evento> Get(int id)
        {
            return this.evento.Where(e => e.EventoId == id);
        }

        [HttpPost]
        public String Post()
        {
            return "Exemplo de Post";
        }

        [HttpPut("{id}")]
        public String Put(int id)
        {
            return $"Exemplo de Put com id = {id}";
        }

        [HttpDelete("{id}")]
        public String Delete(int id)
        {
            return $"Exemplo de Delete com id = {id}";
        }
    }
}
