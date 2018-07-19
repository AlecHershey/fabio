using Microsoft.EntityFrameworkCore;

namespace Fab.IOProject.Models
{
  public class FabioDbContext : DbContext
  {
    public DbSet<User> Users { get; set; }
    public DbSet<Exercise> Exercises { get; set; }
    public DbSet<Workout> Workouts { get; set; }
    public DbSet<WorkoutExercise> WorkoutExercises { get; set; }
    public DbSet<MuscleGroup> MuscleGroups { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      // make sure the connection string makes sense for your machine
      optionsBuilder.UseSqlServer(@"Server=(local);Database=FabIO;Trusted_Connection=True;");
    }
  }
}
