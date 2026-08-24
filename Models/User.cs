namespace To_Do_List.Models
{
    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Adress { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string hash { get; set; } = string.Empty;
        public string salt { get; set; } = string.Empty;
    }
}