using System;
using System.Collections.Generic;

namespace DataAccess.Models.EVChargers;

public partial class Fcm
{
    /// <summary>
    /// รหัสการแจ้งเตือน
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// รหัสผู้ใช้งาน
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// โทเคน
    /// </summary>
    public string FcmToken { get; set; } = null!;

    /// <summary>
    /// วันที่สร้าง
    /// </summary>
    public DateTime CreateDate { get; set; }

    /// <summary>
    /// วันที่ลบ
    /// </summary>
    public bool IsDelete { get; set; }

    /// <summary>
    /// วันที่ลบ
    /// </summary>
    public DateTime? DeleteDate { get; set; }
}
