using Fab.IOProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FabioWebProject.Migrations
{
  [DbContext(typeof(FabioDbContext))]
  partial class FabioDbContextModelSnapshot : ModelSnapshot
  {
    protected override void BuildModel(ModelBuilder modelBuilder)
    {
      modelBuilder
          .HasAnnotation("ProductVersion", "1.1.5")
          .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

      modelBuilder.Entity("Fab.IOProject.Models.Exercise", b =>
          {
            b.Property<int>("Id")
                      .ValueGeneratedOnAdd();

            b.Property<int>("MuscleGroupId");

            b.Property<string>("Name");

            b.HasKey("Id");

            b.ToTable("Exercises");
          });

      modelBuilder.Entity("Fab.IOProject.Models.MuscleGroup", b =>
          {
            b.Property<int>("Id")
                      .ValueGeneratedOnAdd();

            b.Property<string>("Abdominals");

            b.Property<string>("Arms");

            b.Property<string>("Back");

            b.Property<string>("Chest");

            b.Property<string>("Legs");

            b.Property<string>("Shoulders");

            b.HasKey("Id");

            b.ToTable("MuscleGroups");
          });

      modelBuilder.Entity("Fab.IOProject.Models.User", b =>
          {
            b.Property<int>("Id")
                      .ValueGeneratedOnAdd();

            b.Property<int>("Age");

            b.Property<string>("City");

            b.Property<string>("Email");

            b.Property<string>("FirstName");

            b.Property<int>("Height");

            b.Property<string>("LastName");

            b.Property<string>("Password");

            b.Property<string>("UserName");

            b.Property<double>("Weight");

            b.HasKey("Id");

            b.ToTable("Users");
          });

      modelBuilder.Entity("Fab.IOProject.Models.Workout", b =>
          {
            b.Property<int>("Id")
                      .ValueGeneratedOnAdd();

            b.Property<int>("Day");

            b.Property<bool>("IsActive");

            b.Property<int>("UserId");

            b.HasKey("Id");

            b.ToTable("Workouts");
          });

      modelBuilder.Entity("Fab.IOProject.Models.WorkoutExercise", b =>
          {
            b.Property<int>("Id")
                      .ValueGeneratedOnAdd();

            b.Property<int>("ExerciseID");

            b.Property<int>("Repetitions");

            b.Property<int>("Sets");

            b.Property<int>("WorkoutID");

            b.HasKey("Id");

            b.ToTable("WorkoutExercises");
          });
    }
  }
}
