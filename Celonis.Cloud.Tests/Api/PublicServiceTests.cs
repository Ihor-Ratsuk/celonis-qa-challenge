using FluentAssertions;
using NUnit.Framework;
using System.Net;
using System.Threading.Tasks;

namespace Celonis.Cloud.Tests.Api
{
    [TestFixture]
    public class PublicServiceTests : BaseTest
    {
        private readonly PublicServiceClient serviceClient;

        public PublicServiceTests() : base()
        {
            serviceClient = new PublicServiceClient(applicationSettings.ApplicationRootUrl);

            var _ = serviceClient.Authenticate(
                usersSettings.User.Email,
                usersSettings.User.Password).Result;
        }

        [Test]
        [Category("Smoke")]
        [Category("Api")]
        public async Task GET_Apps_ReturnsOk()
        {
            var response = await serviceClient.GetApps();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        [Category("Smoke")]
        [Category("Api")]
        public async Task GET_PublicFeatures_ReturnsOk()
        {
            var response = await serviceClient.GetPublicFeatures();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        [Category("Smoke")]
        [Category("Api")]
        public async Task GET_TeamFeatures_ReturnsOk()
        {
            var response = await serviceClient.GetTeamFeatures();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        [Category("Smoke")]
        [Category("Api")]
        public async Task GET_UnscopedMe_ReturnsOk()
        {
            var response = await serviceClient.GetUnscopedMe();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
