using Fab.IOProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FabioWebProject.Controllers
{
  public class UserViewModel
  {
    public string username { get; set; }
    public string password { get; set; }
    public string email { get; set; }
  }

  [Route("api/[controller]")]
  public class UserAccountController : Controller
  {
    public const string salt = "1hGgi$t!!59@0d";

    // GET: api/values
    [HttpGet]
    public IEnumerable<string> Get()
    {
      return new string[] { "value1", "value2" };
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
      return "value";
    }

    // POST api/values
    [HttpPost]
    public ActionResult AddUser([FromBody]UserViewModel uvm)
    {
      using (FabioDbContext DbContext = new FabioDbContext())
      {
        try
        {
          var exists = DbContext.Users.Any(x => x.UserName == uvm.username);
          if (exists)
          {
            throw new Exception("This username already exists!!! suckaaaa");
          }
          var EmailExists = DbContext.Users.Any(x => x.Email == uvm.email);
          if (EmailExists)
          {
            throw new Exception("Email already in use :(");
          }

          User user = new User
          {
            UserName = uvm.username,
            Email = uvm.email
          };

          var passwordBytes = Encoding.ASCII.GetBytes(uvm.password + salt);

          var sha1 = System.Security.Cryptography.SHA1.Create();
          var hash = sha1.ComputeHash(passwordBytes);

          user.Password = Encoding.ASCII.GetString(hash);

          DbContext.Users.Add(user);

          DbContext.SaveChanges();
        }
        catch (Exception ex)
        {
          return Json(new { error = ex.Message });
        }
        return Json(new { success = true });
      }
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody]string value)
    {
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
  }
}
