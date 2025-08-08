namespace Hospital.DataAccessLayer.DataContext.Entities
{
    public class Patient:BaseEntity
    {
        public  required string FullName { get; set; }
        public required DateTime BirthDate { get; set; }
        public  required string Gender { get; set; }
        public required string Phone { get; set; }
        public  required string Address { get; set; }
    }
}
