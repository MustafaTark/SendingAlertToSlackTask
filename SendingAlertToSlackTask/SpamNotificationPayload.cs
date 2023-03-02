namespace SendingAlertToSlackTask
{
    public class SpamNotificationPayload
    {
       public string? RecordType { get; set; }
        public string? Type { get; set; }
        public int? TypeCode { get; set; }
        public string? Name { get; set; }
        public string? Tag { get; set; }
        public string? MessageStream { get; set; }
        public string? Description { get; set; }
        public string? Email { get; set; }
        public string? From { get; set; }
        public DateTime BouncedAt { get; set; }

    }
}
