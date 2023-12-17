namespace blogCSharp.Models
{
    public class User : Entity
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public User(Guid id, string name, string password, string email) : base(id)
        {
            Name = name;
            Password = password;
            Email = email;
        }
    }
}