using FitnessApp.API.Domain.Models;

namespace FitnessApp.API.Domain.Services.Communication
{
    public class UserResponse : BaseResponse
    {
        public User _User { get; private set; }
        
        private UserResponse(bool success, string message, User user) : base(success, message)
        {
            _User = user;
        }

        public UserResponse(User user) : this(true, string.Empty,user)
        {
        }

        public UserResponse(string message) : this(false, message, null)
        {
        }
    }
}