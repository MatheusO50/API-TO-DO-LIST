namespace To_Do_List.Models
{
    public class TaskEntity
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime IsStarted { get; set; }
        public DateTime IsEnd { get; set; }
        public bool IsCompleted { get; set; }
    }
}