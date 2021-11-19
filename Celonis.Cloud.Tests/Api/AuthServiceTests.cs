using Celonis.Cloud.Tests.Api.Extensions;
using Celonis.Cloud.Tests.Api.Models;
using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Framework;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace Celonis.Cloud.Tests.Api
{
    [TestFixture]
    public class AuthServiceTests : BaseTest
    {
        protected readonly AuthServiceClient serviceClient;

        public AuthServiceTests() : base()
        {
            serviceClient = new AuthServiceClient(applicationSettings.ApplicationRootUrl);
        }

        [Test]
        [Category("Smoke")]
        [Category("Api")]
        public async Task POST_Auth_ReturnsOkAndToken()
        {
            var response = await serviceClient.SendLoginRequest(
                usersSettings.User.Email,
                usersSettings.User.Password);

            using (new AssertionScope())
            {
                response.StatusCode.Should().Be(HttpStatusCode.OK);

                var contract = await response.Deserialize<LoginResponse>();
                contract.Token.Should().NotBeNullOrEmpty();
            }
        }
    }
}
