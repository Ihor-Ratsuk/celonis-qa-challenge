using System.Net.Http;
using System.Threading.Tasks;

namespace Celonis.Cloud.Tests.Api
{
    public class TranslationServiceClient : AuthServiceClient
    {
        public TranslationServiceClient(string applicationRootUrl)
            : base(applicationRootUrl)
        { }

        public async Task<HttpResponseMessage> GetTranslation(string module, string language)
        {
            var response = await httpClient
                .GetAsync($"/translation/api/public/translation?module={module}&language={language}");
            return response;
        }
    }
}
