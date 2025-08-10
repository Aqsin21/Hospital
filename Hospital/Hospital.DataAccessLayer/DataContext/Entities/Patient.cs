namespace Hospital.DataAccessLayer.DataContext.Entities
{
    public class Patient:BaseEntity
    {
        public  string? FullName { get; set; }
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public required DateTime? BirthDate { get; set; }
        public  required string? Gender { get; set; }
        public required string? Phone { get; set; }
        public  required string? Address { get; set; }
    }
}
