namespace AutoServiceApp.Models;

public class Car : BaseEntity
{
    public string CustomerId { get; set; } = "";
    [System.Text.Json.Serialization.JsonIgnore]
    public Customer? Owner { get; set; }
    public string Make { get; set; } = "";
    public string Model { get; set; } = "";
    public int Year { get; set; }
    public string Vin { get; set; } = "";
    public string LicensePlate { get; set; } = "";
    public int Mileage { get; private set; }

    public void UpdateMileage(int mileage)
    {
        if (mileage < Mileage)
            return;

        Mileage = mileage;
    }

    public override string ToString() => $"{Make} {Model}, {LicensePlate}, {Year}, {Mileage} km";
}
