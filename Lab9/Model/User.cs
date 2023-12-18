namespace Lab9.Model
{
    public class User
    {
        public string Email { get; set; }
        public string Password {  get; set; }

        public User(string email, string password)
        {
            this.Email = email;
            this.Password = password;
        }

        public override string ToString()
        {
            return $"Login:{Email}, Password:{Password}\n";
        }
    }
}
