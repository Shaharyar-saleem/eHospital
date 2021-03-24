namespace eHospital.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Admin_Role> Admin_Role { get; set; }
        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<Blog_Category> Blog_Category { get; set; }
        public virtual DbSet<Blog_Comment> Blog_Comment { get; set; }
        public virtual DbSet<Blood_Donation> Blood_Donation { get; set; }
        public virtual DbSet<Blood_Doners> Blood_Doners { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Doctor_Schedule> Doctor_Schedule { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Patient_Treatment> Patient_Treatment { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>()
                .Property(e => e.ADMIN_CONTACT)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Admin>()
                .HasMany(e => e.Blogs)
                .WithRequired(e => e.Admin)
                .HasForeignKey(e => e.ADMIN_FID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Admin>()
                .HasMany(e => e.Blood_Doners)
                .WithOptional(e => e.Admin)
                .HasForeignKey(e => e.ADMIN_FID);

            modelBuilder.Entity<Admin_Role>()
                .HasMany(e => e.Admins)
                .WithOptional(e => e.Admin_Role)
                .HasForeignKey(e => e.ROLE_FID);

            modelBuilder.Entity<Appointment>()
                .HasMany(e => e.Blood_Donation)
                .WithRequired(e => e.Appointment)
                .HasForeignKey(e => e.APPOINTMENT_FID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Appointment>()
                .HasMany(e => e.Feedbacks)
                .WithRequired(e => e.Appointment)
                .HasForeignKey(e => e.APPOINTMENT_FID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Appointment>()
                .HasMany(e => e.Patient_Treatment)
                .WithRequired(e => e.Appointment)
                .HasForeignKey(e => e.APPOINTMENT_FID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Blog>()
                .HasMany(e => e.Blog_Comment)
                .WithRequired(e => e.Blog)
                .HasForeignKey(e => e.BLOG_FID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Blog_Category>()
                .HasMany(e => e.Blogs)
                .WithRequired(e => e.Blog_Category)
                .HasForeignKey(e => e.CATEGORY_FID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Blood_Doners>()
                .HasMany(e => e.Blood_Donation)
                .WithRequired(e => e.Blood_Doners)
                .HasForeignKey(e => e.DONER_FID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Department>()
                .HasMany(e => e.Doctors)
                .WithRequired(e => e.Department)
                .HasForeignKey(e => e.DEPARTMENT_FID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Doctor>()
                .Property(e => e.DR_SALARY)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Doctor>()
                .Property(e => e.DR_CONTACT)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Doctor>()
                .Property(e => e.DR_FEE)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Doctor>()
                .HasMany(e => e.Doctor_Schedule)
                .WithRequired(e => e.Doctor)
                .HasForeignKey(e => e.DR_FID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Doctor_Schedule>()
                .Property(e => e.MAX_APPOINTMENTS)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Doctor_Schedule>()
                .HasMany(e => e.Appointments)
                .WithRequired(e => e.Doctor_Schedule)
                .HasForeignKey(e => e.SCHEDULE_FID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Feedback>()
                .Property(e => e.RATING)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Patient>()
                .Property(e => e.PATIENT_CONTACT)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Patient>()
                .Property(e => e.PATIENT_PIC)
                .IsFixedLength();

            modelBuilder.Entity<Patient>()
                .HasMany(e => e.Appointments)
                .WithRequired(e => e.Patient)
                .HasForeignKey(e => e.PATIENT_FID)
                .WillCascadeOnDelete(false);
        }
    }
}
