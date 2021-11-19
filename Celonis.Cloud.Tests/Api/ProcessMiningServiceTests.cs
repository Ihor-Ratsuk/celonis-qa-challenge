using FluentAssertions;
using NUnit.Framework;
using System.Net;
using System.Threading.Tasks;

namespace Celonis.Cloud.Tests.Api
{
    [TestFixture]
    public class ProcessMiningServiceTests : BaseTest
    {
        private readonly ProcessMiningServiceClient serviceClient;

        public ProcessMiningServiceTests() : base()
        {
            serviceClient = new ProcessMiningServiceClient(applicationSettings.ApplicationRootUrl);

            var _ = serviceClient.Authenticate(
                usersSettings.User.Email,
                usersSettings.User.Password).Result;
        }

        [Test]
        [Category("Smoke")]
        [Category("Api")]
        public async Task GET_Analysis_ReturnsOk()
        {
            var response = await serviceClient.GetAnalysis();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        [Category("Smoke")]
        [Category("Api")]
        public async Task GET_AnalysisApps_ReturnsOk()
        {
            var response = await serviceClient.GetAnalysisApps();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        [Category("Smoke")]
        [Category("Api")]
        public async Task GET_ComputePoolsWorkspaceNodes_ReturnsOk()
        {
            var response = await serviceClient.GetComputePoolsWorkspaceNodes();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        [Category("Smoke")]
        [Category("Api")]
        public async Task GET_Processes_ReturnsOk()
        {
            var response = await serviceClient.GetProcesses();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
