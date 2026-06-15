namespace AutoServiceApp.Services;

public class EmailSender
{
    private readonly List<string> _log = new();

    public IReadOnlyList<string> Log => _log;

    public void Send(string email, string subject, string body)
    {
        _log.Add($"EMAIL {DateTime.Now:g} -> {email}: {subject} {body}");
    }
}
