using System;
using System.Collections.Generic;

namespace DataAccess.Models.EVChargers;

public partial class PrePaidToken
{
    public int PrePaidId { get; set; }

    public Guid TokenId { get; set; }

    public string Username { get; set; } = null!;

    public DateTime ExpiresDate { get; set; }

    public DateTime CreatedDate { get; set; }

    public bool IsRevoked { get; set; }

    public DateTime LastUsedDate { get; set; }
}
