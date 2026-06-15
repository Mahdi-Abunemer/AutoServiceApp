using AutoServiceApp.Models;

namespace AutoServiceApp.Helpers;

public class OrderStatusHelper
{
    public List<string> CommonStatuses { get; set; } = new() { "New", "Diagnostics", "In Progress", "Waiting for Parts", "Ready", "Released" };
}
