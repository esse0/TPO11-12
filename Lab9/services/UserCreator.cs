
using Lab9.Model;

namespace Lab9.services
{
    public class UserCreator
    {
        public const string EMAIL = "zobxmtm757@dyario.com";
        public const string PASSWORD = "123123123";

        public static User WithCredentialsFromProperty()
        {
            return new User(EMAIL, PASSWORD);
        }

        public static User WithEmptyEmail()
        {
            return new User("", PASSWORD);
        }

        public static User WithEmptyPassword()
        {
            return new User(EMAIL, "");
        }
    }
}
