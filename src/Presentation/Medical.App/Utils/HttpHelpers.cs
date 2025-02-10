using Microsoft.AspNetCore.Components;
using Radzen;

namespace Medical.App.Utils
{
    public static class HttpHelpers
    {
        public static void HandleRequestException(HttpRequestException ex, NavigationManager navigationManager, NotificationService notificationService)
        {
            var notification = new NotificationMessage
            {
                Severity = NotificationSeverity.Error,
                Summary = "Error",
                Detail = string.Empty,
                Duration = 2000
            };
            if (ex.Message.Contains("400"))
            {
                notification.Detail = "Hubo un error en la petición realizada.";
            }
            if (ex.Message.Contains("404"))
            {
                notification.Detail = "No se encontró el recurso solicitado.";
            }
            if (ex.Message.Contains("401"))
            {
                notification.Detail = "Usuario no autorizado.";
            }
            if (ex.Message.Contains("403"))
            {
                notification.Detail = "Usuario no autenticado.";
            }
            if (string.IsNullOrWhiteSpace(notification.Detail))
            {
                notification.Detail = $"Algo salió mal, por favor contactar al Administrador. | {ex.Message}";
            }
            notificationService.Notify(notification);
            if (!ex.Message.Contains("400"))
            {
                navigationManager.NavigateTo("/login");
            }
        }
    }
}