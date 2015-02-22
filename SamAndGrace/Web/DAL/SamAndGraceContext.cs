using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Web.Models;

namespace Web.DAL
{
    public class SamAndGraceContext : IdentityDbContext<SiteUser>
    {
        public SamAndGraceContext() : base("DefaultConnection") { }

        public DbSet<Rsvp> Rsvps { get; set; }
    }
}