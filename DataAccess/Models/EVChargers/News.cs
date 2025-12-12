using System;
using System.Collections.Generic;

namespace DataAccess.Models.EVChargers;

public partial class News
{
    /// <summary>
    /// รหัสข่าว
    /// </summary>
    public Guid NewsId { get; set; }

    /// <summary>
    /// ข้อความข่าว
    /// </summary>
    public string NewsMessage { get; set; } = null!;

    /// <summary>
    /// วันที่เริ่มต้นแสดง
    /// </summary>
    public DateTime StartDate { get; set; }

    /// <summary>
    /// วันที่สิ้นสุดแสดง
    /// </summary>
    public DateTime EndDate { get; set; }

    /// <summary>
    /// วันที่สร้าง
    /// </summary>
    public DateTime CreateDate { get; set; }

    /// <summary>
    /// สร้างโดย
    /// </summary>
    public Guid CrateBy { get; set; }

    /// <summary>
    /// สถานะการลบ
    /// </summary>
    public bool IsDelete { get; set; }

    /// <summary>
    /// วันที่ลบ
    /// </summary>
    public DateTime? DeleteDate { get; set; }

    /// <summary>
    /// ลบโดย
    /// </summary>
    public Guid? DeleteBy { get; set; }
}
