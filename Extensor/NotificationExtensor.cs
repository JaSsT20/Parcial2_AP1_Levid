using Radzen;

public static class NotificationExtensor
{
    public static void ShowMessage(this NotificationService notification, string titulo, string mensaje, NotificationSeverity tipo)
    {
        notification.Notify(
            new NotificationMessage{
                Summary = titulo,
                Detail = mensaje,
                Severity = tipo
            }
        );
    }
}