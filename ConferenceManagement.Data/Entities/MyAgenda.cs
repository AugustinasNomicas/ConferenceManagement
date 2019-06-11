using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ConferenceManagement.Data.Entities
{
    public class MyAgenda
    {
        [Key]
        public int IdMyAgenda { get; set; }

        public string IdUser { get; set; }

        public int IdSpeaker { get; set; }
    }
}
