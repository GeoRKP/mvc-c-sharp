using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace UserMvcApp.Data;

public partial class StudentsCf4dbContext : DbContext
{
    public StudentsCf4dbContext()
    {
    }

    public StudentsCf4dbContext(DbContextOptions<StudentsCf4dbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Student> Students { get; set; }
    public virtual DbSet<User> Users { get; set; }

   

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__STUDENTS__3214EC27BF1CFC4C");
            entity.ToTable("STUDENTS");
            entity.HasIndex(e => e.UserId, "UQ_STUDENTS_USER_ID").IsUnique();
            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.UserId).HasColumnName("USER_ID");
            entity.HasOne(d => d.User).WithOne(p => p.Student)
                .HasForeignKey<Student>(d => d.UserId)
                .HasConstraintName("FK_STUDENTS_ToUSERS");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__USERS__3214EC2795BC0683");
            entity.ToTable("USERS");
            entity.HasIndex(e => e.Email, "UQ_USERS_EMAIL").IsUnique();
            entity.HasIndex(e => e.PhoneNumber, "UQ_USERS_PHONE").IsUnique();
            entity.HasIndex(e => e.Username, "UQ_USERS_USERNAME").IsUnique();
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Firstname)
                .HasMaxLength(50)
                .HasColumnName("FIRSTNAME");
            entity.Property(e => e.Institution)
                .HasMaxLength(50)
                .HasColumnName("INSTITUTION");
            entity.Property(e => e.Lastname)
                .HasMaxLength(50)
                .HasColumnName("LASTNAME");
            entity.Property(e => e.Password)
                .HasMaxLength(512)
                .HasColumnName("PASSWORD");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(50)
                .HasColumnName("PHONE_NUMBER");
            entity.Property(e => e.UserRole)
                .HasMaxLength(50)
                .HasColumnName("USER_ROLE");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("USERNAME");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
