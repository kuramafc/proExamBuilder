using Pro.Exam.Builder.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Pro.Exam.Builder.Domain.Dtos
{
    public class RegisterUserDto : UserDto
    {
        [Required]
        [MaxLengthAttribute(45)]
        public string UserName { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public UserTypeEnum Type { get; set; }
    }
}
