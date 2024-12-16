public class Receipt
{
    public Guid Id { get; init; } = Guid.NewGuid();

    public int TotalCost { get; set; }

    public required string[] Items { get; set; }


}