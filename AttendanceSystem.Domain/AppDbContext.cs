using AttendanceSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Domain
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Connections.sqlConnStr);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //في داعي  constrant لل virtual?????????????????????
            //في داعي  constrant لل virtual?????????????????????

        /////////////////////////////// User Table //////////////////////////////////////
            // User Entity Configuration
            modelBuilder.Entity<User>()
                .Property(u => u.UserId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<User>()
               .Property(u => u.FullName);
            //   .HasMaxLength(100)
            //   .IsRequired();
            //modelBuilder.Entity<User>()
            //  .HasIndex(u => u.FullName)
            //  .IsUnique();

            modelBuilder.Entity<User>()
                .Property(u => u.UserEmail);
            //    .HasMaxLength(150)
            //    .IsRequired();
            //modelBuilder.Entity<User>()
            //   .HasIndex(u => u.UserEmail)
            //   .IsUnique();

            modelBuilder.Entity<User>()
                .Property(u => u.UserPhone);
            //    .HasMaxLength(10)
            //    .IsRequired();
            //modelBuilder.Entity<User>()
            //  .HasIndex(u => u.UserPhone)
            //  .IsUnique();

            modelBuilder.Entity<User>()
                .Property(u => u.ReferanceNumber);
            //    .HasMaxLength (12)
            //    .IsRequired();
            //modelBuilder.Entity<User>()
            //  .HasIndex(u => u.ReferanceNumber)
            //  .IsUnique();

            modelBuilder.Entity<User>()
                .Property(u => u.UserImag);
            //    .IsRequired();
            //modelBuilder.Entity<User>()   ////>??????????
            //  .HasIndex(u => u.UserImag)
            //  .IsUnique();

            modelBuilder.Entity<User>()
                .Property(u => u.CreateDate);
                //.IsRequired ();

            modelBuilder.Entity<User>()
                .Property(u => u.Gender);
                //.IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.JobTitel);
                //.IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.Address);
            //.HasMaxLength(300)
            //.IsRequired();

            modelBuilder.Entity<User>()
              .HasOne(u => u.College)
              .WithMany(c => c.Users)//c => c.Users
              .HasForeignKey(u => u.CollegeId)
              .OnDelete(DeleteBehavior.Cascade);
              //.OnDelete(DeleteBehavior.Restrict);// is nssisary ???

            modelBuilder.Entity<User>()
                .HasOne(u => u.Department)
                .WithMany(d => d.Users)
                .HasForeignKey(u => u.DepartmentId)
                .OnDelete(DeleteBehavior.Cascade);
                //.OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Roll)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RollId)
                .OnDelete(DeleteBehavior.Cascade);
                //.OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Login)
                .WithMany(l => l.Users)
                .HasForeignKey(u => u.LoginId)
                .OnDelete(DeleteBehavior.Cascade);
                // .OnDelete(DeleteBehavior.Restrict);



            /////////////////////////////// Section Table //////////////////////////////////////
            // Section Entity Configuration
            modelBuilder.Entity<Section>()
               .Property(s => s.SectionId)
               .ValueGeneratedOnAdd();

            modelBuilder.Entity<Section>()
                .Property(s => s.StartDateTime);
            //.IsRequired();

            modelBuilder.Entity<Section>()
                .Property(s => s.EndDateTime);
                //.IsRequired();

            modelBuilder.Entity<Section>()
                .Property(s => s.SectionNumber);
            //.HasMaxLength(2)
            //.IsRequired();

            modelBuilder.Entity<Section>()
                .Property(s => s.SectionDays);
                //.IsRequired();

            modelBuilder.Entity<Section>()
               .HasOne(s => s.Course)
               .WithMany(c => c.Sections)
               .HasForeignKey(s => s.CourseId)
               .OnDelete(DeleteBehavior.Cascade);
               //.OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Section>()
                .HasOne(s => s.ClassRoom)
                .WithMany(cr => cr.Sections)
                .HasForeignKey(s => s.ClassRoomId)
                .OnDelete(DeleteBehavior.Cascade);
                //.OnDelete(DeleteBehavior.Restrict);

            /////////////////////////////// Roll Table //////////////////////////////////////
            // Roll Entity Configuration
            modelBuilder.Entity<Roll>()
                .Property(r => r.RollId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Roll>()
                .Property(r => r.RollName);
                //.IsRequired()
                //.HasMaxLength(100);


            /////////////////////////////// Login Table //////////////////////////////////////
            // Login Entity Configuration
            modelBuilder.Entity<Login>()
                .Property(l => l.LoginId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Login>()
                .Property(l => l.Username);
            //.HasMaxLength(20)
            //.IsRequired();
            //modelBuilder.Entity<Login>()
            //  .HasIndex(l => l.Username)
            //  .IsUnique();

            modelBuilder.Entity<Login>()
                .Property(l => l.Password);
                //.HasMaxLength(16)
                //.IsRequired();


            /////////////////////////////// Enrollment Table //////////////////////////////////////
            // Enrollment Entity Configuration
            modelBuilder.Entity<Enrollment>()
                .Property(e => e.EnrollmentId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Enrollment>()
               .HasOne(e => e.User)
               .WithMany(u => u.Enrollments)
               .HasForeignKey(e => e.UserId)
               .OnDelete(DeleteBehavior.Cascade);
               //.OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Section)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(e => e.SectionId)
                .OnDelete(DeleteBehavior.Cascade);
                //.OnDelete(DeleteBehavior.Restrict);


            /////////////////////////////// Department Table //////////////////////////////////////
            // Department Entity Configuration
            modelBuilder.Entity<Department>()
                .Property(d => d.DepartmentId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Department>()
                .Property(d => d.DepartmentName);
            //    .IsRequired()
            //    .HasMaxLength(50);
            //modelBuilder.Entity<Department>()
            //  .HasIndex(d => d.DepartmentName)
            //  .IsUnique();

            modelBuilder.Entity<Department>()
                .Property(d => d.HeadUserId);
            //    .IsRequired();
            //modelBuilder.Entity<Department>()
            //  .HasIndex(d => d.HeadUserId)
            //  .IsUnique();

            modelBuilder.Entity<Department>()
              .HasOne(d => d.College)
              .WithMany(cl => cl.Departments)
              .HasForeignKey(u => u.CollegeId)
              .OnDelete(DeleteBehavior.Cascade);
              //.OnDelete(DeleteBehavior.Restrict);// is nssisary ???

            //modelBuilder.Entity<Department>()
            //  .HasOne(d => d.HeadUser)
            //  .WithMany()
            //  .HasForeignKey(d => d.HeadUserId)
            //  .OnDelete(DeleteBehavior.Restrict);


            /////////////////////////////// Course Table //////////////////////////////////////
            // Course Entity Configuration
            modelBuilder.Entity<Course>()
                .Property(c => c.CourseId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Course>()
                .Property(c => c.CourseName);
            //    .HasMaxLength(50)
            //    .IsRequired();
            //modelBuilder.Entity<Course>()
            //    .HasIndex(c => c.CourseName)
            //    .IsUnique();

            modelBuilder.Entity<Course>()
               .Property(c => c.CourseNumber);
            //   .HasMaxLength(20)
            //   .IsRequired();
            //modelBuilder.Entity<Course>()
            //   .HasIndex(c => c.CourseNumber)
            //   .IsUnique();

            modelBuilder.Entity<Course>()
               .Property(c => c.CreditHour);
               //.IsRequired();

            modelBuilder.Entity<Course>()
             .HasOne(c => c.Teacher)
             .WithMany(t => t.Courses)
             .HasForeignKey(c => c.TeacherId)
             .OnDelete(DeleteBehavior.Cascade);
             //.OnDelete(DeleteBehavior.Restrict);// is nssisary ???

            modelBuilder.Entity<Course>()
              .HasOne(c => c.Department)
              .WithMany(d => d.Courses)
              .HasForeignKey(c => c.DepartmentId)
              .OnDelete(DeleteBehavior.Cascade);
              //.OnDelete(DeleteBehavior.Restrict);// is nssisary ???

      

            /////////////////////////////// College Table //////////////////////////////////////
            // Collage Entity Configuration
            modelBuilder.Entity<College>()
                .Property(cl => cl.CollegeId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<College>()
                .Property(cl => cl.CollegeName);
            //    .HasMaxLength(50)
            //    .IsRequired();
            //modelBuilder.Entity<College>()
            //    .HasIndex(cl => cl.CollegeName)
            //    .IsUnique();

            modelBuilder.Entity<College>()
                .Property(cl => cl.DeanUserId);
                //.IsRequired();
            //modelBuilder.Entity<College>()
            //    .HasIndex(cl => cl.DeanUserId)
            //    .IsUnique();

            //modelBuilder.Entity<College>()
            //    .HasOne(c => c.DeanUser)
            //    .WithMany() // Assuming no collection of Colleges in User
            //    .HasForeignKey(c => c.DeanUserId)
            //    .OnDelete(DeleteBehavior.Restrict); // Optional: specify delete behavior


            /////////////////////////////// ClassRoom Table //////////////////////////////////////
            // ClassRoom Entity Configuration
            modelBuilder.Entity<ClassRoom>()
                .Property(cr => cr.ClassRoomId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<ClassRoom>()
                .Property(cr => cr.ClassNumber);
            //    .HasMaxLength(5)
            //    .IsRequired();
            //modelBuilder.Entity<ClassRoom>()
            //    .HasIndex(cr => cr.ClassNumber)
            //    .IsUnique();


            /////////////////////////////// Attendance Table //////////////////////////////////////
            // Attendance Entity Configuration
            modelBuilder.Entity<Attendance>()
                .Property(a => a.AttendanceId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Attendance>()
                .Property(a => a.Status);
            //.IsRequired();

            modelBuilder.Entity<Attendance>()
                .Property(a => a.Date);
                //.IsRequired();


            modelBuilder.Entity<Attendance>()
                .HasOne(a => a.User)
                .WithMany(u => u.Attendances)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);
                //.OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Attendance>()
                .HasOne(a => a.Enrollment)
                .WithMany(e => e.Attendances)
                .HasForeignKey(a => a.EnrollmentId)
                .OnDelete(DeleteBehavior.Cascade);
                //.OnDelete(DeleteBehavior.Restrict);


            /*********************************************************************/


            //modelBuilder.Entity<Login>()
            //    .HasOne(l => l.User)
            //    .WithMany()
            //    .HasForeignKey(l => l.UserID);
        }
                             /// <summary>
                             /// / add virtual ???????//
                             /// </summary>
        public DbSet<User> Users { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Roll> Rolls { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<Enrollment> Enrollments  { get; set; }
        public DbSet<Department> Departments  { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<College> Colleges { get; set; }
        public DbSet<ClassRoom> ClassRooms  { get; set; }
        public DbSet<Attendance> Attendances  { get; set; }


    }
}
