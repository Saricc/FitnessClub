using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessClubAPI.Models
{
    [Table("Client")]
    public class Client
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("FitnessClub")]
        public int IdFitnessClub { get; set; }

        [Required]
        [MaxLength(50)]
        public required string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public required string LastName { get; set; }
        public long Contact { get; set; }
        public bool? IsMale { get; set; }

        public  List<ClientProgram>? ClientPrograms { get; set; }
        public FitnessClub? FitnessClub { get; set; }
        

    }
}
