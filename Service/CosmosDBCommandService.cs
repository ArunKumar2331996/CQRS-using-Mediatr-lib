using Mediator_Pattern.Model;
using Microsoft.Azure.Cosmos;
using System.Threading.Tasks;

namespace Mediator_Pattern.Service
{
    public class CosmosDBCommandService: ICosmosDBCommandService
    {
        private Container _container;
        public CosmosDBCommandService(CosmosClient cosmosClient, string dbName, string containerName)
        {
            this._container = cosmosClient.GetContainer(dbName, containerName);
        }

        public async Task AddItemAsync(Item item)
        {
            await this._container.CreateItemAsync<Item>(item, new PartitionKey(item.Id));
        }

        public async Task DeleteItemAsync(string id)
        {
            await this._container.DeleteItemAsync<Item>(id, new PartitionKey(id));
        }

        public async Task UpdateItemAsync(string id, Item item)
        {
            await this._container.UpsertItemAsync<Item>(item, new PartitionKey(id));
        }
    }

    public interface ICosmosDBCommandService
    {
        Task AddItemAsync(Item item);
        Task UpdateItemAsync(string id, Item item);
        Task DeleteItemAsync(string id);
    }
}
