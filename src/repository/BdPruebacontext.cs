using Microsoft.EntityFrameworkCore;
using PruebaDotnet.src.task.entity;
using PruebaDotnet.src.user.entity;

public class BdPruebaContext : DbContext
{

    public BdPruebaContext(DbContextOptions<BdPruebaContext> options) : base(options)
    { }

    public DbSet<UserEntity> Users { get; set; }
    public DbSet<TaskEntity> Tasks { get; set; }
}