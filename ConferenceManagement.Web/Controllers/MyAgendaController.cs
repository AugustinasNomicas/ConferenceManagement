using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConferenceManagement.Data.Entities;
using ConferenceManagement.Data.Repositories;
using ConferenceManagement.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ConferenceManagement.Web.Controllers
{
    [Authorize]
    public class MyAgendaController : Controller
    {
        private readonly IConferenceRepository _conferenceRepository;
        private readonly ISpeakerRepository _speakerRepository;
        private readonly IMyAgendaRepository _myAgendaRepository;
        private readonly UserManager<IdentityUser> _userManager;

        public MyAgendaController(IConferenceRepository conferenceRepository,
            ISpeakerRepository speakerRepository, IMyAgendaRepository myAgendaRepository,
            UserManager<IdentityUser> userManager)
        {
            _conferenceRepository = conferenceRepository;
            _speakerRepository = speakerRepository;
            _myAgendaRepository = myAgendaRepository;
            _userManager = userManager;
        }

        public IActionResult AddToAgenda(int id, [FromServices] IHttpContextAccessor HttpContextAccessor)
        {
            var speaker = _speakerRepository.GetBy(id);
            var currentUserId = _userManager.GetUserId(HttpContextAccessor.HttpContext.User);
            _myAgendaRepository.Add(new MyAgenda
            {
                IdSpeaker = speaker.IdSpeaker,
                IdUser = currentUserId
            });

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Index()
        {
            var agendaViewModels = _myAgendaRepository.Get().Select(Map).ToList();
            return View(agendaViewModels);
        }

        private MyAgendaListItemViewModel Map(MyAgenda myAgenda)
        {
            var speaker = _speakerRepository.GetBy(myAgenda.IdSpeaker);
            var conference = _conferenceRepository.GetBy(speaker.IdConference);
            var user = _userManager.Users.Single(u => u.Id == myAgenda.IdUser);

            return new MyAgendaListItemViewModel
            {
                ConferenceName = conference.Name,
                Date = speaker.SpeechDateTime,
                SpeakerName = $"{speaker.FirstName} {speaker.LastName}",
                SpeechName = speaker.SpeechName,
                UserName = user.UserName
            };
        }
    }
}