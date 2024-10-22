using AutoMapper;
using StageCase.Application.Dtos;
using StageCase.Domain.Entities;

namespace StageCase.Application.Helpers
{
    public class StageCaseProfiler : Profile
    {
        public StageCaseProfiler()
        {
            CreateMap<Process, ProcessDto>().ReverseMap();
            CreateMap<ProcessType, ProcessTypeDto>().ReverseMap();
        }
    }
}
