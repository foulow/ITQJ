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

        public virtual DbSet<Rol> Roles { get; set; }

        public virtual DbSet<Skill> Skills { get; set; }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>()
                .HasOne(m => m.Rol)
                .WithMany(m => m.Users)
                .HasForeignKey(r => r.RolId);
            modelBuilder.Entity<User>()
                .HasMany(m => m.Projects)
                .WithOne(M => M.User)
                .HasForeignKey(r => r.UserId);


            modelBuilder.Entity<PersonalInfo>()
                .HasOne(m => m.User)
                .WithOne(m => m.PersonalInfo)
                .HasForeignKey(nameof(PersonalInfo));
            modelBuilder.Entity<PersonalInfo>()
                .HasMany(m => m.ProfesionalSkills)
                .WithOne(m => m.PersonalInfo)
                .HasForeignKey(r => r.PersonalInfoId);
            modelBuilder.Entity<PersonalInfo>()
                .HasOne(m => m.LegalDocument)
                .WithOne(m => m.PersonalInfo)
                .HasForeignKey(nameof(PersonalInfo));

            modelBuilder.Entity<ProfesionalSkill>()
                .HasOne(m => m.Skill)
                .WithOne(m => m.ProfesionalSkill)
                .HasForeignKey(nameof(ProfesionalSkill));

            modelBuilder.Entity<LegalDocument>()
                .HasOne(m => m.DocumentType)
                .WithOne(m => m.LegalDocument)
                .HasForeignKey(nameof(LegalDocument));

            modelBuilder.Entity<Postulant>()
                .HasOne(m => m.Project)
                .WithMany(m => m.Postulants)
                .HasForeignKey(r => r.ProjectId);
            modelBuilder.Entity<Postulant>()
                .HasOne(m => m.User)
                .WithMany(m => m.Postulants)
                .HasForeignKey(r => r.UserId);

            modelBuilder.Entity<Message>()
                .HasOne(m => m.User)
                .WithMany(m => m.Messages)
                .HasForeignKey(r => r.UserId);
            modelBuilder.Entity<Message>()
                .HasOne(m => m.Project)
                .WithMany(m => m.Messages)
                .HasForeignKey(r => r.ProjectId);

            modelBuilder.Entity<Review>()
                .HasOne(m => m.User)
                .WithMany(m => m.Reviews)
                .HasForeignKey(r => r.UserId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
