using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MVCAbit.Models;

public partial class AbiturientsContext : DbContext
{
    public AbiturientsContext()
    {
    }

    public AbiturientsContext(DbContextOptions<AbiturientsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Abiturient> Abiturients { get; set; }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Auth> Auths { get; set; }

    public virtual DbSet<Chosen> Chosens { get; set; }

    public virtual DbSet<Faculty> Faculties { get; set; }

    public virtual DbSet<Registration> Registrations { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Secondary> Secondaries { get; set; }

    public virtual DbSet<Speciality> Specialities { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-UJTBBENC;Database=abiturients;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Abiturient>(entity =>
        {
            entity.HasKey(e => e.AbiturientId).HasName("PK__abiturie__3BE29AE9B03E9FCE");

            entity.ToTable("abiturient");

            entity.Property(e => e.AbiturientId).HasColumnName("abiturient_id");
            entity.Property(e => e.AbiturientGoldMedal).HasColumnName("abiturient_gold_medal");
            entity.Property(e => e.AbiturientName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("abiturient_name");
            entity.Property(e => e.AbiturientPhoto)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("abiturient_photo");
            entity.Property(e => e.AbiturientPoBatyushke)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("abiturient_po_batyushke");
            entity.Property(e => e.AbiturientSecId).HasColumnName("abiturient_sec_id");
            entity.Property(e => e.AbiturientSecYear).HasColumnName("abiturient_sec_year");
            entity.Property(e => e.AbiturientSilverMedal).HasColumnName("abiturient_silver_medal");
            entity.Property(e => e.AbiturientSurname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("abiturient_surname");
            entity.Property(e => e.AbiturientTechDiplom).HasColumnName("abiturient_tech_diplom");

            entity.HasOne(d => d.AbiturientSec).WithMany(p => p.Abiturients)
                .HasForeignKey(d => d.AbiturientSecId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__abiturien__abitu__3B75D760");
        });

        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.AddressId).HasName("PK__address__CAA247C8725C87DB");

            entity.ToTable("address");

            entity.Property(e => e.AddressId)
                .ValueGeneratedNever()
                .HasColumnName("address_id");
            entity.Property(e => e.AddressCity)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("address_city");
            entity.Property(e => e.AddressHomeNum).HasColumnName("address_home_num");
            entity.Property(e => e.AddressStreet)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("address_street");
        });

        modelBuilder.Entity<Auth>(entity =>
        {
            entity.HasKey(e => e.AuthStaffId).HasName("PK__auth__3905289A328F733A");

            entity.ToTable("auth");

            entity.Property(e => e.AuthStaffId)
                .ValueGeneratedNever()
                .HasColumnName("auth_staff_id");
            entity.Property(e => e.AuthLogin)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("auth_login");
            entity.Property(e => e.AuthPass)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("auth_pass");

            entity.HasOne(d => d.AuthStaff).WithOne(p => p.Auth)
                .HasForeignKey<Auth>(d => d.AuthStaffId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__auth__auth_staff__46B27FE2");
        });

        modelBuilder.Entity<Chosen>(entity =>
        {
            entity.HasKey(e => e.ChosenId).HasName("PK__chosen__C6D140CFA7114282");

            entity.ToTable("chosen");

            entity.Property(e => e.ChosenId).HasColumnName("chosen_id");
            entity.Property(e => e.ChosenAbId).HasColumnName("chosen_ab_id");
            entity.Property(e => e.ChosenFirstExam).HasColumnName("chosen_first_exam");
            entity.Property(e => e.ChosenSecondExam).HasColumnName("chosen_second_exam");
            entity.Property(e => e.ChosenSpecId).HasColumnName("chosen_spec_id");
            entity.Property(e => e.ChosenThirdExam).HasColumnName("chosen_third_exam");

            entity.HasOne(d => d.ChosenAb).WithMany(p => p.Chosens)
                .HasForeignKey(d => d.ChosenAbId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__chosen__chosen_a__47A6A41B");

            entity.HasOne(d => d.ChosenSpec).WithMany(p => p.Chosens)
                .HasForeignKey(d => d.ChosenSpecId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__chosen__chosen_s__489AC854");
        });

        modelBuilder.Entity<Faculty>(entity =>
        {
            entity.HasKey(e => e.FacultyId).HasName("PK__faculty__7B00413C184B34F4");

            entity.ToTable("faculty");

            entity.Property(e => e.FacultyId).HasColumnName("faculty_id");
            entity.Property(e => e.FacultyName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("faculty_name");
            entity.Property(e => e.FacultyTelephone)
                .HasMaxLength(16)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("faculty_telephone");
        });

        modelBuilder.Entity<Registration>(entity =>
        {
            entity.HasKey(e => e.RegId).HasName("PK__registra__7403877271A0E586");

            entity.ToTable("registration");

            entity.Property(e => e.RegId).HasColumnName("reg_id");
            entity.Property(e => e.RegAbiturientId).HasColumnName("reg_abiturient_id");
            entity.Property(e => e.RegDate)
                .HasColumnType("datetime")
                .HasColumnName("reg_date");
            entity.Property(e => e.RegStaffId).HasColumnName("reg_staff_id");

            entity.HasOne(d => d.RegAbiturient).WithMany(p => p.Registrations)
                .HasForeignKey(d => d.RegAbiturientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__registrat__reg_a__4316F928");

            entity.HasOne(d => d.RegStaff).WithMany(p => p.Registrations)
                .HasForeignKey(d => d.RegStaffId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__registrat__reg_s__440B1D61");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__role__760965CC3DA0AE15");

            entity.ToTable("role");

            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Secondary>(entity =>
        {
            entity.HasKey(e => e.SecondaryId).HasName("PK__secondar__DB57D5B260B5D254");

            entity.ToTable("secondary");

            entity.Property(e => e.SecondaryId).HasColumnName("secondary_id");
            entity.Property(e => e.SecondaryCity)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("secondary_city");
            entity.Property(e => e.SecondaryName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("secondary_name");
            entity.Property(e => e.SecondaryNumber).HasColumnName("secondary_number");
        });

        modelBuilder.Entity<Speciality>(entity =>
        {
            entity.HasKey(e => e.SpecId).HasName("PK__speciali__F670C5673721DC92");

            entity.ToTable("speciality");

            entity.Property(e => e.SpecId).HasColumnName("spec_id");
            entity.Property(e => e.SpecFacId).HasColumnName("spec_fac_id");
            entity.Property(e => e.SpecFirstExam)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("spec_first_exam");
            entity.Property(e => e.SpecName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("spec_name");
            entity.Property(e => e.SpecSecondExam)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("spec_second_exam");
            entity.Property(e => e.SpecThirdExam)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("spec_third_exam");

            entity.HasOne(d => d.SpecFac).WithMany(p => p.Specialities)
                .HasForeignKey(d => d.SpecFacId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__specialit__spec___46E78A0C");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.StaffId).HasName("PK__staff__1963DD9C3AB1339A");

            entity.ToTable("staff");

            entity.Property(e => e.StaffId).HasColumnName("staff_id");
            entity.Property(e => e.StaffFacId).HasColumnName("staff_fac_id");
            entity.Property(e => e.StaffName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("staff_name");
            entity.Property(e => e.StaffPart)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("staff_part");
            entity.Property(e => e.StaffPoBatyushke)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("staff_po_batyushke");
            entity.Property(e => e.StaffSurname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("staff_surname");

            entity.HasOne(d => d.StaffFac).WithMany(p => p.Staff)
                .HasForeignKey(d => d.StaffFacId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__staff__staff_fac__403A8C7D");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__users__3213E83F414BB541");

            entity.ToTable("users");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Login)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("login");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.RoleId).HasColumnName("role_id");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__users__role_id__2B0A656D");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
