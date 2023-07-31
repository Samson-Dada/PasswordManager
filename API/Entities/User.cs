namespace API.Entities
{
    public class User
    {
        public User()
        {
            Password = new List<Password>();
        }
        public string Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string UserPassword { get; set; }
        public ICollection<Password> Password { get; set; }
    }
}
        //public bool IsAdmin { get; set; }
