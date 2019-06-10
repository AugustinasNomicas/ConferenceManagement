using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ConferenceManagement.Web.Models
{
    public class SpeakerViewModel
    {
        [DisplayName("Id")]
        public int IdSpeaker { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string SpeechName { get; set; }

        public DateTime SpeechDateTime { get; set; }

        [DisplayName("Conference")]
        public int IdConference { get; set; }

        [DisplayName("Conference")]
        public string ConferenceName { get; set; }

        public List<SelectListItem> Conferences { get; set; }
    }
}
