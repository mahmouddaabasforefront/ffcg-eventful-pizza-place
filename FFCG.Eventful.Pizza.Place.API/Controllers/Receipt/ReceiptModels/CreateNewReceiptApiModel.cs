using FFCG.Eventful.Pizza.Place.Application.Features.CreateNewReceipt;

namespace FFCG.Eventful.Pizza.Place.Controllers.Receipt.ApiModels;

public record CreateNewReceiptApiModel(int TotalCost, string[] Items)
{
    public CreateNewReceiptCommand MapToCommand()
        => new(TotalCost, Items);
}