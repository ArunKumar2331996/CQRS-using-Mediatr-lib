using Mediator_Pattern.Model;
using Mediator_Pattern.Service;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Mediator_Pattern.Command
{
    public class UpdateItemHandler : IRequestHandler<UpdateItem,Response>
    {
        private readonly ICosmosDBCommandService _cosmosDBCommandService;
        public UpdateItemHandler(ICosmosDBCommandService cosmosDBCommandService)
        {
            _cosmosDBCommandService = cosmosDBCommandService;
        }
        public Task<Response> Handle(UpdateItem request, CancellationToken cancellationToken)
        {
            var result = UpdateItem(request, request.Id);
            return result;
        }

        private async Task<Response> UpdateItem(UpdateItem updateItem,string id)
        {
            var Item = new Item();
            Item.Id = id;
            Item.Name = updateItem.Name;
            Item.Description = updateItem.Description;
            Item.Completed = updateItem.Completed;
            await _cosmosDBCommandService.UpdateItemAsync(id,Item);

            return new Response()
            {
                Data = updateItem.Id
            };
        }
    }
}
