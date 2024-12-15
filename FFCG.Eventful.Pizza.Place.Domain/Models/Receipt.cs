using FFCG.Eventful.Pizza.Place.Domain.Models;

public class Receipt
{
    public Guid Id { get; init; } = Guid.NewGuid();

    public required Customer Customer { get; set; }

    public required Order Order { get; set; }
}