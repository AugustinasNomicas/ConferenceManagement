using ConferenceManagement.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConferenceManagement.Data
{
    public class ConferenceDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<Conference> Conferences { get; set; }

        public ConferenceDbContext(DbContextOptions<ConferenceDbContext> options) : base(options)
        {

        }
    }
}
