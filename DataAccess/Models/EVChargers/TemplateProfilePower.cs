using System;
using System.Collections.Generic;

namespace DataAccess.Models.EVChargers;

public partial class TemplateProfilePower
{
    /// <summary>
    /// รหัสโปรไฟล์
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// หมายเลขโปรไฟล์
    /// </summary>
    public int ProfileNumber { get; set; }

    /// <summary>
    /// ช่วงเวลาเริ่มต้น
    /// </summary>
    public string StartTime { get; set; } = null!;

    /// <summary>
    /// ช่วงเวลาสิ้นสุด
    /// </summary>
    public string EndTime { get; set; } = null!;

    /// <summary>
    /// จำนวนเปอร์เซ็นต์
    /// </summary>
    public int Percent { get; set; }

    /// <summary>
    /// สถานะการลบ
    /// </summary>
    public bool IsDelete { get; set; }
}
