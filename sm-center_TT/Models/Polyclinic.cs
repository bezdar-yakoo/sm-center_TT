using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace sm_center_TT.Models
{
    public class Polyclinic
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        [Comment("The URL of the blog")]
        public int Number { get; set; }
    }
}
