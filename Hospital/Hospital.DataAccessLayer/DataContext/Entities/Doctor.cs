namespace Hospital.DataAccessLayer.DataContext.Entities
{
    public class Doctor
    {
        public required string FullName { get; set; }
        public int DepatmentId { get; set; }
        public required Department Department { get; set; }
        public required string Description { get; set; }

    }
}
