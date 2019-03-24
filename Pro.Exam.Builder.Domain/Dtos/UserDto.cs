using Pro.Exam.Builder.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Pro.Exam.Builder.Domain.Dtos
{
    public class UserDto
    {
        [Required]
        [MaxLengthAttribute(45)]
        public string User { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [MaxLengthAttribute(45)]
        [EmailAddressAttribute()]
        public string Email { get; set; }
        [Required]
        public UserTypeEnum Type { get; set; }
    }
}
