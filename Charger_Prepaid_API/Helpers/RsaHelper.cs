using System.Security.Cryptography;
using System.Text;
using Charger_prepaid_API.Models;

namespace Charger_prepaid_API.Helpers;

public class RsaHelper
{
    private readonly string _privateKeyPem;

    public RsaHelper(IWebHostEnvironment env)
    {
        var privateKeyPath = Path.Combine(env.ContentRootPath, "Keys", "private.pem");
        _privateKeyPem = System.IO.File.ReadAllText(privateKeyPath);
    }
    
    public async Task<bool> RsaDecrypt(LoginReqDto request)
    {
        try
        {
            var cipherBytes = Convert.FromBase64String(request.EncryptedPhone);
 
            using var rsa = RSA.Create();
            rsa.ImportFromPem(_privateKeyPem);
 
            var plainBytes = rsa.Decrypt(cipherBytes, RSAEncryptionPadding.OaepSHA256);
        
            var phone = Encoding.UTF8.GetString(plainBytes);
            
            if(string.IsNullOrWhiteSpace(phone)) return false; 
            return true;
        }
        catch (Exception e)
        {
            return false; 
        }
   
    }
}