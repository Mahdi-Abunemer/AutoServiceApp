namespace AutoServiceApp.Models;

public class Customer : BaseEntity
{
    private readonly List<Car> _cars = new();

    public string Name { get; set; } = "";
    public string Phone { get; set; } = "";
    public string Email { get; set; } = "";
    public string Address { get; set; } = "";
    [System.Text.Json.Serialization.JsonIgnore]
    public IReadOnlyList<Car> Cars => _cars;
    public string LastPaymentMethod { get; set; } = "cash";

    public void AddCar(Car car)
    {
        if (!_cars.Contains(car))
            _cars.Add(car);
    }

    public void RemoveCar(Car car)
    {
        _cars.Remove(car);
    }

    public void ReplaceCars(IEnumerable<Car> cars)
    {
        _cars.Clear();
        _cars.AddRange(cars);
    }

    public string Export() => $"{Name};{Phone};{Email};{Address}";
    public override string ToString() => string.IsNullOrWhiteSpace(Phone) ? Name : $"{Name} ({Phone})";
}
