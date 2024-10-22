using StageCase.Application.Dtos;

namespace StageCase.Application.Contracts
{
    public interface IProcessTypeService
    {
        Task Add(ProcessTypeDto processTypeDto);

        Task<ResponseDto<List<ProcessTypeDto>>> Get();

        Task Update(ProcessTypeDto processTypeDto);

        Task Delete(int idProcessType);
    }
}
