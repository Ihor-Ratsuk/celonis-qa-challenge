using System.Net.Http;
using System.Threading.Tasks;

namespace Celonis.Cloud.Tests.Api
{
    public class PublicServiceClient : AuthServiceClient
    {
        public PublicServiceClient(string applicationRootUrl)
            : base(applicationRootUrl)
        { }

        public async Task<HttpResponseMessage> GetApps()
        {
            var response = await httpClient.GetAsync($"/api/apps");
            return response;
        }

        public async Task<HttpResponseMessage> GetPublicFeatures()
        {
            var response = await httpClient.GetAsync($"/api/public/features");
            return response;
        }

        public async Task<HttpResponseMessage> GetTeamFeatures()
        {
            var response = await httpClient.GetAsync($"/api/team/features");
            return response;
        }

        public async Task<HttpResponseMessage> GetUnscopedMe()
        {
            var response = await httpClient.GetAsync($"/api/unscoped/me");
            return response;
        }
    }
}
