using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FitnessClubAPI.Models
{
    [Table("FitnessProgram")]
    public class FitnessProgram
    {
        public FitnessProgram() 
        { 
            ClientPrograms = new List<ClientProgram>();
            Coaches = new List<Coach>();
        }
        
       
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdFitnessProgram { get; set; }

        [Required]
        [MaxLength(50)]
        public required string Name { get; set; }

        public  IList<ClientProgram> ClientPrograms { get; set; }
        public  IList<Coach> Coaches { get; set; }

    }
}
