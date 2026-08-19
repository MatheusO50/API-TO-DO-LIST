namespace To_Do_List.Models
{
    public class UserEntity
    {
        public long Id { get; set; }
        public long Id_Task { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Adress { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}