using AutoServiceApp.Models;

namespace AutoServiceApp.Services;

public class OrderCostCalculator
{
    private const decimal PartCostMultiplier = 1.20m;
    private const decimal CardPaymentFeeRate = 0.05m;
    private const int LoyaltyCarCount = 2;
    private const decimal LoyaltyDiscountRate = 0.10m;
    private const decimal ReadyOrderFee = 500m;
    private const decimal LargeOrderDiscountLimit = 10000m;
    private const decimal LargeOrderDiscountRate = 0.15m;

    public decimal CalculateOrderCost(
        RepairOrder order,
        bool final,
        string paymentMethod,
        List<Part> parts)
    {
        var works = order.Works
            .Sum(
            x => x.Cost +
            (decimal)x.Hours
            * (order.AssignedMechanic?.HourRate ?? 0));

        var usedParts = order
            .UsedPartIds
            .Select(id => parts.FirstOrDefault(p => p.Id == id))
            .Where(p => p != null).Sum(p => p!.Price * PartCostMultiplier);

        var result = works + usedParts;
        if (paymentMethod == "card")
            result += result * CardPaymentFeeRate;
        if (order.Customer != null && order.Customer.Cars.Count > LoyaltyCarCount)
            result -= result * LoyaltyDiscountRate;
        if (final && order.Status == "Ready")
            result += ReadyOrderFee;

        var discount = result > LargeOrderDiscountLimit ? result * LargeOrderDiscountRate : 0;

        return result - discount;
    }
}