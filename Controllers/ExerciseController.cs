using Fab.IOProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Fab.IOProject.Controllers
{
  [Route("api/[controller]")]
  public class ExerciseController : Controller
  {
    // GET: Exercise
    [HttpGet]
    public IEnumerable<Exercise> Get()
    {
      using (FabioDbContext DbContext = new FabioDbContext())
      {
        return DbContext.Exercises.ToList();
      }
    }
  }
}
