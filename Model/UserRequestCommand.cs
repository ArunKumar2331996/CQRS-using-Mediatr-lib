using MediatR;

namespace Mediator_Pattern.Model
{
    public class UserRequestCommand: IRequest<UserResponse>
    {
        public int  UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
