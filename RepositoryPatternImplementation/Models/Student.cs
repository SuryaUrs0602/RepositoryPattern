using System.ComponentModel.DataAnnotations;

namespace RepositoryPatternImplementation.Models
{
    public class Student
    {
        [Key]
        public int StudentRollNumber { get; set; }

        [Required]
        public string StudentName { get; set; } = string.Empty;

        public string CollegeName { get; set; } = string.Empty;

        public string StudentCity { get; set; } = string.Empty;
    }
}
