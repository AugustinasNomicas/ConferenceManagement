﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ConferenceManagement.Data.Entities
{
    public class Conference
    {
        public int IdConference { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public List<Speaker> Speakers { get; set; } = new List<Speaker>();
    }
}