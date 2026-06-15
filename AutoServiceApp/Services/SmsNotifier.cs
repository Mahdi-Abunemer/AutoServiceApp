namespace AutoServiceApp.Services;

public class SmsNotifier
{
    private readonly List<string> _sentMessages = new();

    public IReadOnlyList<string> SentMessages => _sentMessages;

    public void SendSms(string phone, string text)
    {
        _sentMessages.Add($"SMS {DateTime.Now:g} -> {phone}: {text}");
    }
}
