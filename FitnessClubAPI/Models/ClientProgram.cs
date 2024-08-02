using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessClubAPI.Models
{
    [Table("ClientProgram")]
    public class ClientProgram
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdClientProgram { get; set; }

        [ForeignKey("Client")]
        public int IdClient { get; set; }

        [ForeignKey("FitnessProgram")]
        public int IdFitnessProgram { get; set; }

      

        // Navigation property for the related Account entity
        public required Client Client { get; set; }
        public required FitnessProgram FitnessProgram { get; set; }

    }
}
