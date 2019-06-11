using ConferenceManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConferenceManagement.Data.Repositories
{
    public class SpeakerRepository : ISpeakerRepository
    {
        private readonly List<Speaker> _speakersInMemoryDb = new List<Speaker>();

        public SpeakerRepository()
        {
            Add(new Speaker { FirstName = "John", LastName = "Travolta", IdConference = 1, SpeechName = "Test", SpeechDateTime = new DateTime(2019, 09, 01) });
            Add(new Speaker { FirstName = "Luke", LastName = "Skywalker", IdConference = 2, SpeechName = "Test 2", SpeechDateTime = new DateTime(2019, 10, 01) });
        }

        public int Add(Speaker entity)
        {
            if (entity.IdSpeaker == 0)
            {
                entity.IdSpeaker = _speakersInMemoryDb.Count + 1;
            }

            _speakersInMemoryDb.Add(entity);

            return entity.IdConference;
        }

        public void Delete(int id)
        {
            _speakersInMemoryDb.RemoveAt(id - 1);
        }

        public IEnumerable<Speaker> Get()
        {
            return _speakersInMemoryDb;
        }

        public Speaker GetBy(int id)
        {
            return _speakersInMemoryDb.Single(c => c.IdSpeaker == id);
        }

        public void Update(Speaker entity)
        {

        }
    }
}
