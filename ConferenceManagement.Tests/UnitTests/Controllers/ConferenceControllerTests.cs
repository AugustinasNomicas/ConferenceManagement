using ConferenceManagement.Data.Entities;
using ConferenceManagement.Data.Repositories;
using ConferenceManagement.Web.Controllers;
using ConferenceManagement.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ConferenceManagement.Tests.UnitTests.Controllers
{
    public class ConferenceControllerTests
    {
        private ConferenceController conferenceController;

        [Fact]
        public void Details_ValidId_ReturnsViewModel()
        {
            // arrange
            int conferenceId = 1;
            var conferenceRepositoryMock = new Mock<IConferenceRepository>();

            conferenceRepositoryMock.Setup(c => c.GetBy(It.IsAny<int>()))
                .Returns(new Conference
                {
                    IdConference = 1,
                    Name = "test name",
                    Description = "desc"
                });

            conferenceController = new ConferenceController(conferenceRepositoryMock.Object);

            // act
            var viewModel = (conferenceController.Details(conferenceId) as ViewResult).Model
                as ConferenceViewModel;

            // asert
            Assert.Equal(1, viewModel.IdConference);
            Assert.Equal("test name", viewModel.Name);
            Assert.Equal("desc", viewModel.Description);
        }
    }
}
