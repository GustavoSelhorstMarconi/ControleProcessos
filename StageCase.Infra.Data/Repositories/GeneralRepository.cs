using StageCase.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageCase.Infra.Data.Repositories
{
    public class GeneralRepository : IGeneralRepository
    {
        private readonly Context _context;

        public GeneralRepository(Context context)
        {
            _context = context;
        }

        public async Task Add<T>(T entity) where T : class
        {
            await _context.AddAsync(entity);

            await _context.SaveChangesAsync();
        }

        public async Task Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteRange<T>(T entities) where T : class
        {
            _context.RemoveRange(entities);

            await _context.SaveChangesAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
