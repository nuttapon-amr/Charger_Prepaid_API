using System;
using System.Collections.Generic;

namespace DataAccess.Models.EVChargers;

public partial class ChargePoint
{
    /// <summary>
    /// รหัสหัสชาร์จ
    /// </summary>
    public Guid ChargePointId { get; set; }

    /// <summary>
    /// รหัสชาร์จเจอร์
    /// </summary>
    public int ChargerId { get; set; }

    /// <summary>
    /// หมายเลขหัวชาร์จ
    /// </summary>
    public int CnNo { get; set; }

    /// <summary>
    /// ประเภทหัวชาร์จ
    /// </summary>
    public string ChargerPointType { get; set; } = null!;

    /// <summary>
    /// สถานะการเชื่อมต่อ
    /// </summary>
    public string? Connection { get; set; }

    /// <summary>
    /// วันที่ลบ
    /// </summary>
    public DateTime? DeleteDate { get; set; }

    /// <summary>
    /// สถานะการลบ
    /// </summary>
    public bool? IsDelete { get; set; }

    /// <summary>
    /// ค่าพลังงานสูงสุด
    /// </summary>
    public int MaxPower { get; set; }

    /// <summary>
    /// ค่าพลังงานที่กำหนด
    /// </summary>
    public int SetPower { get; set; }

    /// <summary>
    /// สถานะการตั้งค่าอัตโนมัติ
    /// </summary>
    public bool IsAuto { get; set; }

    /// <summary>
    /// สถานะการใช้งาน
    /// </summary>
    public bool Status { get; set; }

    /// <summary>
    /// สถานะการจอง 0=ต้องจองก่อน 1= ไม่ต้องจองก่อน
    /// </summary>
    public bool IsWalkIn { get; set; }

    public virtual ICollection<BookingTimeSlot> BookingTimeSlots { get; set; } = new List<BookingTimeSlot>();

    public virtual Charger Charger { get; set; } = null!;

    public virtual ICollection<ChargerBooking> ChargerBookings { get; set; } = new List<ChargerBooking>();

    public virtual ICollection<ChargerPurchase> ChargerPurchases { get; set; } = new List<ChargerPurchase>();

    public virtual ICollection<UnitPriceSchedule> UnitPriceSchedules { get; set; } = new List<UnitPriceSchedule>();

    public virtual ICollection<UnitPrice> UnitPrices { get; set; } = new List<UnitPrice>();
}
