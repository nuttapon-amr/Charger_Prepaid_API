using System;
using System.Collections.Generic;

namespace DataAccess.Models.EVChargers;

public partial class UnitPriceSchedule
{
    /// <summary>
    /// รหัสการตั้งราคาตามช่วงเวลา
    /// </summary>
    public Guid UnitPriceScheduleId { get; set; }

    /// <summary>
    /// รหัสหัวชาร์จ
    /// </summary>
    public Guid ChargePointId { get; set; }

    /// <summary>
    /// ราคาต่อหน่วย
    /// </summary>
    public double Price { get; set; }

    /// <summary>
    /// ประเภทการคำนวณ 0 ต่อพลังงาน 1 ต่อชั่วโมง
    /// </summary>
    public int UnitType { get; set; }

    /// <summary>
    /// เวลาเริ่มต้น
    /// </summary>
    public string ScheduleStartTime { get; set; } = null!;

    /// <summary>
    /// เวลาสิ้นสุด
    /// </summary>
    public string ScheduleEndTime { get; set; } = null!;

    /// <summary>
    /// สถานะการตั้งเวลา
    /// </summary>
    public bool ScheduleStatus { get; set; }

    /// <summary>
    /// วันที่สร้าง
    /// </summary>
    public DateTime CreateDate { get; set; }

    /// <summary>
    /// สถานะการลบ
    /// </summary>
    public bool IsDelete { get; set; }

    public virtual ChargePoint ChargePoint { get; set; } = null!;
}
