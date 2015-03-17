using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Models;

namespace Web.DAL
{
    public class ArtistRepository : GenericRepository<SamAndGraceContext, Artist>
    {
        public ArtistRepository()
        {
        }
    }
}