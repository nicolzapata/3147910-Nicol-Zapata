using System;

/// <summary>
/// Summary description for Class1
/// </summary>
public class ApplicationDbContext : DbContext
{
	public ApplicationDbContext(DbContextOptions<ApplicationDbContext>
            options) : base(options)
	{
	}
	public DbSet<Models.Producto> Productos { get; set; }
}
