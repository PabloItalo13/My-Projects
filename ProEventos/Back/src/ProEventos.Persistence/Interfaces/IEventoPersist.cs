using System.Threading.Tasks;
using ProEventos.Domain.Models;

namespace ProEventos.Persistence.Interfaces
{
    public interface IEventoPersist
    {
        Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool incluiPalestrantes = false);
        Task<Evento[]> GetAllEventosAsync(bool incluiPalestrantes = false);
        Task<Evento> GetEventoByIdAsync(int eventoId, bool incluiPalestrantes = false);
    }
}