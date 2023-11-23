using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using my_cs_degree.Areas.Identity.Data;

namespace my_cs_degree.Data;

public class my_cs_degreeContext : IdentityDbContext<my_cs_degreeUser>
{
    public my_cs_degreeContext(DbContextOptions<my_cs_degreeContext> options)
        : base(options)
    {
    }
    
    public DbSet<my_cs_degreeUser> my_cs_degreeUser { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
