using System;
using System.Collections.Generic;

namespace DataAccess.Models.EVChargers;

public partial class ApplicationVersion
{
    /// <summary>
    /// ลำดับเวอร์ชั่นแอปพลิเคชั่น
    /// </summary>
    public int ApplicationVersionId { get; set; }

    /// <summary>
    /// หมายเลขเวอร์ชั่น
    /// </summary>
    public string VersionNumber { get; set; } = null!;

    /// <summary>
    /// วันที่สร้าง
    /// </summary>
    public DateTime CreateDate { get; set; }

    /// <summary>
    /// สถานะการลบ
    /// </summary>
    public bool IsDelete { get; set; }
}
