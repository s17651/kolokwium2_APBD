using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace kolpkwium2_APBD.Models
{
    public class Event
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEvent { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name{ get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public virtual ICollection<ArtistEvent> ArtistEvent { get; set; }

        public virtual ICollection<EventOrganiser> EventOrganiser { get; set; }
    }
}
