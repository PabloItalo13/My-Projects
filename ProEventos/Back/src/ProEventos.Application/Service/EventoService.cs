using System;
using System.Threading.Tasks;
using ProEventos.Application.Interface;
using ProEventos.Domain.Models;
using ProEventos.Persistence.Interfaces;

namespace ProEventos.Application.Service
{
    public class EventoService : IEventoService
    {
        private readonly IGeralPersist geralPersist;
        private readonly IEventoPersist eventoPersist;
        public EventoService(IGeralPersist geralPersist, IEventoPersist eventoPersist)
        {
            this.geralPersist = geralPersist;
            this.eventoPersist = eventoPersist;
        }
        public async Task<Evento> AddEvento(Evento model)
        {
            try
            {
                this.geralPersist.add<Evento>(model);

                if(await this.geralPersist.SaveChangesAsync())
                {
                    return await this.eventoPersist.GetEventoByIdAsync(model.Id, false);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> UpdateEvento(int eventoId, Evento model)
        {
            try
            {
                var evento = await this.eventoPersist.GetEventoByIdAsync(eventoId, false);
                if (evento == null)
                {
                    return null;
                }

                model.Id = evento.Id;

                this.geralPersist.Update<Evento>(model);
                if(await this.geralPersist.SaveChangesAsync())
                {
                    return await this.eventoPersist.GetEventoByIdAsync(model.Id, false);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteEvento(int eventoId)
        {
            try
            {
                var evento = await this.eventoPersist.GetEventoByIdAsync(eventoId, false);
                if (evento == null)
                {
                    throw new Exception("Evento para delete não encontrado.");
                }
                
                this.geralPersist.Delete<Evento>(evento);
                return await this.geralPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosAsync(bool incluiPalestrantes = false)
        {
            try
            {
                var eventos = await this.eventoPersist.GetAllEventosAsync(false);
                if (eventos == null)
                {
                    return null;
                }

                return eventos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool incluiPalestrantes = false)
        {
            try
            {
                var eventos = await this.eventoPersist.GetAllEventosByTemaAsync(tema, false);
                if (eventos == null)
                {
                    return null;
                }

                return eventos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> GetEventoByIdAsync(int eventoId, bool incluiPalestrantes = false)
        {
            try
            {
                var evento = await this.eventoPersist.GetEventoByIdAsync(eventoId, false);
                if (evento == null)
                {
                    return null;
                }

                return evento;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}