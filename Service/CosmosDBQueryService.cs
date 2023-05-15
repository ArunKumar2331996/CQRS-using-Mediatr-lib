using Mediator_Pattern.Model;
using Microsoft.Azure.Cosmos;
using System.Threading.Tasks;

namespace Mediator_Pattern.Service
{
    public class CosmosDBQueryService : ICosmosDBQueryService
    {
        private Container _container;
        public CosmosDBQueryService(CosmosClient cosmosClient, string dbName, string containerName)
        {
            this._container = cosmosClient.GetContainer(dbName, containerName);
        }
        public async Task<Item> GetItemAsync(string id)
        {
            try
            {
                ItemResponse<Item> response = await this._container.ReadItemAsync<Item>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }

        }
    }

    public interface ICosmosDBQueryService
    {
        Task<Item> GetItemAsync(string id);
    }
}
