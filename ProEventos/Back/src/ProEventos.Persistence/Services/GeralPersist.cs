using System.Threading.Tasks;
using ProEventos.Persistence.Context;
using ProEventos.Persistence.Interfaces;

namespace ProEventos.Persistence.Services
{
    public class GeralPersist : IGeralPersist
    {
        private readonly ProEventosContext context;
        public GeralPersist(ProEventosContext context)
        {
            this.context = context;
        }
        
        public void add<T>(T entity) where T : class
        {
            this.context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            this.context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            this.context.Remove(entity);
        }

        public void DeleteRange<T>(T[] entity) where T : class
        {
            this.context.RemoveRange(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await this.context.SaveChangesAsync()) > 0;
        }
    }
}