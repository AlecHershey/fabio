using Fab.IOProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fab.IOProject.Controllers
{
  public class WorkoutExerciseModel
  {
    public int id { get; set; }
    public int workoutid { get; set; }
    public int exerciseid { get; set; }
    public string exercise { get; set; }
    public int sets { get; set; }
    public int repetitions { get; set; }
  }

  public class WorkoutModel
  {
    public int id { get; set; }
    public int day { get; set; }
    public List<WorkoutExerciseModel> exercises { get; set; }
  }

  [Route("api/[controller]")]
  public class WorkoutController : Controller
  {
    [HttpPost]
    public ActionResult AddWorkout([FromBody]WorkoutModel uvm)
    {
      WorkoutModel response = new WorkoutModel();

      Workout workout = new Workout
      {
        Day = uvm.day,
        // UserId = uvm.userId,
        UserId = Convert.ToInt32(HttpContext.User.Claims.First(x => x.Type == "Id").Value),
        Id = uvm.id
      };

      using (FabioDbContext DbContext = new FabioDbContext())
      {
        if (uvm.id == 0)
        {
          DbContext.Workouts.Add(workout);

          DbContext.SaveChanges();

          foreach (var wem in uvm.exercises)
          {
            var workoutExercise = new WorkoutExercise
            {
              WorkoutID = workout.Id,
              ExerciseID = wem.exerciseid,
              Repetitions = wem.repetitions,
              Sets = wem.sets,
              Id = wem.id
            };

            DbContext.WorkoutExercises.Add(workoutExercise);
          }

          DbContext.SaveChanges();
        }
        else
        {
          foreach (var wem in uvm.exercises)
          {
            if (wem.id > 0)
            {
              var workoutExercise = new WorkoutExercise
              {
                WorkoutID = workout.Id,
                ExerciseID = wem.exerciseid,
                Repetitions = wem.repetitions,
                Sets = wem.sets,
                Id = wem.id
              };

              DbContext.WorkoutExercises.Update(workoutExercise);
            }
            else
            {
              var workoutExercise = new WorkoutExercise
              {
                WorkoutID = workout.Id,
                ExerciseID = wem.exerciseid,
                Repetitions = wem.repetitions,
                Sets = wem.sets,
                Id = wem.id
              };

              DbContext.WorkoutExercises.Add(workoutExercise);
            }

            DbContext.SaveChanges();
          }
        }
        response.day = workout.Day;
        response.id = workout.Id;

        response.exercises = DbContext.WorkoutExercises.Where(x => workout.Id == x.WorkoutID)
          .Select(x => new WorkoutExerciseModel
          {
            exerciseid = x.ExerciseID,
            repetitions = x.Repetitions,
            sets = x.Sets,
            workoutid = x.WorkoutID,
            exercise = DbContext.Exercises.First(z => z.Id == x.ExerciseID).Name,
            id = x.Id
          })
          .ToList();

        return Json(response);
      }
    }

    [HttpGet]
    public ActionResult Index(int day)
    {
      WorkoutModel response = new WorkoutModel();

      int userId = Convert.ToInt32(HttpContext.User.Claims.First(x => x.Type == "Id").Value);
      Workout workout = new Workout();
      using (FabioDbContext DbContext = new FabioDbContext())
      {
        workout = DbContext.Workouts.FirstOrDefault(x => x.UserId == userId && x.Day == day);

        if (workout == null)
        {
          return Json(response);
        }
        response.day = workout.Day;
        response.id = workout.Id;

        response.exercises = DbContext.WorkoutExercises.Where(x => workout.Id == x.WorkoutID)
          .Select(x => new WorkoutExerciseModel
          {
            exerciseid = x.ExerciseID,
            repetitions = x.Repetitions,
            sets = x.Sets,
            workoutid = x.WorkoutID,
            exercise = DbContext.Exercises.First(z => z.Id == x.ExerciseID).Name,
            id = x.Id
          })
          .ToList();
      }
      return Json(response);
    }

    [HttpDelete]
    public ActionResult DeleteWorkoutExercise(int id)
    {
      bool response = false;
      int UserId = Convert.ToInt32(HttpContext.User.Claims.First(x => x.Type == "Id").Value);

      if (UserId != 0)
      {
        using (FabioDbContext DbContext = new FabioDbContext())
        {
          var exercise = DbContext.WorkoutExercises.FirstOrDefault(x => x.Id == id);
          DbContext.WorkoutExercises.Remove(exercise);
          response = true;
          DbContext.SaveChanges();
        }
      }
      return Json(response);
    }
  }
}
