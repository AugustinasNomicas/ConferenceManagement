using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ConferenceManagement.Data.Entities
{
    public class Speaker
    {
        [Key]
        public int IdSpeaker { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string SpeechName { get; set; }

        public DateTime SpeechDateTime { get; set; }

        public int IdConference { get; set; }
        public Conference Conference { get; set; }
    }
}
