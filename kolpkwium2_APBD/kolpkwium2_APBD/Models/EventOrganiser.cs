using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace kolpkwium2_APBD.Models
{
    public class EventOrganiser
    {
        public int IdEvent { get; set; }
        [ForeignKey("IdEvent")]
        public virtual Event Event { get; set; }

        public int IdOrganiser { get; set; }
        [ForeignKey("IdOrganiser")]
        public Organiser Organiser { get; set; }
    }
}
