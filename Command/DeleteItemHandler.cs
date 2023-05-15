using Mediator_Pattern.Model;
using Mediator_Pattern.Service;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Mediator_Pattern.Command
{
    public class DeleteItemHandler : IRequestHandler<DeleteItem, Response>
    {
        private readonly ICosmosDBCommandService _cosmosDBCommandService;
        public DeleteItemHandler(ICosmosDBCommandService cosmosDBCommandService)
        {
            _cosmosDBCommandService = cosmosDBCommandService;
        }
        public Task<Response> Handle(DeleteItem request, CancellationToken cancellationToken)
        {
            var res = DeleteItem(request.Id);
            return res;
        }

        public async Task<Response> DeleteItem(string id)
        {
            await _cosmosDBCommandService.DeleteItemAsync(id);
            return new Response() { Data = id };
        }
    }
}
