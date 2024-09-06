using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sm_center_TT.Models
{
    public class Patient
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        [RegularExpression(@"^[А-Яа-я]*$", ErrorMessage = "Некорекстное имя")]
        public string FirstName { get; set; }
        [Required]
        [RegularExpression(@"^[А-Яа-я]*$", ErrorMessage = "Некорекстное фамилия")]
        public string SecondName { get; set; }
        [Required]
        [RegularExpression(@"^[А-Яа-я]*$", ErrorMessage = "Некорекстное отчество")]
        public string? MiddleName { get; set; }
        [Required]
        public string Adderss { get; set; }
        [Required]
        public DateTime? BirthDay { get; set; }
        [Required]
        public bool IsMale { get; set; }
        public int PolyclinicId { get; set; }


    }
}
