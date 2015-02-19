using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Web.Models;

namespace Web.DAL
{
    public class SamAndGraceContext : DbContext
    {
        public SamAndGraceContext() : base("DefaultConnection") { }

        public DbSet<Rsvp> Rsvps { get; set; }
    }
}