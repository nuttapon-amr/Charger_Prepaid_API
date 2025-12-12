using System;
using System.Collections.Generic;

namespace DataAccess.Models.EVChargers;

public partial class ChargerCmd
{
    /// <summary>
    /// รหัสคำสั่ง
    /// </summary>
    public int ChargerCmdId { get; set; }

    /// <summary>
    /// ข้อความคำสั่ง
    /// </summary>
    public string ChargerCmdMessage { get; set; } = null!;

    /// <summary>
    /// วันที่สร้าง
    /// </summary>
    public DateTime ChargerCmdCreateDate { get; set; }

    /// <summary>
    /// สถานะการส่งคำสั่ง
    /// </summary>
    public bool ChargerCmdStatus { get; set; }

    /// <summary>
    /// รหัสผู้ใช้งาน ผู้ส่งคำสั่ง
    /// </summary>
    public Guid? UserId { get; set; }
}
