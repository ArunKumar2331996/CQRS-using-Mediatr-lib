using Mediator_Pattern.Model;
using Mediator_Pattern.Service;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Mediator_Pattern.Query
{
    public class GetItemByIdHandler : IRequestHandler<GetItemById, Item>
    {
        private readonly ICosmosDBQueryService _cosmosDBQueryService;
        public GetItemByIdHandler(ICosmosDBQueryService cosmosDBQueryService)
        {
            _cosmosDBQueryService = cosmosDBQueryService;
        }
        public Task<Item> Handle(GetItemById request, CancellationToken cancellationToken)
        {
            var response = _cosmosDBQueryService.GetItemAsync(request.Id);
            return response;
        }
    }
}
