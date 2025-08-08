using Hospital.DataAccessLayer.DataContext.Entities;
using Microsoft.EntityFrameworkCore;
namespace Hospital.DataAccessLayer.DataContext
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Blog > Blogs { get; set; }



    }
}
