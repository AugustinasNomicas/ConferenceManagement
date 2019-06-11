using ConferenceManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConferenceManagement.Data.Repositories
{
    public class MyAgendaRepository : IMyAgendaRepository
    {
        private readonly ConferenceDbContext _conferenceDbContext;

        public MyAgendaRepository(ConferenceDbContext conferenceDbContext)
        {
            _conferenceDbContext = conferenceDbContext;
        }

        public int Add(MyAgenda entity)
        {
            _conferenceDbContext.MyAgenda.Add(entity);

            _conferenceDbContext.SaveChanges();

            return entity.IdMyAgenda;
        }

        public void Delete(int id)
        {
            var agenda = GetBy(id);
            _conferenceDbContext.Remove(agenda);
            _conferenceDbContext.SaveChanges();
        }

        public IEnumerable<MyAgenda> Get()
        {
            return _conferenceDbContext.MyAgenda;
        }

        public MyAgenda GetBy(int id)
        {
            return _conferenceDbContext.MyAgenda.Single(m => m.IdMyAgenda == id);
        }

        public void Update(MyAgenda entity)
        {
            _conferenceDbContext.MyAgenda.Update(entity);
            _conferenceDbContext.SaveChanges();
        }
    }
}
