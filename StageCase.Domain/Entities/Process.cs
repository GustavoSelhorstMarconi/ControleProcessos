namespace StageCase.Domain.Entities
{
    public class Process
    {
        public Process(int? idProcessParent, int idProcessType, string name, string description)
        {
            IdProcessParent = idProcessParent;
            IdProcessType = idProcessType;
            Name = name;
            Description = description;
            SubProcesses = new List<Process>();
        }

        protected Process()
        {
            Name = string.Empty;
            Description = string.Empty;
            SubProcesses = new List<Process>();
        }

        public int Id { get; set; }

        public int? IdProcessParent { get; private set; }

        public Process? ProcessParent { get; private set; }

        public int IdProcessType { get; private set; }

        public ProcessType ProcessType { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public List<Process> SubProcesses { get; set; }

        public void UpdateProcess(string name, string description, int idProcessType)
        {
            if (!string.IsNullOrEmpty(name))
            {
                Name = name;
            }
            if (!string.IsNullOrEmpty(description))
            {
                Description = description;
            }

            IdProcessType = idProcessType;
        }

        public void SetSubProcesses(List<Process> subProcesses)
        {
            SubProcesses = subProcesses;
        }
    }
}
