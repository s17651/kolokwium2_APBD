using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolpkwium2_APBD.Models
{
    public class ArtistEventRequest
    {
        public int IdArtist { get; set; }

        public int IdEvent { get; set; }

        public DateTime PerformanceDate { get; set; }
    }
}
