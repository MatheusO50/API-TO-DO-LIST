namespace To_Do_List.Models
{
    public class RefreshToken
    {
        public long Id { get; set; }
        public string Token { get; set; } = string.Empty;
        public long UserId { get; set; }
        public DateTime Expires { get; set; }
        public bool IsRevoked { get; set; }
    }
}