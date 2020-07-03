using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OngPetCare.infra.Configuration;

namespace OngPetCare.infra.Context
{
    public class DataBaseContext:IdentityDbContext
    {

        public DataBaseContext(DbContextOptions options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new UserConfiguration());

        }
    }
}
