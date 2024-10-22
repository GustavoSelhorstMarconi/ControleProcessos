namespace StageCase.Domain.Entities
{
    public class ProcessType
    {
        protected ProcessType()
        {
            Processes = new List<Process>();
        }

        public ProcessType(string name, string description)
        {
            Name = name;
            Description = description;
            Processes = new List<Process>();
        }

        public int Id { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public List<Process> Processes { get; set; }

        public void UpdateProcessType(string name, string description)
        {
            if (!string.IsNullOrEmpty(name))
            {
                Name = name;
            }
            if (!string.IsNullOrEmpty(description))
            {
                Description = description;
            }
        }
    }
}
