using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConferenceManagement.Data.Entities;
using ConferenceManagement.Data.Repositories;
using ConferenceManagement.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConferenceManagement.Web.Controllers
{
    public class SpeakerController : Controller
    {
        private readonly ISpeakerRepository _speakerRepository;

        private List<Conference> _conferences;

        public SpeakerController(ISpeakerRepository speakerRepository, IConferenceRepository conferenceRepository)
        {
            _speakerRepository = speakerRepository;

            _conferences = conferenceRepository.Get().ToList();
        }

        // GET: Speaker
        public ActionResult Index()
        {
            var speakers = _speakerRepository.Get().Select(s => Map(s, _conferences));
            return View(speakers);
        }

        // GET: Speaker/Details/5
        public ActionResult Details(int id)
        {
            return View(Map(_speakerRepository.GetBy(id), _conferences));
        }

        public ActionResult Create(SpeakerViewModel speakerViewModel)
        {
            if (ModelState.IsValid)
            {
                _speakerRepository.Add(Map(speakerViewModel));
                return RedirectToAction("Index", "Speaker");
            }

            if (speakerViewModel.Conferences == null)
            {
                speakerViewModel.Conferences = _conferences.Select(Map).ToList();
            }

            return View(speakerViewModel);
        }

        // GET: Speaker/Edit/5
        public ActionResult Edit(int id)
        {
            var s = Map(_speakerRepository.GetBy(id), _conferences);
            return View(s);
        }

        // POST: Speaker/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SpeakerViewModel speakerViewModel)
        {
            if (ModelState.IsValid)
            {
                var s = _speakerRepository.GetBy(speakerViewModel.IdSpeaker);

                s.IdSpeaker = speakerViewModel.IdSpeaker;
                s.IdConference = speakerViewModel.IdConference;
                s.FirstName = speakerViewModel.FirstName;
                s.LastName = speakerViewModel.LastName;
                s.SpeechDateTime = speakerViewModel.SpeechDateTime;
                s.SpeechName = speakerViewModel.SpeechName;

                return RedirectToAction("Index", "Speaker");
            }
            else
            {
                return View();
            }
        }

        // GET: Speaker/Delete/5
        public ActionResult Delete(int id)
        {
            _speakerRepository.Delete(id);
            return RedirectToAction("Index", "Speaker");
        }

        private SpeakerViewModel Map(Speaker speaker, List<Conference> conferences) =>
            new SpeakerViewModel
            {
                IdSpeaker = speaker.IdSpeaker,
                IdConference = speaker.IdConference,
                FirstName = speaker.FirstName,
                LastName = speaker.LastName,
                SpeechDateTime = speaker.SpeechDateTime,
                SpeechName = speaker.SpeechName,
                Conferences = conferences.Select(Map).ToList(),
                ConferenceName = conferences.FirstOrDefault(c => c.IdConference == speaker.IdConference).Name
            };

        private Speaker Map(SpeakerViewModel speaker) =>
            new Speaker
            {
                IdSpeaker = speaker.IdSpeaker,
                IdConference = speaker.IdConference,
                FirstName = speaker.FirstName,
                LastName = speaker.LastName,
                SpeechDateTime = speaker.SpeechDateTime,
                SpeechName = speaker.SpeechName,
            };

        private Microsoft.AspNetCore.Mvc.Rendering.SelectListItem Map(Conference c) =>
            new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Value = c.IdConference.ToString(), Text = c.Name };
    }
}