using AutoMapper;
using StageCase.Application.Contracts;
using StageCase.Application.Dtos;
using StageCase.Domain.Contracts;
using StageCase.Domain.Entities;

namespace StageCase.Application.Services
{
    public class ProcessTypeService : IProcessTypeService
    {
        private readonly IGeneralRepository _generalRepository;
        private readonly IProcessTypeRepository _processTypeRepository;
        private readonly IMapper _mapper;

        public ProcessTypeService(IGeneralRepository generalRepository, IProcessTypeRepository processTypeRepository, IMapper mapper)
        {
            _generalRepository = generalRepository;
            _processTypeRepository = processTypeRepository;
            _mapper = mapper;
        }

        public async Task Add(ProcessTypeDto processTypeDto)
        {
            try
            {
                ProcessType? processType = _mapper.Map<ProcessType>(processTypeDto);

                await _generalRepository.Add(processType);
            }
            catch
            {
                throw new Exception("Erro ao cadastrar um tipo de processo.");
            }
        }

        public async Task<ResponseDto<List<ProcessTypeDto>>> Get()
        {
            try
            {
                List<ProcessType>? processTypes = await _processTypeRepository.Get();

                List<ProcessTypeDto>? processTypesDto = _mapper.Map<List<ProcessTypeDto>>(processTypes);

                return ResponseDto<List<ProcessTypeDto>>.Success(processTypesDto);
            }
            catch (Exception ex)
            {
                return ResponseDto<List<ProcessTypeDto>>.Failure("Erro ao buscar tipos de processos.");
            }
        }

        public async Task Update(ProcessTypeDto processTypeDto)
        {
            try
            {
                ProcessType? processType = await _processTypeRepository.GetByIdAsync(processTypeDto.Id);

                processType.UpdateProcessType(processTypeDto.Name, processTypeDto.Description);

                await _generalRepository.SaveAsync();
            }
            catch
            {
                throw new Exception("Erro ao atualizar um tipo de processo.");
            }
        }

        public async Task Delete(int idProcessType)
        {
            try
            {
                ProcessType? processType = await _processTypeRepository.GetByIdAsync(idProcessType);

                await _generalRepository.Delete(processType);

                await _generalRepository.SaveAsync();
            }
            catch
            {
                throw new Exception("Erro ao deletar um tipo de processo.");
            }
        }
    }
}
