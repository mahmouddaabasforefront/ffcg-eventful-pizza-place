namespace FFCG.Eventful.Pizza.Place.Application.Interfaces;

public interface IReceiptProvider
{
    public Task<Receipt> GetReceiptById(Guid id);
    public Task<IEnumerable<Receipt>> GetAllReceipts();
    public Task<Receipt> UpsertReceipt(Receipt receipt);
}