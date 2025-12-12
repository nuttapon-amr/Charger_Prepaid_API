using Charger_Prepaid_API.Helpers;
using Charger_prepaid_API.Models;
using DataAccess.Models.EVChargers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Charger_prepaid_API.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthenController : ControllerBase
{
    private readonly EvchargersContext  _context;

    public AuthenController(EvchargersContext context)
    {
        _context = context;
    }
    
    [HttpPost("otp")]
    public async Task<IActionResult> Index([FromQuery] string phoneNumber, [FromQuery] string otp)
    {
        ResponseData  data = new ResponseData(); 
        try
        {
            if (string.IsNullOrWhiteSpace(phoneNumber) || string.IsNullOrWhiteSpace(otp) || phoneNumber.Length == 10)
                return BadRequest("otp , phoneNumber parameters are required ");
            // ตรวจสอบ invalid phone , otp
            // ออก token  
            
            bool verifyOtp = true; 
            if (verifyOtp)
            {
                var tokenObj = new PrePaidToken()
                {
                 TokenId = Guid.NewGuid(),
                 Username = phoneNumber,
                 ExpiresDate = DateTime.Now.AddHours(1),
                 CreatedDate = DateTime.Now,
                 IsRevoked = false,
                 LastUsedDate = DateTime.Now,
                };
                await _context.PrePaidTokens.AddAsync(tokenObj);
                await _context.SaveChangesAsync();
        
                data = new  ResponseData(1002,tokenObj.TokenId);
                return Ok(data);
            }
            else
            {
                data = new ResponseData(9100);
                return Unauthorized(data);
            }
        }
        catch (Exception e)
        {
            data = new ResponseData(9903,e.Message);
            return  BadRequest(data);
        }

    }

    [HttpGet("status/{tokenId}")]
    public async Task<IActionResult> GetStatus([FromQuery] string tokenId)
    {
        ResponseData  data = new ResponseData();
        try
        {
            if (string.IsNullOrWhiteSpace(tokenId))
            {
                data = new ResponseData(1101);
                return Unauthorized(data);
            }

            StatusHelper helper = new StatusHelper(_context);
            var check = await helper.GetUserStatus(tokenId);
            if (check == null)
            {
                return Unauthorized();
            }
            else
            {
                return Ok(check);
            }

            // token expire
            // ถ้า token invalid ให้ไปหน้า login
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}