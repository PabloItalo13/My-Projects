using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain.Models;
using ProEventos.Persistence.Context;
using ProEventos.Persistence.Interfaces;

namespace ProEventos.Persistence.Services
{
    public class PalestrantePersist : IPalestrantePersist
    {
        private readonly ProEventosContext context;
        public PalestrantePersist(ProEventosContext context)
        {
            this.context = context;
        }
        
        public async Task<Palestrante[]> GetAllPalestrantesAsync(bool incluiEventos = false)
        {
           IQueryable<Palestrante> query = this.context.Palestrantes
                .Include(p => p.RedeSociais);

            if (incluiEventos)
            {
                query = query
                    .Include(p => p.PalestranteEventos)
                    .ThenInclude(pe => pe.Evento);
            }

            query = query
                .OrderBy(p => p.Id)
                .AsNoTracking();

            return await query.ToArrayAsync();
        }

        public async Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool incluiEventos = false)
        {
            IQueryable<Palestrante> query = this.context.Palestrantes
                .Include(p => p.RedeSociais);

            if (incluiEventos)
            {
                query = query
                    .Include(p => p.PalestranteEventos)
                    .ThenInclude(pe => pe.Evento);
            }

            query = query
                .Where(p => p.Nome.ToLower().Contains(nome.ToLower()))
                .OrderBy(p => p.Id)
                .AsNoTracking();

            return await query.ToArrayAsync();
        }

        public async Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool incluiEventos = false)
        {
            IQueryable<Palestrante> query = this.context.Palestrantes
                .Include(p => p.RedeSociais);

            if (incluiEventos)
            {
                query = query
                    .Include(p => p.PalestranteEventos)
                    .ThenInclude(pe => pe.Evento);
            }

            query = query
                .Where(p => p.Id == palestranteId)
                .OrderBy(p => p.Id)
                .AsNoTracking();

            return await query.FirstOrDefaultAsync();
        }
    }
}