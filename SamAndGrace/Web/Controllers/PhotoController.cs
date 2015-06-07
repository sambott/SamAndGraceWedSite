using System.Web.Mvc;

namespace Web.Controllers
{
    public class PhotoController : Controller
    {
        public ActionResult Index()
        {
            return
                Redirect(
                    "https://drive.google.com/folderview?id=0B8IHC9s4FX7zfmRqX2otWDNEOE5qT01UT1dxUkFPVHVRUnduSlNDRWpZcURxOHJzRUlaNTQ&usp=sharing");
        }
    }
}