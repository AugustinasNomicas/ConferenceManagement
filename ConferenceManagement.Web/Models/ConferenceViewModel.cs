using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ConferenceManagement.Web.Models
{
    public class ConferenceViewModel
    {
        [DisplayName("ID")]
        public int IdConference { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
    }
}
