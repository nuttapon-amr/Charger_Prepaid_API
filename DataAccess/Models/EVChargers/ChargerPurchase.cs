using System;
using System.Collections.Generic;

namespace DataAccess.Models.EVChargers;

public partial class ChargerPurchase
{
    /// <summary>
    /// รหัสการชำระเงิน
    /// </summary>
    public int PaymentId { get; set; }

    /// <summary>
    /// รหัสหัวชาร์จ
    /// </summary>
    public Guid ChargePointId { get; set; }

    /// <summary>
    /// รหัสธุรกรรม
    /// </summary>
    public int? TransId { get; set; }

    /// <summary>
    /// รหัสการจอง
    /// </summary>
    public int? ChargerBookingId { get; set; }

    /// <summary>
    /// หมายเลขอ้างอิง1
    /// </summary>
    public string Ref1 { get; set; } = null!;

    /// <summary>
    /// หมายเลขอ้างอิง2
    /// </summary>
    public string Ref2 { get; set; } = null!;

    /// <summary>
    /// รหัสผู้ใช้งาน
    /// </summary>
    public string UserId { get; set; } = null!;

    /// <summary>
    /// จำนวนเงิน
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// วันที่สร้าง
    /// </summary>
    public DateTime CreateDate { get; set; }

    /// <summary>
    /// สถานะการชำระเงิน
    /// </summary>
    public bool IsPaid { get; set; }

    /// <summary>
    /// วันที่ชำระเงิน
    /// </summary>
    public DateTime? PaidDate { get; set; }

    /// <summary>
    /// สถานะการลบ
    /// </summary>
    public bool IsDelete { get; set; }

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
    /// วิธีการชำระ เช่น qrcode creditcard
    /// </summary>
    public string PaymentType { get; set; } = null!;

    public virtual ChargePoint ChargePoint { get; set; } = null!;
}
