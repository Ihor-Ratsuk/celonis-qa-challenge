using Celonis.Cloud.Tests.Api;
using Celonis.Cloud.Tests.Common.Configuration;
using System.Collections.Generic;
using System.Net;

namespace Celonis.Cloud.Tests.UI.Contexts
{
    public class AuthServiceContext
    {
        private readonly IApplicationOptions applicationOptions;

        private AuthServiceClient authServiceClient;
        public AuthServiceClient AuthServiceClient =>
            authServiceClient ??= new AuthServiceClient(applicationOptions.ApplicationRootUrl);

        private IList<Cookie> cookies;

        public AuthServiceContext(ConfigurationContext configurationContext)
        {
            applicationOptions = configurationContext.ApplicationOptions;
        }

        public IList<Cookie> Authenticate(string email, string password)
        {
            return cookies ??= AuthServiceClient
                .Authenticate(email, password)
                .Result;
        }
    }
}
