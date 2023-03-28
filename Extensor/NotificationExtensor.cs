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
    public static void Guardado(this NotificationService notification)
    {
        notification.Notify(
            new NotificationMessage{
                Summary = "Guardar",
                Detail = "Se ha guardado correctamente.",
                Severity = NotificationSeverity.Success
            }
        );
    }
    public static void Advertencia(this NotificationService notification, string mensaje)
    {
        notification.Notify(
            new NotificationMessage{
                Summary = "Advertencia",
                Detail = mensaje,
                Severity = NotificationSeverity.Warning
            }
        );
    }
}