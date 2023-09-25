using CSCI3110WebAPIIntroLec.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CSCI3110WebAPIIntroLec.Services;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Pet> Pets => Set<Pet>();
}

