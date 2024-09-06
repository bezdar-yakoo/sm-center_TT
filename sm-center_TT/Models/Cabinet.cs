using System.ComponentModel.DataAnnotations;

namespace sm_center_TT.Models
{
    public class Cabinet
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        public int Number { get; set; }
    }
}
