using DataAccess.Models.EVChargers;
using Microsoft.EntityFrameworkCore;

namespace Charger_Prepaid_API.Helpers;

public class StatusHelper
{
    private readonly EvchargersContext  _context;
    public StatusHelper(EvchargersContext  context)
    {
        _context = context;
    }

    public async Task<ResponseUserStatus> GetUserStatus(string TokenId)
    {
        try
        {
            PrePaidToken tokenDetail = new PrePaidToken();

            // token isRevoked
            if (!string.IsNullOrEmpty(TokenId) && await isRevoked(TokenId))
            {
                return new ResponseUserStatus()
                {
                    PageName = PageName.login,
                    TokenId = TokenId
                };
            }
 
            // ตรวจสอบ token หมดอายุ หรือมีในระบบหรือไม่
            if (!string.IsNullOrEmpty(TokenId))
            {
                tokenDetail = await GetTokenDetail(TokenId);
                // ไม่มีในระบบ 
                if (tokenDetail == null)
                { 
                    return  new ResponseUserStatus()
                    {
                        PageName = PageName.login, 
                        TokenId = TokenId
                    };
                }

            } 
        
            return new ResponseUserStatus();
        }
        catch  
        {
           return new ResponseUserStatus();
        }
        
    }
    
    public async Task<ResponseUserStatus> GetStatus(ResponseUserStatus userStatus)
    {
        try
        {
            PrePaidToken tokenDetail = new PrePaidToken();
   
            // token isRevoked
            if (userStatus.TokenId != null && await isRevoked(userStatus.TokenId))
            {
                return new ResponseUserStatus()
                {
                    PageName = PageName.login
                };
            }
 
            // ตรวจสอบ token หมดอายุ หรือมีในระบบหรือไม่
            if (userStatus.TokenId != null)
            {
                tokenDetail = await GetTokenDetail(userStatus.TokenId);
                // ไม่มีในระบบ 
                if (tokenDetail == null)
                { 
                  return  new ResponseUserStatus()
                    {
                        PageName = PageName.login, 
                    };
                }
                
                
            }
             
            //  chargerpointId ไม่มี
            if (string.IsNullOrEmpty(userStatus.ChargerPointId))
            {
                return new ResponseUserStatus()
                {
                    PageName = PageName.history,
                    TokenId = tokenDetail.TokenId.ToString()
                };
            }
             
            var chargers = await _context.ChargePoints
                .Include(i=>i.Charger) 
                .Select(s=> new
                {
                    s.ChargePointId,
                    s.Charger.CpId,
                    s.CnNo
                })
                .ToListAsync(); 
            
            // ตรวจสอบธุรกรรมล่าสุด
            var tran = await _context.ChargerSummaries
                .Where(w=>w.TagId == tokenDetail.Username)
                .OrderByDescending(o=>o.TransUpdate)
                .FirstOrDefaultAsync();
            
            var heartbeat = await _context.ChargerHeartBeats
                .Where(w => w.TagId  == tokenDetail.Username  )
                .FirstOrDefaultAsync();
            
            // ไม่เจอธุรกรรมล่าสุด ไม่เคยใช้งานหัวนี้มาก่อน  
            if (tran == null)
            { 
                if (heartbeat == null)
                {
                    // check wallets 
                    // {
                    //     return (PageName.topup,null);
                    // }
                    return new ResponseUserStatus()
                    {
                        PageName = PageName.topup,
                        TokenId = tokenDetail.TokenId.ToString()
                    };
                }
                else if(await isCharger(heartbeat))
                {
                    // ผู้ใช้งานนี้ กำลังชาร์จอยุ่ 
                    return new ResponseUserStatus()
                    {
                        PageName = PageName.chargerdetail,
                        TokenId = tokenDetail.TokenId.ToString()
                    };
                }
                else
                {
                    // ผู้ใช้งานไม่ได้ทำอะไรเลยให้มาหน้า เติมเงิน เพื่อเลือกการชาร์จแบบ เหมาหรือ แบบต่อหน่วย  
                    // check wallets 
                    // {
                    //     return (PageName.topup,null);
                    // } 
                    return new ResponseUserStatus()
                    {
                        PageName = PageName.topup,
                        TokenId = tokenDetail.TokenId.ToString()
                    };
                } 
            }
            else
            {
                // เช็คว่า ตอนนี้หัวที่ใช้งานอยุ่ล่าสุดเป็นหัวชาร์จไหน 
                // หัวชาร์จปัจจุบัน ตรงกับ tran หรือผู้ใช้งานใช้หัวชาร์จเดิม
                      
                var chargerCurrent  = chargers
                    .Where(w=>w.ChargePointId.ToString() == userStatus.ChargerPointId)
                    .FirstOrDefault();
                
                // หัวชาร์จปัจจุบันที่ ผู้ใช้งานส่งเข้ามากำลังชาร์จอยุ่
                if (chargerCurrent != null && 
                    heartbeat != null &&
                    chargerCurrent.CnNo == heartbeat.CnNo && 
                    chargerCurrent.CpId == heartbeat.CpId  
                    )
                {
                    // check wallets 
                    // {
                    //     return (PageName.topup,null);
                    // }
                    return new ResponseUserStatus()
                    {
                        PageName = PageName.chargerdetail,
                        TokenId = tokenDetail.TokenId.ToString(),
                        ChargerPointId = chargerCurrent.ChargePointId.ToString()
                    };
                }
                else
                {
                    //ผู้ใช้งานนี้ยังไม่ได้ทำการชาร์จใดๆ หัวชาร์จไม่มีการใช้งาน แต่ยังมีธุรกรรมเก่าที่เคยชาร์จ 
                    return new ResponseUserStatus()
                    {
                        PageName = PageName.history,
                        TokenId = tokenDetail.TokenId.ToString()
                    };
                }
            }
        }
        catch (Exception e)
        {
            return new ResponseUserStatus()
            {
                PageName = PageName.err,
                TokenId = userStatus.TokenId
            };
        }
    }

