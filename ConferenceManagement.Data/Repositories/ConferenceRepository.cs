using ConferenceManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConferenceManagement.Data.Repositories
{
    public class ConferenceRepository : IConferenceRepository
    {
        private readonly List<Conference> _conferencesInMemoryDb = new List<Conference>();

        public ConferenceRepository()
        {
            Add(new Conference
            {
                Name = "BuildStuff",
                Description = "Conference for IT Geeks"
            });

            Add(new Conference
            {
                Name = "Login",
                Description = "Media / tech conference"
            });
        }

        public int Add(Conference entity)
        {
            if (entity.IdConference == 0)
            {
                entity.IdConference = _conferencesInMemoryDb.Count + 1;
            }

            _conferencesInMemoryDb.Add(entity);

            return entity.IdConference;
        }

        public void Delete(int id)
        {
            _conferencesInMemoryDb.RemoveAt(id - 1);
        }

        public IEnumerable<Conference> Get()
        {
            return _conferencesInMemoryDb;
        }

        public Conference GetBy(int id)
        {
            return _conferencesInMemoryDb.Single(c => c.IdConference == id);
        }

        public void Update(Conference entity)
        {
        }
    }
}