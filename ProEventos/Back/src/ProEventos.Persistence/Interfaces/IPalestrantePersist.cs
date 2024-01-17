using System.Threading.Tasks;
using ProEventos.Domain.Models;

namespace ProEventos.Persistence.Interfaces
{
    public interface IPalestrantePersist
    {
        Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool incluiEventos = false);
        Task<Palestrante[]> GetAllPalestrantesAsync(bool incluiEventos = false);
        Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool incluiEventos = false);
    }
}