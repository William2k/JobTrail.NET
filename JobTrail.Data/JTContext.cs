using JobTrail.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace JobTrail.Data
{
    public class JTContext : IdentityDbContext<User, Role, Guid>
    {
        public JTContext(DbContextOptions<JTContext> options) : base(options)
        {
        }

        public DbSet<Job> Jobs { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>(b => 
            {
                b.ToTable("Users");
                b.Property(x => x.DateCreated).HasDefaultValueSql("GETDATE()");
                b.Property(x => x.Id).HasDefaultValueSql("NEWSEQUENTIALID()");
            });

            builder.Entity<Role>(b =>
            {
                b.ToTable("Roles");
                b.Property(x => x.Id).HasDefaultValueSql("NEWSEQUENTIALID()");
            });

            builder.Entity<IdentityUserRole<Guid>>().ToTable("UserRoles");
            builder.Entity<IdentityUserClaim<Guid>>().ToTable("UserClaims");
            builder.Entity<IdentityUserLogin<Guid>>().ToTable("UserLogins");
            builder.Entity<IdentityRoleClaim<Guid>>().ToTable("RoleClaims");
            builder.Entity<IdentityUserToken<Guid>>().ToTable("UserTokens");

            builder.Entity<Job>(b => 
            {
                b.Property(x => x.DateCreated).HasDefaultValueSql("GETDATE()");
            });
        }
    }
}
