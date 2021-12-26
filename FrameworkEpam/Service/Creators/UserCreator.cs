using FrameworkEpam.Model;
using FrameworkEpam.Utils;

namespace FrameworkEpam.Service
{
    public static class UserCreator
    {
        public static User CreateFromConfig()
        {
            var configUser = ConfigurationManager.Configuration.User;
            return new User(configUser.Login, configUser.Password);
        }

        public static User CreateWithEmptyUsername() => new User("", ConfigurationManager.Configuration.User.Password);
        public static User CreateWithEmptyPassword() => new User(ConfigurationManager.Configuration.User.Login, "");
    }
}
