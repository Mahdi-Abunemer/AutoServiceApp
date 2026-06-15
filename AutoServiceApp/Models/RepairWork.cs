namespace AutoServiceApp.Models;

public class RepairWork : BaseEntity
{
    public string Name { get; set; } = "";
    public double Hours { get; private set; }
    public decimal Cost { get; private set; }

    public void SetHours(double hours)
    {
        if (hours < 0)
            return;

        Hours = hours;
    }

    public void SetCost(decimal cost)
    {
        if (cost < 0)
            return;

        Cost = cost;
    }

    public override string ToString() => $"{Name} - {Hours} h - {Cost:C}";
}
