using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sm_center_TT.Models
{
    public class Doctor
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [RegularExpression(@"^[А-Яа-я]*.[А-Яа-я]*.([А-Яа-я]*|.)$", ErrorMessage = "Некорекстное ФИО")]
        [Required]
        public string FullName { get; set; }

        [Required]
        public int CabinetId { get; set; }

        [Required]
        public int SpecializationId { get; set; }

        public int? PolyclinicId { get; set; }
    }
}
