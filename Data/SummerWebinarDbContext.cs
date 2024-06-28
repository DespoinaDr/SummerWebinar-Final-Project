using Microsoft.EntityFrameworkCore;

namespace SummerWebinarApp.Data
{
    public class SummerWebinarDbContext : DbContext
    {
        // Default constructor
        public SummerWebinarDbContext()
        {

        }

        // Constructor that accepts DbContextOptions
        public SummerWebinarDbContext(DbContextOptions<SummerWebinarDbContext> options)
            : base(options)
        {
        }

        // DbSets for the entities
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Webinar> Webinars { get; set; }

        // Method to configure the model
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("STUDENTS");
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.Institution)
                    .HasMaxLength(50).HasColumnName("INSTITUTION");
                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(50).HasColumnName("PHONE_NUMBER");
                entity.HasOne(d => d.User).WithOne(p => p.Student)
                      .HasForeignKey<Student>(d => d.UserId)
                      .HasConstraintName("FK_STUDENTS_USERS");
                entity.HasMany(s => s.Webinars)
                    .WithMany(w => w.Students)
                .UsingEntity("STUDENTS_WEBINARS");
            });

            // Configuration for the Teacher entity
            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.ToTable("TEACHERS");
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.Institution)
                    .HasMaxLength(50).HasColumnName("INSTITUTION");
                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(50).HasColumnName("PHONE_NUMBER");
                entity.HasOne(d => d.User).WithOne(p => p.Teacher)
                      .HasForeignKey<Teacher>(d => d.UserId)
                      .HasConstraintName("FK_TEACHERS_USERS");
            });
            // Configuration for the Webinar entity
            modelBuilder.Entity<Webinar>(entity =>
            {
                entity.ToTable("WEBINARS");
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.TeacherId).HasColumnName("TEACHER_ID");
                entity.Property(e => e.Description)
                    .HasMaxLength(50).HasColumnName("DESCRIPTION");
                entity.HasOne(w => w.Teacher)                   // Webinar has one Teacher
                    .WithMany(t => t.Webinars)                   // Teacher has many Webinars
                    .HasForeignKey(w => w.TeacherId)            // Optional: Since convention is TeacherId
                    .HasConstraintName("FK_TEACHERS_WEBINARS");  // Optional: But we can define a custom constraint name

                // Adding seed data for the Webinars table

                entity.HasData(
                    new Webinar
                    {
                        Id = 8,
                        Description = "Java",
                        TeacherId = 1
                    },
                     new Webinar
                     {
                         Id = 9,
                         Description = "JavaScript",
                         TeacherId = 2
                     },
                     new Webinar
                     {
                         Id = 10,
                         Description = "MSSQL",
                         TeacherId = 3
                     },
                     new Webinar
                     {
                         Id = 11,
                         Description = "Python",
                         TeacherId = 4
                     },

                     new Webinar
                     {
                         Id = 12,
                         Description = "Angular",
                         TeacherId = 5
                     },

                     new Webinar
                     {
                         Id = 13,
                         Description = "Android",
                         TeacherId = 6
                     }
                 );
            });
            // Configuration for the User entity
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("USERS");
                entity.HasIndex(e => e.Lastname, "IX_LASTNAME");
                entity.HasIndex(e => e.Username, "UQ_USERNAME").IsUnique();
                entity.HasIndex(e => e.Email, "UQ_EMAIL").IsUnique();
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.Username)
                    .HasMaxLength(50).HasColumnName("USERNAME");
                entity.Property(e => e.Password)
                    .HasMaxLength(512).HasColumnName("PASSWORD");
                entity.Property(e => e.Email)
                    .HasMaxLength(50).HasColumnName("EMAIL");
                entity.Property(e => e.Firstname)
                    .HasMaxLength(50).HasColumnName("FIRSTNAME");
                entity.Property(e => e.Lastname)
                    .HasMaxLength(50).HasColumnName("LASTNAME");
                entity.Property(e => e.UserRole)
                    .HasColumnName("USER_ROLE")
                    .HasConversion<string>()
                    .HasMaxLength(50);

                // Configuration for CreatedAt
                entity.Property(e => e.CreatedAt)
                    .HasColumnName("CREATED_AT")
                    .HasDefaultValueSql("GETDATE()");

                // Configuration for UpdatedAt
                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("UPDATED_AT")
                    .HasDefaultValueSql("GETDATE()")
                    .ValueGeneratedOnAddOrUpdate();

            });
        }
        // Override SaveChanges to update timestamps
        public override int SaveChanges()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is User && (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                if (entityEntry.State == EntityState.Added)
                {
                    ((User)entityEntry.Entity).CreatedAt = DateTime.Now;
                }
                ((User)entityEntry.Entity).UpdatedAt = DateTime.Now;
            }

            return base.SaveChanges();
        }
        // Override SaveChangesAsync to update timestamps
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is User && (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                if (entityEntry.State == EntityState.Added)
                {
                    ((User)entityEntry.Entity).CreatedAt = DateTime.Now;
                }
                ((User)entityEntry.Entity).UpdatedAt = DateTime.Now;
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
