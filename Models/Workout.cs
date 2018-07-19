namespace Fab.IOProject.Models
{
  public class Workout
  {
    public int Id { get; set; }
    public int UserId { get; set; }
    public int Day { get; set; }
    public bool IsActive { get; set; }
  }
}
