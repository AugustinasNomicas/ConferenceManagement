using ConferenceManagement.Data.Repositories;
using ConferenceManagement.Web.Controllers;
using ConferenceManagement.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Xunit;

namespace ConferenceManagement.Tests.IntegrationTests.Controllers
{
    public class ConferenceControllerTests : IntegrationTestBase
    {
        public ConferenceControllerTests() : base()
        {

        }

        [Fact]
        public void Controller_AddConference_ReturnsNewConferenceAsLast()
        {
            var repository = ServiceProvider.GetRequiredService<IConferenceRepository>();
            var controller = new ConferenceController(repository);

            // create new conference
            var result = controller.Create(new Web.Models.ConferenceViewModel
            {
                Name = "test Conf",
                Description = "hello"
            }) as RedirectToActionResult;

            Assert.Equal("Conference", result.ControllerName);
            Assert.Equal("Index", result.ActionName);

            // get last conference
            var conferenceList = (controller.Index() as ViewResult).Model as IEnumerable<ConferenceViewModel>;
            var conferenceViewModel = conferenceList.Last();

            Assert.Equal("test Conf", conferenceViewModel.Name);
            Assert.Equal("hello", conferenceViewModel.Description);
        }
    }
}