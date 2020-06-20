using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolpkwium2_APBD.Models
{
    public class ArtistEventResponse
    {
        public Artist Artist { get; set; }

        public ICollection<Event> Events { get; set; }
    }
}
