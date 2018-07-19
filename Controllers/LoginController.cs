using Fab.IOProject.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FabioWebProject.Controllers
{
  public class LoginViewModel
  {
    public string username { get; set; }
    public string password { get; set; }
  }

  [Route("api/[controller]")]
  public class LoginController : Controller
  {
    // POST api/values
    [HttpPost]
    public ActionResult CheckUser([FromBody]LoginViewModel uvm)
    {
      using (FabioDbContext DbContext = new FabioDbContext())
      {
        var user = DbContext.Users.FirstOrDefault(x => x.UserName == uvm.username);
        if (user == null)
        {
          throw new Exception("Username doesn't exist");
        }

        var passwordBytes = Encoding.ASCII.GetBytes(uvm.password + UserAccountController.salt);

        var sha1 = System.Security.Cryptography.SHA1.Create();
        var hash = sha1.ComputeHash(passwordBytes);

        string hashedPassword = Encoding.ASCII.GetString(hash);

        var passwordsMatch = user.Password == hashedPassword;
        if (!passwordsMatch)
        {
          throw new Exception("Incorrect password. ");
        }

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim("Id", user.Id.ToString())
        };

        var claimsIdentity = new ClaimsIdentity(
            claims,
            CookieAuthenticationDefaults.AuthenticationScheme);

        HttpContext.Authentication.SignInAsync(
              CookieAuthenticationDefaults.AuthenticationScheme,
              new ClaimsPrincipal(claimsIdentity),
              new AuthenticationProperties
              {
                IsPersistent = true,
                ExpiresUtc = DateTime.UtcNow.AddDays(7)
              });

        return Json(new { success = true });
      }
    }

    //PUT
    [HttpPut]
    public ActionResult Logout()
    {
      HttpContext.Authentication.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

      return Json(new { success = true });
    }

    //cookie
    public ActionResult Index()
    {
      if (HttpContext.User == null || HttpContext.User.Claims.Count() == 0)
      {
        return Json(null);
      }
      else
      {
        int userId = Convert.ToInt32(HttpContext.User.Claims.First(x => x.Type == "Id").Value);
        User user = null;
        using (FabioDbContext DbContext = new FabioDbContext())
        {
          user = DbContext.Users.FirstOrDefault(x => x.Id == userId);
        }
        return Json(user);
      }
    }
  }
}
