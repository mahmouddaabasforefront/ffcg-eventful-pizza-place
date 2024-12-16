using FFCG.Eventful.Pizza.Place.Application.Interfaces;
using FFCG.Eventful.Pizza.Place.Domain.Models;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;

namespace FFCG.Eventful.Pizza.Place.Cosmos;

public class ReceiptProvider : IReceiptProvider
{
    private readonly Container _container;

    public ReceiptProvider(CosmosClient cosmosClient)
    {
        _container = cosmosClient.GetContainer("ffcg-eventful-pizza-place", "receipts-mahmoud");
    }

    public async Task<Receipt> GetReceiptById(Guid id)
    {
        return await _container.ReadItemAsync<Receipt>(id.ToString(), new PartitionKey(id.ToString()));
    }

    public async Task<IEnumerable<Receipt>> GetAllReceipts()
    {
        var iterator = _container
    .GetItemLinqQueryable<Receipt>()
    .Where(x => x.Id != Guid.Empty);

        return await iterator.ToFeedIterator().ReadNextAsync();
    }

    public async Task<Receipt> UpsertReceipt(Receipt receipt)
    {
        var result = await _container.UpsertItemAsync(
    receipt,
    new PartitionKey(receipt.Id.ToString())
    );

        return result.Resource;
    }
}