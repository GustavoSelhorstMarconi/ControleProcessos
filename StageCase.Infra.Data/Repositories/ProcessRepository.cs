using Microsoft.EntityFrameworkCore;
using StageCase.Domain.Contracts;
using StageCase.Domain.Entities;

namespace StageCase.Infra.Data.Repositories
{
    public class ProcessRepository : IProcessRepository
    {
        private readonly Context _context;

        public ProcessRepository(Context context)
        {
            _context = context;
        }

        public async Task<Process> GetByIdAsync(int id)
        {
            Process? process = await _context.Process
                .Include(x => x.SubProcesses)
                .SingleOrDefaultAsync(x => x.Id == id);

            if (process == null)
            {
                throw new ApplicationException("Processo não encontrado.");
            }

            return process;
        }

        public async Task<List<Process>> GetByProcessType(int idProcessType)
        {
            var processes = await _context.Process
                .AsNoTracking()
                .Where(x => x.IdProcessType == idProcessType)
                .ToListAsync();

            return processes;
        }
    }
}
