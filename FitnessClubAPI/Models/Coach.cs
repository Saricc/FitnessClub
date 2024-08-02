using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessClubAPI.Models
{
    [Table("Coach")]
    public class Coach
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCoach { get; set; }

        [ForeignKey("FitnessClub")]
        public int IdFitnessClub { get; set; }

        [ForeignKey("FitnessProgram")]
        public int IdProgram { get; set; }

        [Required]
        [MaxLength(50)]
        public required string Firstname { get; set; }

        [Required]
        [MaxLength(50)]
        public required string Lastname { get; set; }

        [Required]
        [MaxLength(50)]
        public long Contact { get; set; }

        public bool? Male { get; set; }
     

        // Navigation properties
        public virtual FitnessClub? FitnessClub { get; set; }
        public virtual FitnessProgram? FitnessProgram { get; set; }



    }
}
