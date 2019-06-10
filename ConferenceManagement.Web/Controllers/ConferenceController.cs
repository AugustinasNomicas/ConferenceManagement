using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConferenceManagement.Data.Entities;
using ConferenceManagement.Data.Repositories;
using ConferenceManagement.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConferenceManagement.Web.Controllers
{
    public class ConferenceController : Controller
    {
        private readonly IConferenceRepository _conferenceRepository;

        public ConferenceController(IConferenceRepository conferenceRepository)
        {
            _conferenceRepository = conferenceRepository;
        }

        public IActionResult Index()
        {
            var conferenceViewModels = _conferenceRepository.Get().Select(c => new ConferenceViewModel
            {
                IdConference = c.IdConference,
                Name = c.Name,
                Description = c.Description
            });

            return View(conferenceViewModels);
        }

        public IActionResult Edit(int id)
        {
            var c = _conferenceRepository.GetBy(id);
            var conferenceViewModel = new ConferenceViewModel
            {
                IdConference = c.IdConference,
                Name = c.Name,
                Description = c.Description
            };

            return View(conferenceViewModel);
        }

        [HttpPost]
        public IActionResult Edit(ConferenceViewModel conferenceViewModel)
        {
            if (ModelState.IsValid)
            {
                var c = _conferenceRepository.GetBy(conferenceViewModel.IdConference);

                c.Name = conferenceViewModel.Name;
                c.Description = conferenceViewModel.Description;

                return RedirectToAction("Index", "Conference");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Create(ConferenceViewModel conferenceViewModel)
        {
            if (ModelState.IsValid)
            {
                _conferenceRepository.Add(new Conference
                {
                    Name = conferenceViewModel.Name,
                    Description = conferenceViewModel.Description
                });

                return RedirectToAction("Index", "Conference");
            }

            return View();
        }

        public IActionResult Details(int id)
        {
            var c = _conferenceRepository.GetBy(id);
            var conferenceViewModel = new ConferenceViewModel
            {
                IdConference = c.IdConference,
                Name = c.Name,
                Description = c.Description
            };

            return View(conferenceViewModel);
        }

        public IActionResult Delete(int id)
        {
            _conferenceRepository.Delete(id);
            return RedirectToAction("Index", "Conference");
        }
    }
}