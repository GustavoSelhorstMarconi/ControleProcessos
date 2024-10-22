namespace StageCase.Application.Dtos
{
    public class ProcessTypeDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<ProcessDto>? Processes { get; set; }
    }
}
