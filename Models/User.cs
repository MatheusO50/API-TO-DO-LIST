namespace To_Do_List.Models
{
    public record class User
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Adress { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Passwordhash { get; set; } = string.Empty;
        
    }
}