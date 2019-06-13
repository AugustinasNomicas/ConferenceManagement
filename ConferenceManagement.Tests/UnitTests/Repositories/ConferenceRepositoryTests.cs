using ConferenceManagement.Data;
using ConferenceManagement.Data.Entities;
using ConferenceManagement.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace ConferenceManagement.Tests.UnitTests.Repositories
{
    public class ConferenceRepositoryTests
    {
        private ConferenceRepository conferenceRepository;

        public ConferenceRepositoryTests()
        {
            DbContextOptions<ConferenceDbContext> options = new DbContextOptionsBuilder<ConferenceDbContext>()
            .UseInMemoryDatabase(databaseName: "ConferenceDb")
            .Options;

            var conferenceDbContext = new ConferenceDbContext(options);

            conferenceRepository = new ConferenceRepository(conferenceDbContext);
        }

        [Fact]
        public void Add_NewConferences_DbRowCreatedWithNewId()
        {
            // arrange
            var conference = new Conference()
            {
                Description = "test",
                Name = "name test"
            };

            // act
            conferenceRepository.Add(conference);

            // assert
            var createdConference = conferenceRepository.Get().Single();
            Assert.Equal(1, createdConference.IdConference);
        }

        [Fact]
        public void GetBy_NonExistingId_ThrowsExpcetion()
        {
            // arrange
            var nonExistingId = 99;

            // act
            var ex = Assert.Throws<System.InvalidOperationException>(() => conferenceRepository.GetBy(nonExistingId));

            // assert
            Assert.Equal("Sequence contains no elements", ex.Message);
        }
    }
}
