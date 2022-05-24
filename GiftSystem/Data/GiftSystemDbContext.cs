namespace GiftSystem.Data
{
    using GiftSystem.Data.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class GiftSystemDbContext : IdentityDbContext<ApplicationUser>
    {
        public GiftSystemDbContext(DbContextOptions<GiftSystemDbContext> options)
            : base(options)
        {

        }

        public DbSet<Transaction> Transactions { get; init; }
    }
}