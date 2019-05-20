using Pro.Exam.Builder.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Pro.Exam.Builder.Domain.Dtos
{
    public class UserDto
    {
        [Required]
        public string Password { get; set; }
        [Required]
        [MaxLengthAttribute(45)]
        [EmailAddressAttribute()]
        public string Email { get; set; }
    }
}
