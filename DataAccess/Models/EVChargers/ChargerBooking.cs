using System;
using System.Collections.Generic;

namespace DataAccess.Models.EVChargers;

public partial class ChargerBooking
{
    /// <summary>
    /// รหัสการจอง
    /// </summary>
    public int ChargerBookingId { get; set; }

    /// <summary>
    /// รหัสหัวชาร์จ
    /// </summary>
    public Guid ChargePointId { get; set; }

    /// <summary>
    /// รหัสผู้ใช้งาน
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// ช่วงเวลาที่เริ่มจองและชาร์จ
    /// </summary>
    public DateTime StartDate { get; set; }

    /// <summary>
    /// ช่วงเวลาสิ้นสุดการชาร์จ
    /// </summary>
    public DateTime EndDate { get; set; }

    /// <summary>
    /// จำนวน block ที่จอง
    /// </summary>
    public int TotalSlot { get; set; }

    /// <summary>
    /// วันที่สร้าง
    /// </summary>
    public DateTime CreateDate { get; set; }

    /// <summary>
    /// สถานะการยกเลิก
    /// </summary>
    public bool IsCancel { get; set; }

    /// <summary>
    /// ประเภทการยกเลิก 0=user ยกเลิก 1=มาไม่ทันกำหนดเวลา 2=ผู้ดูแลยกเลิก
    /// </summary>
    public int? CancelReasonType { get; set; }

    /// <summary>
    /// เหตุผลการยกเลิกการจอง
    /// </summary>
    public string? CancelReason { get; set; }

    /// <summary>
    /// วันที่ยกเลิก
    /// </summary>
    public DateTime? CancelDate { get; set; }

    /// <summary>
    /// ยกเลิกโดย
    /// </summary>
    public Guid? CancelBy { get; set; }

    /// <summary>
    /// สถานะการจอง 0=กำลังจอง 1=จองเรียบร้อย 2=เลิกจอง 3=ใช้งานเสร็จ
    /// </summary>
    public int Status { get; set; }

    /// <summary>
    /// สถานะการชำระ
    /// </summary>
    public bool IsPaid { get; set; }

    /// <summary>
    /// รหัสใบกำกับภาษี
    /// </summary>
    public Guid? TaxInvoiceId { get; set; }

    /// <summary>
    /// รหัสข้อมูลผู้เสียภาษี
    /// </summary>
    public Guid? TaxpayerinfoId { get; set; }

    /// <summary>
    /// วันที่ชำระ
    /// </summary>
    public DateTime? PaidDate { get; set; }

    /// <summary>
    /// จำนวนเงิน
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// ค่าบริการ
    /// </summary>
    public decimal Fee { get; set; }

    /// <summary>
    /// สุทธิ
    /// </summary>
    public decimal Net { get; set; }

    /// <summary>
    /// อัตราค่าธรรมเนียมร้อยละ
    /// </summary>
    public double PercentageFeeRate { get; set; }

    /// <summary>
    /// ราคา
    /// </summary>
    public double Price { get; set; }

    /// <summary>
    /// ช่วงเวลาของช่องslot หน่วยนาที
    /// </summary>
    public string BookingTimeSlotMinute { get; set; } = null!;

    public virtual ChargePoint ChargePoint { get; set; } = null!;

    public virtual ICollection<ChargerHeartBeat> ChargerHeartBeats { get; set; } = new List<ChargerHeartBeat>();

    public virtual ICollection<ChargerSummary> ChargerSummaries { get; set; } = new List<ChargerSummary>();
}
