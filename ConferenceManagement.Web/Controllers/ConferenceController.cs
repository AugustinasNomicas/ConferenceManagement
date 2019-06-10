using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConferenceManagement.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConferenceManagement.Web.Controllers
{
    public class ConferenceController : Controller
    {
        public IActionResult Index()
        {
            return View(new List<ConferenceViewModel>()
            {
                new ConferenceViewModel() { IdConference = 1, Name ="Test", Description = "Desc"}
            });
        }
    }
}