using Mediator_Pattern.Model;
using Mediator_Pattern.Service;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Mediator_Pattern.Command
{
    public class CreateItemHandler : IRequestHandler<CreateItem, Response>
    {
        private readonly ICosmosDBCommandService _cosmosDbCommandService;
        public CreateItemHandler(ICosmosDBCommandService cosmosDbCommandService)
        {
            _cosmosDbCommandService = cosmosDbCommandService;
        }
        public Task<Response> Handle(CreateItem request, CancellationToken cancellationToken)
        {
            var result = AddItem(request);
            return result;
        }

        private async Task<Response> AddItem(CreateItem createItem)
        {
            var Item = new Item();
            Item.Id = createItem.Id;
            Item.Name = createItem.Name;
            Item.Completed = createItem.Completed;
            Item.Description = createItem.Description;

            await _cosmosDbCommandService.AddItemAsync(Item);
            return new Response
            {
                Data = createItem.Id
            };
        }
    }
}
