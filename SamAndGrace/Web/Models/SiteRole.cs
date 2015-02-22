using Microsoft.AspNet.Identity.EntityFramework;

namespace Web.Models
{
    public class SiteRole : IdentityRole
    {
        public SiteRole()
        {
        }

        public SiteRole(string name, string description) : base(name)
        {
            Description = description;
        }

        public string Description { get; set; }
    }
}