using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FabioWebProject.Migrations
{
  public partial class CreateDatabase : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.CreateTable(
          name: "Exercises",
          columns: table => new
          {
            Id = table.Column<int>(nullable: false)
                  .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            MuscleGroupId = table.Column<int>(nullable: false),
            Name = table.Column<string>(nullable: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Exercises", x => x.Id);
          });

      migrationBuilder.CreateTable(
          name: "MuscleGroups",
          columns: table => new
          {
            Id = table.Column<int>(nullable: false)
                  .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            Abdominals = table.Column<string>(nullable: true),
            Arms = table.Column<string>(nullable: true),
            Back = table.Column<string>(nullable: true),
            Chest = table.Column<string>(nullable: true),
            Legs = table.Column<string>(nullable: true),
            Shoulders = table.Column<string>(nullable: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_MuscleGroups", x => x.Id);
          });

      migrationBuilder.CreateTable(
          name: "Users",
          columns: table => new
          {
            Id = table.Column<int>(nullable: false)
                  .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            Age = table.Column<int>(nullable: false),
            City = table.Column<string>(nullable: true),
            FirstName = table.Column<string>(nullable: true),
            Height = table.Column<int>(nullable: false),
            LastName = table.Column<string>(nullable: true),
            Weight = table.Column<double>(nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Users", x => x.Id);
          });

      migrationBuilder.CreateTable(
          name: "Workouts",
          columns: table => new
          {
            Id = table.Column<int>(nullable: false)
                  .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            Day = table.Column<int>(nullable: false),
            IsActive = table.Column<bool>(nullable: false),
            UserId = table.Column<int>(nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Workouts", x => x.Id);
          });

      migrationBuilder.CreateTable(
          name: "WorkoutExercises",
          columns: table => new
          {
            Id = table.Column<int>(nullable: false)
                  .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            ExerciseID = table.Column<int>(nullable: false),
            Repetitions = table.Column<int>(nullable: false),
            Sets = table.Column<int>(nullable: false),
            WorkoutID = table.Column<int>(nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_WorkoutExercises", x => x.Id);
          });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
          name: "Exercises");

      migrationBuilder.DropTable(
          name: "MuscleGroups");

      migrationBuilder.DropTable(
          name: "Users");

      migrationBuilder.DropTable(
          name: "Workouts");

      migrationBuilder.DropTable(
          name: "WorkoutExercises");
    }
  }
}
