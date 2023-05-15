using MediatR;

namespace Mediator_Pattern.Model
{
    public class GetItemById: IRequest<Item>
    {
        public GetItemById(string id)
        {
            Id = id;
        }
        public string Id { get; set; }
    }
}
