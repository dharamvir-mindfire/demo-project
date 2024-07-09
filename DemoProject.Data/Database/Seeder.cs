using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DemoProject.Database
{
    public static class Seeder
    {
        public static void RoleSeeder(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(new IdentityRole { Id = "7de6b658-4034-4dd8-9480-bb985e5c578e", Name = "Admin", NormalizedName = "ADMIN" });
            builder.Entity<IdentityRole>().HasData(new IdentityRole { Id = "7e51f693-ff34-49fe-a998-d53192b40e51", Name = "Customer", NormalizedName = "CUSTOMER" });
        }
    }
}
