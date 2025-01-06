using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace TestDauVaoXuong.Models
{
    public class AppDbcontext : DbContext
    {
        public AppDbcontext()
        {
            
        }

        public AppDbcontext(DbContextOptions options) : base(options)
        {

        }

        public virtual DbSet<Staff> Staff { get; set; }
        public virtual DbSet<Facility> Facilities { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<DepartmentFacility> DepartmentFacilities { get; set; }
        public virtual DbSet<Major> Majors { get; set; }
        public virtual DbSet<MajorFacility> MajorFacilities { get; set; }
        public virtual DbSet<StaffMajorFacility> StaffMajorFacilities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOPD-DELLIN\\SQLEXPRESS;Database=exam_distribution_test;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            SeedingData(modelBuilder);

        }

        public void SeedingData(ModelBuilder modelBuilder)
        {
            // Seed Staff
            modelBuilder.Entity<Staff>().HasData(
                new Staff { Id = Guid.Parse("550e8400-e29b-41d4-a716-446655440000"), Status = 1, CreatedDate = DateTime.Parse("2021-08-01 05:00:00"), LastModifiedDate = DateTime.Parse("2021-08-02 05:00:00"), AccountFe = "fe_account1@fe.edu.vn", AccountFpt = "fpt_account1@fpt.edu.vn", Name = "John Wick", StaffCode = "ST001" },
                new Staff { Id = Guid.Parse("550e8400-e29b-41d4-a716-446655440001"), Status = 1, CreatedDate = DateTime.Parse("2021-08-01 05:00:00"), LastModifiedDate = DateTime.Parse("2021-08-02 05:00:00"), AccountFe = "fe_account2@fe.edu.vn", AccountFpt = "fpt_account2@fpt.edu.vn", Name = "Top1 Flo", StaffCode = "ST002" },
                new Staff { Id = Guid.Parse("550e8400-e29b-41d4-a716-446655440002"), Status = 1, CreatedDate = DateTime.Parse("2021-08-01 05:00:00"), LastModifiedDate = DateTime.Parse("2021-08-02 05:00:00"), AccountFe = "fe_account3@fe.edu.vn", AccountFpt = "fpt_account3@fpt.edu.vn", Name = "Lục Luật", StaffCode = "ST003" }
            );

            // Seed Facility
            modelBuilder.Entity<Facility>().HasData(
                new Facility { Id = Guid.Parse("550e8400-e29b-41d4-a716-446655440010"), Status = 1, CreatedDate = DateTime.Parse("2021-08-01 05:00:00"), LastModifiedDate = DateTime.Parse("2021-08-02 05:00:00"), Code = "FAC001", Name = "HN" },
                new Facility { Id = Guid.Parse("550e8400-e29b-41d4-a716-446655440011"), Status = 1, CreatedDate = DateTime.Parse("2021-08-01 05:00:00"), LastModifiedDate = DateTime.Parse("2021-08-02 05:00:00"), Code = "FAC002", Name = "HCM" }
            );

            // Seed Department
            modelBuilder.Entity<Department>().HasData(
                new Department { Id = Guid.Parse("550e8400-e29b-41d4-a716-446655440020"), Status = 1, CreatedDate = DateTime.Parse("2021-08-01 05:00:00"), LastModifiedDate = DateTime.Parse("2021-08-02 05:00:00"), Code = "DEP001", Name = "Department One" },
                new Department { Id = Guid.Parse("550e8400-e29b-41d4-a716-446655440021"), Status = 1, CreatedDate = DateTime.Parse("2021-08-01 05:00:00"), LastModifiedDate = DateTime.Parse("2021-08-02 05:00:00"), Code = "DEP002", Name = "Department Two" },
                new Department { Id = Guid.Parse("550e8400-e29b-41d4-a716-446655440022"), Status = 1, CreatedDate = DateTime.Parse("2021-08-01 05:00:00"), LastModifiedDate = DateTime.Parse("2021-08-02 05:00:00"), Code = "DEP003", Name = "Department Three" }
            );

            // Seed DepartmentFacility
            modelBuilder.Entity<DepartmentFacility>().HasData(
                new DepartmentFacility { Id = Guid.Parse("550e8400-e29b-41d4-a716-446655440030"), Status = 1, CreatedDate = DateTime.Parse("2021-08-01 05:00:00"), LastModifiedDate = DateTime.Parse("2021-08-02 05:00:00"), DepartmentId = Guid.Parse("550e8400-e29b-41d4-a716-446655440020"), FacilityId = Guid.Parse("550e8400-e29b-41d4-a716-446655440010"), StaffId = Guid.Parse("550e8400-e29b-41d4-a716-446655440000") },
                new DepartmentFacility { Id = Guid.Parse("550e8400-e29b-41d4-a716-446655440031"), Status = 1, CreatedDate = DateTime.Parse("2021-08-01 05:00:00"), LastModifiedDate = DateTime.Parse("2021-08-02 05:00:00"), DepartmentId = Guid.Parse("550e8400-e29b-41d4-a716-446655440021"), FacilityId = Guid.Parse("550e8400-e29b-41d4-a716-446655440011"), StaffId = Guid.Parse("550e8400-e29b-41d4-a716-446655440001") },
                new DepartmentFacility { Id = Guid.Parse("550e8400-e29b-41d4-a716-446655440032"), Status = 1, CreatedDate = DateTime.Parse("2021-08-01 05:00:00"), LastModifiedDate = DateTime.Parse("2021-08-02 05:00:00"), DepartmentId = Guid.Parse("550e8400-e29b-41d4-a716-446655440022"), FacilityId = Guid.Parse("550e8400-e29b-41d4-a716-446655440011"), StaffId = Guid.Parse("550e8400-e29b-41d4-a716-446655440002") }
            );

            // Seed Major
            modelBuilder.Entity<Major>().HasData(
                new Major { Id = Guid.Parse("550e8400-e29b-41d4-a716-446655440040"), Status = 1, CreatedDate = DateTime.Parse("2021-08-01 05:00:00"), LastModifiedDate = DateTime.Parse("2021-08-02 05:00:00"), Name = "Major One", Code = "MAJ001" },
                new Major { Id = Guid.Parse("550e8400-e29b-41d4-a716-446655440041"), Status = 1, CreatedDate = DateTime.Parse("2021-08-01 05:00:00"), LastModifiedDate = DateTime.Parse("2021-08-02 05:00:00"), Name = "Major Two", Code = "MAJ002" },
                new Major { Id = Guid.Parse("550e8400-e29b-41d4-a716-446655440042"), Status = 1, CreatedDate = DateTime.Parse("2021-08-01 05:00:00"), LastModifiedDate = DateTime.Parse("2021-08-02 05:00:00"), Name = "Major Three", Code = "MAJ003" }
            );

            // Seed MajorFacility
            modelBuilder.Entity<MajorFacility>().HasData(
                new MajorFacility { Id = Guid.Parse("550e8400-e29b-41d4-a716-446655440050"), Status = 1, CreatedDate = DateTime.Parse("2021-08-01 05:00:00"), LastModifiedDate = DateTime.Parse("2021-08-02 05:00:00"), DepartmentFacilityId = Guid.Parse("550e8400-e29b-41d4-a716-446655440030"), MajorId = Guid.Parse("550e8400-e29b-41d4-a716-446655440040") },
                new MajorFacility { Id = Guid.Parse("550e8400-e29b-41d4-a716-446655440051"), Status = 1, CreatedDate = DateTime.Parse("2021-08-01 05:00:00"), LastModifiedDate = DateTime.Parse("2021-08-02 05:00:00"), DepartmentFacilityId = Guid.Parse("550e8400-e29b-41d4-a716-446655440031"), MajorId = Guid.Parse("550e8400-e29b-41d4-a716-446655440041") },
                new MajorFacility { Id = Guid.Parse("550e8400-e29b-41d4-a716-446655440052"), Status = 1, CreatedDate = DateTime.Parse("2021-08-01 05:00:00"), LastModifiedDate = DateTime.Parse("2021-08-02 05:00:00"), DepartmentFacilityId = Guid.Parse("550e8400-e29b-41d4-a716-446655440032"), MajorId = Guid.Parse("550e8400-e29b-41d4-a716-446655440042") }
            );

            // Seed StaffMajorFacility
            modelBuilder.Entity<StaffMajorFacility>().HasData(
                new StaffMajorFacility { Id = Guid.Parse("550e8400-e29b-41d4-a716-446655440060"), Status = 1, CreatedDate = DateTime.Parse("2021-08-01 05:00:00"), LastModifiedDate = DateTime.Parse("2021-08-02 05:00:00"), MajorFacilityId = Guid.Parse("550e8400-e29b-41d4-a716-446655440050"), StaffId = Guid.Parse("550e8400-e29b-41d4-a716-446655440000") },
                new StaffMajorFacility { Id = Guid.Parse("550e8400-e29b-41d4-a716-446655440061"), Status = 1, CreatedDate = DateTime.Parse("2021-08-01 05:00:00"), LastModifiedDate = DateTime.Parse("2021-08-02 05:00:00"), MajorFacilityId = Guid.Parse("550e8400-e29b-41d4-a716-446655440051"), StaffId = Guid.Parse("550e8400-e29b-41d4-a716-446655440001") },
                new StaffMajorFacility { Id = Guid.Parse("550e8400-e29b-41d4-a716-446655440062"), Status = 1, CreatedDate = DateTime.Parse("2021-08-01 05:00:00"), LastModifiedDate = DateTime.Parse("2021-08-02 05:00:00"), MajorFacilityId = Guid.Parse("550e8400-e29b-41d4-a716-446655440052"), StaffId = Guid.Parse("550e8400-e29b-41d4-a716-446655440002") }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
    
