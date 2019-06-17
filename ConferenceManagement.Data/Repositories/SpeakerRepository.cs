using ConferenceManagement.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConferenceManagement.Data.Repositories
{
    public class SpeakerRepository : ISpeakerRepository
    {
        private readonly ConferenceDbContext _conferenceDbContext;

        public SpeakerRepository(ConferenceDbContext conferenceDbContext)
        {
            _conferenceDbContext = conferenceDbContext;
        }

        public int Add(Speaker entity)
        {
            _conferenceDbContext.Speakers.Add(entity);

            _conferenceDbContext.SaveChanges();

            return entity.IdSpeaker;
        }

        public void Delete(int id)
        {
            var speaker = GetBy(id);
            _conferenceDbContext.Remove(speaker);

            _conferenceDbContext.SaveChanges();
        }

        public IEnumerable<Speaker> Get()
        {
            return _conferenceDbContext.Speakers;
        }

        public Speaker GetBy(int id)
        {
            return _conferenceDbContext.Speakers.Single(c => c.IdSpeaker == id);
        }

        public void Update(Speaker entity)
        {
            _conferenceDbContext.Update(entity);

            _conferenceDbContext.SaveChanges();
        }
    }
}
