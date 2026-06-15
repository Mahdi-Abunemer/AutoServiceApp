namespace AutoServiceApp.Models;

public class Part : BaseEntity
{
    public string Name { get; set; } = "";
    public string Article { get; set; } = "";
    public decimal Price { get; set; }
    public int Stock { get; private set; }

    public void SetStock(int stock)
    {
        if (stock < 0)
            return;

        Stock = stock;
    }

    public bool UseStock(int quantity)
    {
        if (quantity <= 0 || Stock < quantity)
            return false;

        Stock -= quantity;
        return true;
    }


    public override string ToString() => $"{Name} [{Article}], {Price:C}, stock {Stock}";
}
