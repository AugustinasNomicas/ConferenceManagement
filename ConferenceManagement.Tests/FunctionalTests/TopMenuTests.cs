using ConferenceManagement.Web;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ConferenceManagement.Tests.FunctionalTests
{
    public class TopMenuTests
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public TopMenuTests()
        {
            _factory = new WebApplicationFactory<Startup>();
        }

        [Theory]
        [InlineData("/")]
        [InlineData("/MyAgenda")]
        [InlineData("/Conference")]
        [InlineData("/Speaker")]
        public async Task Get_Endpoints_ReturnSuccessAndCorrectContentType(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("text/html; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }

        [Fact]
        public async Task Get_MyAgenda_IsSecure()
        {
            // Arrange
            var client = _factory.CreateClient(
                new WebApplicationFactoryClientOptions
                {
                    AllowAutoRedirect = false
                });

            // Act
            var response = await client.GetAsync("/MyAgenda");

            // Assert
            Assert.Equal(HttpStatusCode.Redirect, response.StatusCode);
            Assert.Contains("Account/Login", response.Headers.Location.OriginalString);
        }
    }
}
