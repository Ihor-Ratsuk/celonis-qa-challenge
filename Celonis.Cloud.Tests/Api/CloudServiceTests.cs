using FluentAssertions;
using NUnit.Framework;
using System.Net;
using System.Threading.Tasks;

namespace Celonis.Cloud.Tests.Api
{
    [TestFixture]
    public class CloudServiceTests : BaseTest
    {
        private readonly CloudServiceClient serviceClient;

        public CloudServiceTests() : base()
        {
            serviceClient = new CloudServiceClient(applicationSettings.ApplicationRootUrl);

            var _ = serviceClient.Authenticate(
                usersSettings.User.Email,
                usersSettings.User.Password).Result;
        }

        [Test]
        [Category("Smoke")]
        [Category("Api")]
        public async Task GET_Cloud_ReturnsOk()
        {
            var response = await serviceClient.GetCloud();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        [Category("Smoke")]
        [Category("Api")]
        public async Task GET_Permissions_ReturnsOk()
        {
            var response = await serviceClient.GetPermissions();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        [Category("Smoke")]
        [Category("Api")]
        public async Task GET_Team_ReturnsOk()
        {
            var response = await serviceClient.GetTeam();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
