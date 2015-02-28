using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class Track
    {
        [Key]
        [ColumnAttribute(Order = 0)]
        [DisplayName("Track")]
        public string TrackName { get; set; }
        [Key]
        [ColumnAttribute(Order = 1)]
        [ForeignKey("Artist")]
        [DisplayName("Artist")]
        public string ArtistName { get; set; }
        public int Votes { get; set; }
        public virtual Artist Artist { get; set; }

        public Track()
        {
            Votes = 1;
        }

        public void CountVote()
        {
            Votes++;
        }
    }
}