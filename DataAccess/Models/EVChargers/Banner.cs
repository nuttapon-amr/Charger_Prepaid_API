using System;
using System.Collections.Generic;

namespace DataAccess.Models.EVChargers;

public partial class Banner
{
    /// <summary>
    /// รหัสแบนเนอร์
    /// </summary>
    public Guid BannerId { get; set; }

    /// <summary>
    /// รหัสไฟล์
    /// </summary>
    public Guid FileId { get; set; }

    /// <summary>
    /// ชื่อประเภท
    /// </summary>
    public string TypeName { get; set; } = null!;

    /// <summary>
    /// ลิงค์เว็บไซต์
    /// </summary>
    public string ClickLink { get; set; } = null!;

    /// <summary>
    /// สถานะการแสดง
    /// </summary>
    public bool IsShow { get; set; }
}
