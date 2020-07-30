namespace ITQJ.EFCore
{
    using ITQJ.Domain.Models;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext() { }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
                return;

            var migrationsAssembly = typeof(ApplicationDBContext).Assembly.GetName().FullName;
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB; Database=ITQJ_DB; Trusted_Connection=True; MultipleActiveResultSets=True;",
                    sql => sql.MigrationsAssembly(migrationsAssembly))
                    .UseLazyLoadingProxies();
        }

        public virtual DbSet<DocumentType> DocumentTypes { get; set; }

        public virtual DbSet<LegalDocument> LegalDocuments { get; set; }

        public virtual DbSet<Message> Messages { get; set; }

        public virtual DbSet<PersonalInfo> PersonalInfos { get; set; }

        public virtual DbSet<Postulant> Postulants { get; set; }

        public virtual DbSet<ProfesionalSkill> ProfesionalSkills { get; set; }

        public virtual DbSet<Project> Projects { get; set; }

        public virtual DbSet<Review> Reviews { get; set; }

        public virtual DbSet<Role> Roles { get; set; }

        public virtual DbSet<Skill> Skills { get; set; }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(m => m.Role)
                .WithMany(m => m.Users);
            modelBuilder.Entity<User>()
                .HasIndex(u => u.UserName)
                .IsUnique();

            modelBuilder.Entity<LegalDocument>()
                .HasOne(m => m.DocumentType)
                .WithMany(m => m.LegalDocuments);

            modelBuilder.Entity<PersonalInfo>()
                .HasOne(m => m.User)
                .WithOne(m => m.PersonalInfo);
            modelBuilder.Entity<PersonalInfo>()
                .HasOne(m => m.LegalDocument)
                .WithOne(m => m.PersonalInfo);

            modelBuilder.Entity<ProfesionalSkill>()
                .HasOne(m => m.PersonalInfo)
                .WithMany(m => m.ProfesionalSkills);
            modelBuilder.Entity<ProfesionalSkill>()
                .HasOne(m => m.Skill)
                .WithOne(m => m.ProfesionalSkill);

            modelBuilder.Entity<Project>()
                .HasOne(M => M.User)
                .WithMany(m => m.Projects);

            modelBuilder.Entity<Postulant>()
                .HasOne(m => m.Project)
                .WithMany(m => m.Postulants)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Postulant>()
                .HasOne(m => m.User)
                .WithMany(m => m.Postulants);

            modelBuilder.Entity<Message>()
                .HasOne(m => m.User)
                .WithMany(m => m.Messages)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Message>()
                .HasOne(m => m.Project)
                .WithMany(m => m.Messages);

            modelBuilder.Entity<Review>()
                .HasOne(m => m.User)
                .WithMany(m => m.Reviews);

            base.OnModelCreating(modelBuilder);
        }
    }
}