    private async Task<bool> isCharger (ChargerHeartBeat heartBeat)
    {
        var status = heartBeat.CnStatus;
        switch (status.ToLower())
        { 
            case "charging":
                return true;
            case "suspendedev":
            case "preparing":
                return true; 
            default:
                return false;
        }
    }
  
    public async Task<PrePaidToken> GetTokenDetail (string tokenId) 
    {
        try
        {
            var check = await _context.PrePaidTokens.Where(w => w.TokenId.ToString() == tokenId).FirstOrDefaultAsync();
           
            if(check == null) return null;
           
            if (check.ExpiresDate > DateTime.Now)
            {
                return check;
            }
            else
            {
                // refresh Token
                var tokenObj = new PrePaidToken()
                {
                    TokenId = Guid.NewGuid(),
                    Username = check.Username,
                    ExpiresDate = DateTime.Now.AddHours(1),
                    CreatedDate = DateTime.Now,
                    IsRevoked = false,
                    LastUsedDate = DateTime.Now,
                };
                check.IsRevoked = true;
                await _context.PrePaidTokens.AddAsync(tokenObj);
                await _context.SaveChangesAsync(); 
                
                return tokenObj;
            }
        }
        catch  
        {
            return null;
        }
    }

    public async Task<bool> isRevoked(string tokenId)
    {
        try
        {
            var  check = await _context.PrePaidTokens.AnyAsync(w => w.TokenId.ToString() == tokenId && w.IsRevoked);
            return check;
        }
        catch (Exception e)
        {
          return false; 
        }
    }
    public class ResponseUserStatus
    {
        public PageName  PageName { get; set; }
        public string? ChargerPointId { get; set; }
        public string? TokenId { get; set; }
    }

    public enum PageName
    {
        err,
        login,
        history,
        chargerdetail,
        topup,
        refreshtoken
        
    }
}