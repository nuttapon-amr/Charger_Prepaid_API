using System;
using System.Collections.Generic;

namespace DataAccess.Models.EVChargers;

public partial class UserKey
{
    /// <summary>
    /// รหัสประจำตัวkey
    /// </summary>
    public Guid UserKeyId { get; set; }

    /// <summary>
    /// ประเภทของkey 1=rfid 2=vid
    /// </summary>
    public string UserKeyType { get; set; } = null!;

    /// <summary>
    /// ค่าkey
    /// </summary>
    public string UserKeyValue { get; set; } = null!;

    /// <summary>
    /// รหัสผู้ใช้งาน
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// วันที่สร้าง
    /// </summary>
    public DateTime CreateDate { get; set; }

    /// <summary>
    /// ผู้สร้าง
    /// </summary>
    public Guid CreateBy { get; set; }

    /// <summary>
    /// วันที่ปรับปรุง
    /// </summary>
    public DateTime UpdateDate { get; set; }

    /// <summary>
    /// ผู้ปรังปรุง
    /// </summary>
    public Guid UpdateBy { get; set; }

    /// <summary>
    /// สถานะการลบ
    /// </summary>
    public bool IsDelete { get; set; }

    /// <summary>
    /// วันที่ลบ
    /// </summary>
    public DateTime? DeleteDate { get; set; }

    /// <summary>
    /// รองรับการยืนยันตัวตนแบบ offline ac=20 card,dc=50 card
    /// </summary>
    public bool IsSupportOffline { get; set; }
}
