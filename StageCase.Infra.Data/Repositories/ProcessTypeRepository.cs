using Microsoft.EntityFrameworkCore;
using StageCase.Domain.Contracts;
using StageCase.Domain.Entities;

namespace StageCase.Infra.Data.Repositories
{
    public class ProcessTypeRepository : IProcessTypeRepository
    {
        private readonly Context _context;

        public ProcessTypeRepository(Context context)
        {
            _context = context;
        }

        public async Task<ProcessType> GetByIdAsync(int id)
        {
            ProcessType? processType = await _context.ProcessTypes
                .SingleOrDefaultAsync(x => x.Id == id);

            if (processType == null)
            {
                throw new ApplicationException("Tipo de processo não encontrado.");
            }

            return processType;
        }

        public async Task<List<ProcessType>> Get()
        {
            var processesTypes = await _context.ProcessTypes
                .Include(x => x.Processes)
                .AsNoTracking()
                .ToListAsync();

            return processesTypes;
        }
    }
}
