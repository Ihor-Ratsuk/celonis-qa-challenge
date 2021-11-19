using System.Net.Http;
using System.Threading.Tasks;

namespace Celonis.Cloud.Tests.Api
{
    public class ProcessMiningServiceClient : AuthServiceClient
    {
        public ProcessMiningServiceClient(string applicationRootUrl)
            : base(applicationRootUrl)
        { }

        public async Task<HttpResponseMessage> GetAnalysis()
        {
            var response = await httpClient.GetAsync($"/process-mining/api/analysis");
            return response;
        }

        public async Task<HttpResponseMessage> GetAnalysisApps()
        {
            var response = await httpClient.GetAsync($"/process-mining/api/analysis/apps");
            return response;
        }

        public async Task<HttpResponseMessage> GetComputePoolsWorkspaceNodes()
        {
            var response = await httpClient.GetAsync($"/process-mining/api/compute-pools/workspaces-nodes");
            return response;
        }

        public async Task<HttpResponseMessage> GetProcesses()
        {
            var response = await httpClient.GetAsync($"/process-mining/api/processes");
            return response;
        }
    }
}
