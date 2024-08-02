

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessClubAPI.Models
{
    [Table("FitnessClub")]
    public class FitnessClub
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdFitnessClub { get; set; }

        [Required]
        [MaxLength(50)]
        public required string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public required string Email { get; set; }

        [Required]
        [MaxLength(50)]
        public required string Address { get; set; }

        // Navigation property for related Account entities
        public required IList<Client> Clients { get; set; }
        public required IList<Coach> Coaches { get; set; }

    }
}
