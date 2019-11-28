using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace ChinookPlayground.Domain.Models
{
    [DebuggerDisplay("{Name} (ArtistId = {ArtistId})")]
    [Table("Artist")]
    public class Artist
    {
        [Key]
        public int ArtistId { get; set; }

        [Required, MaxLength(120)]
        public string Name { get; set; }
    }
}
