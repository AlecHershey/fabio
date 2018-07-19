using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FabioWebProject
{
  [Route("api/[controller]")]
  public class ValuesController : Controller
  {
    // GET: api/values
    [HttpGet]
    public IEnumerable<string> Get()
    {
      return new string[] { "Alec", "Is", "The", "Best", "DEVELOPER!!!!!" };
    }
  }
}
