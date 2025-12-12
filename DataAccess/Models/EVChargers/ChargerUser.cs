using System;
using System.Collections.Generic;

namespace DataAccess.Models.EVChargers;

public partial class ChargerUser
{
    /// <summary>
    /// รหัสเครื่องชาร์จกับผู้ใช้งาน
    /// </summary>
    public int ChargerUserId { get; set; }

    /// <summary>
    /// รหัสเครื่องชาร์จ
    /// </summary>
    public int? ChargerId { get; set; }

    /// <summary>
    /// รหัสผู้ใช้งาน
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// สร้างโดย
    /// </summary>
    public Guid? CreateBy { get; set; }

    /// <summary>
    /// สร้างวันที่
    /// </summary>
    public DateTime? CreateDate { get; set; }

    /// <summary>
    /// สถานะการใช้งาน
    /// </summary>
    public bool? Status { get; set; }

    /// <summary>
    /// ลบโดย
    /// </summary>
    public string? DeleteBy { get; set; }

    /// <summary>
    /// วันที่ลบ
    /// </summary>
    public DateTime? DeleteDate { get; set; }

    /// <summary>
    /// สถานะการลบ
    /// </summary>
    public bool? IsDelete { get; set; }

    public virtual Charger? Charger { get; set; }
}
