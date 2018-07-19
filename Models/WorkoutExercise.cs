namespace Fab.IOProject.Models
{
  public class WorkoutExercise
  {
    public int Id { get; set; }
    public int WorkoutID { get; set; }
    public int ExerciseID { get; set; }
    public int Sets { get; set; }
    public int Repetitions { get; set; }
  }
}
