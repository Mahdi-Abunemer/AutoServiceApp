namespace AutoServiceApp.Services;

public class NotificationFacade
{
    public SmsNotifier Sms { get; }
    public EmailSender Email { get; }

    public NotificationFacade(SmsNotifier sms, EmailSender email)
    {
        Sms = sms;
        Email = email;
    }

    public void Notify(NotificationType type, string phone, string email, string title, string message)
    {
        if (type == NotificationType.Sms)
            Sms.SendSms(phone, message);
        else if (type == NotificationType.Email)
            Email.Send(email, title, message);
        else
        {
            Sms.SendSms(phone, message);
            Email.Send(email, title, message);
        }
    }
}

public enum NotificationType
{
    Sms,
    Email,
    Both
}
