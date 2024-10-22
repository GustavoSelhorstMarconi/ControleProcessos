using StageCase.Domain.Entities;

namespace StageCase.Domain.Contracts
{
    public interface IProcessTypeRepository
    {
        Task<ProcessType> GetByIdAsync(int id);

        Task<List<ProcessType>> Get();
    }
}
