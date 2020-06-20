using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace kolpkwium2_APBD.Models
{
    public class ArtistEvent
    {
        public int IdEvent { get; set; }
        [ForeignKey("IdEvent")]
        public virtual Event Event { get; set; }

        public int IdArtist { get; set; }
        [ForeignKey("IdArtist")]
        public Artist Artist { get; set; }

        public DateTime PerformanceDate { get; set; }
    }
}
