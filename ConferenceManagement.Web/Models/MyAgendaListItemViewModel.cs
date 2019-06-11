using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConferenceManagement.Web.Models
{
    public class MyAgendaListItemViewModel
    {
        public DateTime Date { get; set; }
        public string ConferenceName { get; set; }
        public string SpeechName { get; set; }
        public string SpeakerName { get; set; }
        public string UserName { get; set; }
    }
}
