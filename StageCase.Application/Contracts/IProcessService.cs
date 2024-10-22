using StageCase.Application.Dtos;

namespace StageCase.Application.Contracts
{
    public interface IProcessService
    {
        Task<ResponseDto<ProcessDto>> Add(ProcessDto processDto);

        Task<ResponseDto<List<ProcessDto>>> Get(int idProcessType);

        Task<ResponseDto<ProcessDto>> Update(ProcessDto processDto);

        Task Delete(int idProcess);
    }
}
