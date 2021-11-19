namespace Celonis.Cloud.Tests.Api.Models
{
    public class LoginResponse
    {
        public bool RequiresSecondFactor { get; set; }
        public string Token { get; set; }
        public string TwoFactorAuthenticationChannel { get; set; }
    }
}
