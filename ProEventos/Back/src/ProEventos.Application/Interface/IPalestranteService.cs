using System.Threading.Tasks;
using ProEventos.Domain.Models;

namespace ProEventos.Application.Interface
{
    public interface IPalestranteService
    {
        Task<Evento> AddPalestrante(Evento model);
        Task<Evento> UpdatePalestrante(int eventoId, Evento model);
        Task<bool> DeletePalestrante(int eventoId);        
        Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool incluiEventos = false);
        Task<Palestrante[]> GetAllPalestrantesAsync(bool incluiEventos = false);
        Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool incluiEventos = false);
    }
}