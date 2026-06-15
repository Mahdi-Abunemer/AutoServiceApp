namespace AutoServiceApp.Models;

public class Mechanic : BaseEntity
{
    private readonly List<string> _assignedOrderIds = new();

    public string Name { get; set; } = "";
    public string Specialization { get; set; } = "";
    public decimal HourRate { get; set; }
    public IReadOnlyList<string> AssignedOrderIds => _assignedOrderIds;

    public void AssignOrder(string orderId)
    {
        if (!_assignedOrderIds.Contains(orderId))
            _assignedOrderIds.Add(orderId);
    }

    public void RemoveOrder(string orderId)
    {
        _assignedOrderIds.Remove(orderId);
    }

    public void ReplaceAssignedOrders(IEnumerable<string> orderIds)
    {
        _assignedOrderIds.Clear();

        foreach (var orderId in orderIds)
            AssignOrder(orderId);
    }

    public override string ToString() => $"{Name} - {Specialization}, {HourRate:C}/h";
}
