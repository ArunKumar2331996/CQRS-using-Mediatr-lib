using MediatR;

namespace Mediator_Pattern.Model
{
    public class DeleteItem: IRequest<Response>
    {
        public DeleteItem(string id)
        {
            Id = id;
        }
        public string Id { get; set; }
    }
}
