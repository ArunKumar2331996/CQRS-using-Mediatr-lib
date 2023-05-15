using Mediator_Pattern.Model;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Mediator_Pattern.Handler
{
    public class LoginHandler : IRequestHandler<UserRequestCommand, UserResponse>
    {
        public async Task<UserResponse> Handle(UserRequestCommand request, CancellationToken cancellationToken)
        {
            UserResponse userResponse = new UserResponse { IsAuthenticated = true,Token="afadsfadfasfa"};
            return await Task.FromResult(userResponse);
        }
    }
}
