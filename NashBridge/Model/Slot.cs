namespace NashBridge.Model
{
    public class Slot
    {
        public Guid Id { get; set; }
        public Guid MentorId { get; set; }
        public Guid MenteeId { get; set; }
        public DateTime SlotTime { get; set; }
        public string Description { get; set; }
        public bool IsBooked { get; set; }
    }
}
