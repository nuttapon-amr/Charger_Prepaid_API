using System;
using System.Collections.Generic;

namespace DataAccess.Models.EVChargers;

public partial class BookingTimeSlot
{
    /// <summary>
    /// รหัสข้อมูล
    /// </summary>
    public Guid BookingTimeSlotId { get; set; }

    /// <summary>
    /// รหัสหัวชาร์จ
    /// </summary>
    public Guid ChargePointId { get; set; }

    /// <summary>
    /// ราคาต่อ slot
    /// </summary>
    public double SlotPrice { get; set; }

    /// <summary>
    /// ช่วงเวลาของช่องslot หน่วยนาที
    /// </summary>
    public string BookingTimeSlotMinute { get; set; } = null!;

    /// <summary>
    /// วันที่สร้าง
    /// </summary>
    public DateTime CreateDate { get; set; }

    /// <summary>
    /// สร้างโดย
    /// </summary>
    public Guid CreateBy { get; set; }

    /// <summary>
    /// วันที่ปรับปรุงข้อมูล
    /// </summary>
    public DateTime UpdateDate { get; set; }

    /// <summary>
    /// รหัสผู้ปรับปรุงข้อมูล
    /// </summary>
    public Guid UpdateBy { get; set; }

    public virtual ChargePoint ChargePoint { get; set; } = null!;
}
