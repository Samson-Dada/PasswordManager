using System.Text.Json.Serialization;

namespace API.Shared.Entities
{
    public class Password
    {
        //public int Id { get; set; }
        public string Id { get; set; }
        public string Title { get; set; }
        public string HashedPassword { get; set; }
        public string UserId { get; set; }
        public string Date { get; set; }
        [JsonIgnore]
        public User User { get; set; }
    }

}

// implement a method to make the date be updated when user update password
