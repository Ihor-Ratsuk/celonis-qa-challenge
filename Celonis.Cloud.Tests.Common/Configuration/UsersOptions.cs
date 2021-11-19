namespace Celonis.Cloud.Tests.Common.Configuration
{
    public class UsersOptions : IUsersOptions
    {
        public const string Section = "Users";

        public UserCredentials User { get; set; }

        IUserCredentials IUsersOptions.User => User;
    }
}
