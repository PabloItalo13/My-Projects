using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain.Models;
using ProEventos.Persistence.Context;
using ProEventos.Persistence.Interfaces;

namespace ProEventos.Persistence.Services
{
    public class EventoPersist : IEventoPersist
    {
        private readonly ProEventosContext context;
        public EventoPersist(ProEventosContext context)
        {
            this.context = context;
            // this.context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        
        public async Task<Evento[]> GetAllEventosAsync(bool incluiPalestrantes = false)
        {
            IQueryable<Evento> query = this.context.Eventos
                .Include(e => e.Lotes)
                .Include(e => e.RedeSociais);

            if (incluiPalestrantes) 
            {
                query = query
                    .Include(e => e.PalestranteEventos)
                    .ThenInclude(pe => pe.Palestrante);
            }

            query = query
                .OrderBy(e => e.Id)
                .AsNoTracking();

            return await query.ToArrayAsync();
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool incluiPalestrantes = false)
        {
            IQueryable<Evento> query = this.context.Eventos
                .Include(e => e.Lotes)
                .Include(e => e.RedeSociais);

            if (incluiPalestrantes) 
            {
                query = query
                    .Include(e => e.PalestranteEventos)
                    .ThenInclude(pe => pe.Palestrante);
            }

            query = query
                .Where(e => e.Tema.ToLower().Contains(tema.ToLower()))
                .OrderBy(e => e.Id)
                .AsNoTracking();;

            return await query.ToArrayAsync();
        }

        public async Task<Evento> GetEventoByIdAsync(int eventoId, bool incluiPalestrantes = false)
        {
            IQueryable<Evento> query = this.context.Eventos
                .Include(e => e.Lotes)
                .Include(e => e.RedeSociais);

            if (incluiPalestrantes) 
            {
                query = query
                    .Include(e => e.PalestranteEventos)
                    .ThenInclude(pe => pe.Palestrante);
            }

            query = query
                .Where(e => e.Id == eventoId)
                .OrderBy(e => e.Id)
                .AsNoTracking();;

            return await query.FirstOrDefaultAsync();
        }
    }
}