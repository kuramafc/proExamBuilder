using Pro.Exam.Builder.Domain.Enums;

namespace Pro.Exam.Builder.Domain.Models
{
    public class UserResponse
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Code { get; set; }
        public UserTypeEnum Type { get; set; }
    }
}
