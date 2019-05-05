using Pro.Exam.Builder.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Pro.Exam.Builder.Domain.Dtos
{
    public class UserDto
    {
        [Required]
        [MaxLengthAttribute(45)]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [MaxLengthAttribute(45)]
        [EmailAddressAttribute()]
        public string Email { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public UserTypeEnum Type { get; set; }
    }
}
