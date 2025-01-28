using System;
using System.ComponentModel.DataAnnotations;

namespace StudentModelForm.Models
{
    public class Student
    {
        public required int Id { get; set; }

        [StringLength(100)]
        public string? FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public required string LastName { get; set; }

        [Required]
        [Range(18, 100, ErrorMessage = "Age must be between 18 and 100.")]
        public int Age { get; set; }

        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Phone]
        public string? PhoneNumber { get; set; }

        public DateTime EnrollmentDate { get; set; }
    }
}
