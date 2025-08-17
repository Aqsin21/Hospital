namespace Hospital.DataAccessLayer.DataContext.Entities
{
    public class Room:BaseEntity
    {
        public required int RoomNumber { get; set; }
        public required string Type { get; set; } // ICU, Normal, Private
        public bool IsAvailable { get; set; }
    }
}
