using FFCG.Eventful.Pizza.Place.Application.Interfaces;
using MediatR;

namespace FFCG.Eventful.Pizza.Place.Application.Features.CreateNewReceipt;

public record CreateNewReceiptCommand(int TotalCost, string[] Items) : IRequest<Receipt>;

public class CreateNewReceiptHandler(IReceiptProvider _provider) : IRequestHandler<CreateNewReceiptCommand, Receipt>
{
    public async Task<Receipt> Handle(CreateNewReceiptCommand request, CancellationToken cancellationToken)
    {
        return await _provider.UpsertReceipt(new Receipt()
        {
            TotalCost = request.TotalCost,
            Items = request.Items
        });
    }
}