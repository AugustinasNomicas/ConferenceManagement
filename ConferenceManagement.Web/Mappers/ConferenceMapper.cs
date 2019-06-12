using ConferenceManagement.Data.Entities;
using ConferenceManagement.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConferenceManagement.Web.Mappers
{
    public static class ConferenceMapper
    {
        public static ConferenceViewModel ToViewModel(this Conference conference)
        => new ConferenceViewModel
        {
            IdConference = conference.IdConference,
            Name = conference.Name,
            Description = conference.Description
        };

        public static Conference ToModel(this ConferenceViewModel conferenceViewModel)
        => new Conference
        {
            IdConference = conferenceViewModel.IdConference,
            Name = conferenceViewModel.Name,
            Description = conferenceViewModel.Description,
        };
    }
}
