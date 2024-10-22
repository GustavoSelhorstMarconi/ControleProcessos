using AutoMapper;
using StageCase.Application.Contracts;
using StageCase.Application.Dtos;
using StageCase.Domain.Contracts;
using StageCase.Domain.Entities;

namespace StageCase.Application.Services
{
    public class ProcessService : IProcessService
    {
        private readonly IGeneralRepository _generalRepository;
        private readonly IProcessRepository _processRepository;
        private readonly IMapper _mapper;

        public ProcessService(IGeneralRepository generalRepository, IProcessRepository processRepository, IMapper mapper)
        {
            _generalRepository = generalRepository;
            _processRepository = processRepository;
            _mapper = mapper;
        }

        public async Task<ResponseDto<ProcessDto>> Add(ProcessDto processDto)
        {
            try
            {
                Process? process = _mapper.Map<Process>(processDto);

                await _generalRepository.Add(process);

                ProcessDto processDtoCreated = _mapper.Map<ProcessDto>(process);

                return ResponseDto<ProcessDto>.Success(processDtoCreated);
            }
            catch
            {
                throw new Exception("Erro ao cadastrar um processo.");
            }
        }

        public async Task<ResponseDto<List<ProcessDto>>> Get(int idProcessType)
        {
            try
            {
                List<Process>? processes = await _processRepository.GetByProcessType(idProcessType);

                processes = PopulateSubProcesses(processes);

                processes = processes
                    .Where(x => !x.IdProcessParent.HasValue)
                    .ToList();

                List<ProcessDto>? processDto = _mapper.Map<List<ProcessDto>>(processes);

                return ResponseDto<List<ProcessDto>>.Success(processDto);
            }
            catch (Exception)
            {
                return ResponseDto<List<ProcessDto>>.Failure("Erro ao buscar processos.");
            }
        }

        public async Task<ResponseDto<ProcessDto>> Update(ProcessDto processDto)
        {
            try
            {
                Process? process = await _processRepository.GetByIdAsync(processDto.Id.Value);

                process.UpdateProcess(processDto.Name, processDto.Description, processDto.IdProcessType);

                await _generalRepository.SaveAsync();

                ProcessDto processDtoUpdated = _mapper.Map<ProcessDto>(process);

                return ResponseDto<ProcessDto>.Success(processDtoUpdated);
            }
            catch
            {
                throw new Exception("Erro ao atualizar o processo.");
            }
        }

        public async Task Delete(int idProcess)
        {
            try
            {
                Process? process = await _processRepository.GetByIdAsync(idProcess);

                await _generalRepository.Delete(process);

                await _generalRepository.SaveAsync();
            }
            catch
            {
                throw new Exception("Erro ao deletar o processo.");
            }
        }

        private List<Process> PopulateSubProcesses(List<Process> processes)
        {
            processes.ForEach(x =>
            {
                x.SetSubProcesses(processes
                    .Where(p => p.IdProcessParent == x.Id)
                    .ToList());
            });

            return processes;
        }
    }
}
