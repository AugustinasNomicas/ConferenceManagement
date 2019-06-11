using ConferenceManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConferenceManagement.Data.Repositories
{
    public class ConferenceRepository : IConferenceRepository
    {
        private readonly ConferenceDbContext _conferenceDbContext;

        public ConferenceRepository(ConferenceDbContext conferenceDbContext)
        {
            _conferenceDbContext = conferenceDbContext;
        }

        public int Add(Conference entity)
        {
            _conferenceDbContext.Conferences.Add(entity);

            _conferenceDbContext.SaveChanges();

            return entity.IdConference;
        }

        public void Delete(int id)
        {
            var conf = GetBy(id);
            _conferenceDbContext.Conferences.Remove(conf);
            _conferenceDbContext.SaveChanges();
        }

        public IEnumerable<Conference> Get()
        {
            return _conferenceDbContext.Conferences ?? Enumerable.Empty<Conference>();
        }

        public Conference GetBy(int id)
        {
            return _conferenceDbContext.Conferences.Single(c => c.IdConference == id);
        }

        public void Update(Conference entity)
        {
            _conferenceDbContext.Conferences.Update(entity);
            _conferenceDbContext.SaveChanges();
        }
    }
}