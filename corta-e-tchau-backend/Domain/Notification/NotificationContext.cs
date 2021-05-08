using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace corta_e_tchau_backend.Domain.Notification
{
    public class NotificationContext
    {
        private readonly List<Notification> _notifications;
        public IReadOnlyCollection<Notification> Notifications => _notifications;
        public bool HasNotifications => _notifications.Any();

        public NotificationContext()
        {
            _notifications = new List<Notification>();
        }

        public void AddNotification(string message)
        {
            _notifications.Add(new Notification(message));
        }

        public void AddNotifications(ValidationResult validationResult)
        {
            AddNotification(validationResult.ErrorMessage);
        }
    }
}
