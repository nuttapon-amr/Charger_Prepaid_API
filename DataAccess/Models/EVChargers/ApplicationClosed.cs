using System;
using System.Collections.Generic;

namespace DataAccess.Models.EVChargers;

public partial class ApplicationClosed
{
    /// <summary>
    /// ลำดับการปิดแอปพลิเคชั่น
    /// </summary>
    public int ApplicationClosedId { get; set; }

    /// <summary>
    /// ชื่อฟังก์ชั่น
    /// </summary>
    public string FunctionName { get; set; } = null!;

    /// <summary>
    /// วันที่สร้าง
    /// </summary>
    public DateTime CreateDate { get; set; }

    /// <summary>
    /// วันที่ปิดการใช้งาน
    /// </summary>
    public DateTime StartDate { get; set; }

    /// <summary>
    /// วันที่สิ้นสุดการปิดการใช้งาน
    /// </summary>
    public DateTime EndDate { get; set; }

    /// <summary>
    /// สถานะการลบ
    /// </summary>
    public bool IsDelete { get; set; }
}
