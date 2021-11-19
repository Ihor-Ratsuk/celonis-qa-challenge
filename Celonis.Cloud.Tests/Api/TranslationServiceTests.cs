using FluentAssertions;
using NUnit.Framework;
using System.Net;
using System.Threading.Tasks;

namespace Celonis.Cloud.Tests.Api
{
    [TestFixture]
    public class TranslationServiceTests : BaseTest
    {
        private readonly TranslationServiceClient serviceClient;

        public TranslationServiceTests() : base()
        {
            serviceClient = new TranslationServiceClient(applicationSettings.ApplicationRootUrl);

            var _ = serviceClient.Authenticate(
                usersSettings.User.Email,
                usersSettings.User.Password).Result;
        }

        [TestCase("emotion", "en")]
        [TestCase("emotion-cloud", "en")]
        [TestCase("process-mining", "en")]
        [Category("Smoke")]
        [Category("Api")]
        public async Task GET_Translation_ReturnsOk(string module, string language)
        {
            var response = await serviceClient.GetTranslation(module, language);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
