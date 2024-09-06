using System.ComponentModel.DataAnnotations;

namespace sm_center_TT.Models
{
    public class Specialization
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name  { get; set; }
    }
}
