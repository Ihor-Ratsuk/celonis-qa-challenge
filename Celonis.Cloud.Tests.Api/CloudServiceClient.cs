using System.Net.Http;
using System.Threading.Tasks;

namespace Celonis.Cloud.Tests.Api
{
    public class CloudServiceClient : AuthServiceClient
    {
        public CloudServiceClient(string applicationRootUrl)
            : base(applicationRootUrl)
        { }

        public async Task<HttpResponseMessage> GetCloud()
        {
            var response = await httpClient.GetAsync($"/api/cloud");
            return response;
        }

        public async Task<HttpResponseMessage> GetPermissions()
        {
            var response = await httpClient.GetAsync($"/api/cloud/permissions");
            return response;
        }

        public async Task<HttpResponseMessage> GetTeam()
        {
            var response = await httpClient.GetAsync($"/api/cloud/team");
            return response;
        }
    }
}
