namespace StageCase.Application.Dtos
{
    public class ProcessDto
    {
        public int? Id { get; set; }

        public int? IdProcessParent { get; set; }

        public int IdProcessType { get; set; }

        public ProcessTypeDto? ProcessType { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<ProcessDto>? SubProcesses { get; set; }
    }
}
