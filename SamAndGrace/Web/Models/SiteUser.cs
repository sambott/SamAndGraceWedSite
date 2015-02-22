using Microsoft.AspNet.Identity.EntityFramework;

namespace Web.Models
{
    public class SiteUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}