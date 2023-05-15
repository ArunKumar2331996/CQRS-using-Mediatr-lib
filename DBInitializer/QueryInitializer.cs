using Mediator_Pattern.Service;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace Mediator_Pattern.DBInitializer
{
    public class QueryInitializer
    {
        public static async Task<CosmosDBQueryService> InitializeCosmosClientInstanceAsync(IConfigurationSection configurationSection)
        {
            string dbName = configurationSection.GetSection("DatabaseName").Value;
            string containerName = configurationSection.GetSection("ContainerName").Value;
            string accountName = configurationSection.GetSection("Account").Value;
            string key = configurationSection.GetSection("Key").Value;
            Microsoft.Azure.Cosmos.CosmosClient client = new Microsoft.Azure.Cosmos.CosmosClient(accountName, key);
            CosmosDBQueryService cosmosDbService = new CosmosDBQueryService(client, dbName, containerName);
            Microsoft.Azure.Cosmos.DatabaseResponse database = await client.CreateDatabaseIfNotExistsAsync(dbName);
            await database.Database.CreateContainerIfNotExistsAsync(containerName, "/id");

            return cosmosDbService;
        }
    }
}
