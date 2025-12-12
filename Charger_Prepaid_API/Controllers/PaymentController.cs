using Charger_prepaid_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Charger_prepaid_API.Controllers;

[ApiController]
[Route("[controller]")]
public class PaymentController : ControllerBase
{ 
    public PaymentController( )
    {
    
    }

    [HttpGet("Wallets/{userId}")]
    public async Task<IActionResult> GetWallets([FromQuery] string userId)
    {
        try
        {
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    [HttpPost("Wallets/Deposit")]
    public async Task<IActionResult> Deposit([FromBody]WalletDepositDto walletDepositDto)
    {
        try
        {
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}