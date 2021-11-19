using Celonis.Cloud.Tests.Api.Extensions;
using Celonis.Cloud.Tests.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Celonis.Cloud.Tests.Api
{
    public class AuthServiceClient
    {
        protected readonly HttpClient httpClient;
        protected readonly CookieContainer cookieContainer;

        public AuthServiceClient(string applicationRootUrl)
        {
            cookieContainer = new CookieContainer();
            var handler = new HttpClientHandler()
            {
                CookieContainer = cookieContainer
            };

            httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri(applicationRootUrl)
            };
        }

        public async Task<HttpResponseMessage> SendLoginRequest(string email, string password)
        {
            var message = new LoginRequest
            {
                Email = email,
                Password = password
            };
            var response = await httpClient.PostAsync("/api/public/auth", message.ToStringContent());
            return response;
        }

        public async Task<IList<Cookie>> Authenticate(string email, string password)
        {
            var response = await SendLoginRequest(email, password);
            response.EnsureSuccessStatusCode();

            return cookieContainer.GetCookies(httpClient.BaseAddress).ToList();
        }
    }
}
