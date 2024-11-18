using System.ComponentModel.DataAnnotations;

namespace QuanLyCV.Models {
    public class EmployeeCV {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Range(18, 40)]
        public int Age { get; set; }

        [Display(Name = "Profile Picture")]
        public string? ProfilePicture { get; set; }

        [Required]
        [Phone]
        [StringLength(15)]
        public string PhoneNumber { get; set; } = string.Empty;
        
        [Required]
        public string Degree { get; set; } = string.Empty;

        public string Certifications { get; set; } = string.Empty;
    }
}