using StageCase.Domain.Entities;

namespace StageCase.Domain.Contracts
{
    public interface IProcessRepository
    {
        Task<Process> GetByIdAsync(int id);

        Task<List<Process>> GetByProcessType(int idProcessType);
    }
}
