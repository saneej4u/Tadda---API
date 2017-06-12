namespace Tadda.Model.Entities
{
    public class Notification
    {
        public int NotificationId { get; set; }
        public int OrderId { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }

        public int EnduserId { get; set; }
    }
}