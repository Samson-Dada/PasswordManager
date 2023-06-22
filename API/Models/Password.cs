namespace API.Models
{
    public class Password
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Username { get; set; }
        public string EncryptedPassword { get; set; }
    }
}
