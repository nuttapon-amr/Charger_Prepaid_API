using Charger_prepaid_API.Helpers;
using Charger_prepaid_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Charger_prepaid_API.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthenController : ControllerBase
{
   private IWebHostEnvironment env;

   public AuthenController(IWebHostEnvironment env)
   {
      this.env = env;
   }
   [HttpPost]
   public async Task<IActionResult> Index([FromBody] LoginReqDto request)
   {
      try
      {
         if (string.IsNullOrWhiteSpace(request.EncryptedPhone))
            return BadRequest("EncryptedPhone is required");
      
         RsaHelper rsa = new RsaHelper(env);
         bool reult = await rsa.RsaDecrypt(request);

         if (reult)
         {
            return Ok();
         }
         else
         {
            return Unauthorized(); 
         }
      }
      catch (Exception e)
      {
         return StatusCode(500, e);
      }
      
   }
}