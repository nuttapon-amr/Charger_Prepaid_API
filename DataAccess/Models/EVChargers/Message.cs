using System;
using System.Collections.Generic;

namespace DataAccess.Models.EVChargers;

public partial class Message
{
    /// <summary>
    /// รหัสข้อความ
    /// </summary>
    public Guid MessageId { get; set; }

    /// <summary>
    /// หัวข้อข้อความ
    /// </summary>
    public string MessageTitle { get; set; } = null!;

    /// <summary>
    /// ข้อความ
    /// </summary>
    public string Message1 { get; set; } = null!;

    /// <summary>
    /// วันที่สร้าง
    /// </summary>
    public DateTime CreateDate { get; set; }

    /// <summary>
    /// สร้างโดย
    /// </summary>
    public Guid CreateBy { get; set; }

    /// <summary>
    /// อัพเดทวันที่
    /// </summary>
    public DateTime UpdateDate { get; set; }

    /// <summary>
    /// อัพเดทโดย
    /// </summary>
    public Guid UpdateBy { get; set; }

    /// <summary>
    /// ลบวันที่
    /// </summary>
    public DateTime? DeleteDate { get; set; }

    /// <summary>
    /// ลบโดย
    /// </summary>
    public Guid? DeleteBy { get; set; }

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();
}
