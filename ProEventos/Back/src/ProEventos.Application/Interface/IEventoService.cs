using System.Threading.Tasks;
using ProEventos.Domain.Models;

namespace ProEventos.Application.Interface
{
    public interface IEventoService
    {
        Task<Evento> AddEvento(Evento model);
        Task<Evento> UpdateEvento(int eventoId, Evento model);
        Task<bool> DeleteEvento(int eventoId);
        Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool incluiPalestrantes = false);
        Task<Evento[]> GetAllEventosAsync(bool incluiPalestrantes = false);
        Task<Evento> GetEventoByIdAsync(int eventoId, bool incluiPalestrantes = false);
    }
}