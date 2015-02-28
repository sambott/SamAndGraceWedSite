using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class Artist
    {
        [Key]
        [DisplayName("Artist")]
        public string ArtistName { get; set; }
        public int Votes { get; set; }

        public Artist()
        {
            Votes = 1;
        }

        public void CountVote()
        {
            Votes++;
        }
    }
}