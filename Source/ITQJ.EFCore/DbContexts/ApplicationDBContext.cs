namespace ITQJ.EFCore.DbContexts
{
    using ITQJ.Domain.Entities;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDBContext : DbContext
    {
        public virtual DbSet<DocumentType> DocumentTypes { get; set; }

        public virtual DbSet<LegalDocument> LegalDocuments { get; set; }

        public virtual DbSet<Message> Messages { get; set; }

        public virtual DbSet<MileStone> MileStones { get; set; }

        public virtual DbSet<PersonalInfo> PersonalInfos { get; set; }

        public virtual DbSet<Postulant> Postulants { get; set; }

        public virtual DbSet<ProfesionalSkill> ProfesionalSkills { get; set; }

        public virtual DbSet<Project> Projects { get; set; }

        public virtual DbSet<Review> Reviews { get; set; }

        public virtual DbSet<Skill> Skills { get; set; }

        public virtual DbSet<User> Users { get; set; }

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Subject)
                .IsUnique();
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<LegalDocument>()
                .HasOne(e => e.DocumentType)
                .WithMany(e => e.LegalDocuments);

            modelBuilder.Entity<PersonalInfo>()
                .HasOne(e => e.User)
                .WithOne(e => e.PersonalInfo);
            modelBuilder.Entity<PersonalInfo>()
                .HasOne(e => e.LegalDocument)
                .WithOne(e => e.PersonalInfo);

            modelBuilder.Entity<ProfesionalSkill>()
                .HasOne(e => e.PersonalInfo)
                .WithMany(e => e.ProfesionalSkills);
            modelBuilder.Entity<ProfesionalSkill>()
                .HasOne(e => e.Skill)
                .WithMany(e => e.ProfesionalSkills);

            modelBuilder.Entity<Project>()
                .HasOne(e => e.User)
                .WithMany(e => e.Projects);
            modelBuilder.Entity<Project>()
                .Property(p => p.IsOpen)
                .HasDefaultValue(true);

            modelBuilder.Entity<Postulant>()
                .HasOne(e => e.Project)
                .WithMany(e => e.Postulants)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Postulant>()
                .HasOne(e => e.User)
                .WithMany(e => e.Postulants);

            modelBuilder.Entity<Message>()
                .HasOne(e => e.User)
                .WithMany(e => e.Messages)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Message>()
                .HasOne(e => e.Project)
                .WithMany(e => e.Messages);

            modelBuilder.Entity<MileStone>()
                .HasOne(e => e.Project)
                .WithMany(e => e.MileStones);

            modelBuilder.Entity<Review>()
                .HasOne(e => e.User)
                .WithMany(e => e.Reviews);

            base.OnModelCreating(modelBuilder);
        }
    }
}
