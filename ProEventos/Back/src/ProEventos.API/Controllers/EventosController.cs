using System;
using Microsoft.AspNetCore.Mvc;
using ProEventos.Domain.Models;
using ProEventos.Application.Interface;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {
        private readonly IEventoService eventoService;
        public EventosController(IEventoService eventoService)
        {
            this.eventoService = eventoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var eventos = await this.eventoService.GetAllEventosAsync(true);
                if (eventos == null) 
                {
                    return NotFound("Nehum evento encontrado.");
                }

                return Ok(eventos);
            }
            catch (Exception ex)
            {
                return this.StatusCode(
                    StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar eventos. Erro: {ex.Message}"
                );
            }
        }

        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var evento = await this.eventoService.GetEventoByIdAsync(id, true);
                if (evento == null) 
                {
                    return NotFound("Nehum evento por id foi encontrado.");
                }

                return Ok(evento);
            }
            catch (Exception ex)
            {
                return this.StatusCode(
                    StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar evento. Erro: {ex.Message}"
                );
            }
        }

        [HttpGet("tema/{tema}")]
        public async Task<IActionResult> GetByTema(string tema)
        {
            try
            {
                var evento = await this.eventoService.GetAllEventosByTemaAsync(tema, true);
                if (evento == null) 
                {
                    return NotFound("Nehum evento por tema foi encontrado.");
                }

                return Ok(evento);
            }
            catch (Exception ex)
            {
                return this.StatusCode(
                    StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar eventos. Erro: {ex.Message}"
                );
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Evento model)
        {
            try
            {
                var evento = await this.eventoService.AddEvento(model);
                if (evento == null) 
                {
                    return BadRequest("Erro ao adicionar o evento.");
                }

                return Ok(evento);
            }
            catch (Exception ex)
            {
                return this.StatusCode(
                    StatusCodes.Status500InternalServerError,
                    $"Erro ao adicionar o evento. Erro: {ex.Message}"
                );
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Evento model)
        {
            try
            {
                var evento = await this.eventoService.UpdateEvento(id, model);
                if (evento == null) 
                {
                    return BadRequest("Erro ao atualizar o evento.");
                }

                return Ok(evento);
            }
            catch (Exception ex)
            {
                return this.StatusCode(
                    StatusCodes.Status500InternalServerError,
                    $"Erro ao atualizar o evento. Erro: {ex.Message}"
                );
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (await this.eventoService.DeleteEvento(id)) 
                {
                    return Ok("Deletado.");
                }
                else
                {
                    return BadRequest("Evento não deletado.");
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(
                    StatusCodes.Status500InternalServerError,
                    $"Erro ao deletar o evento. Erro: {ex.Message}"
                );
            }
        }
    }
}
