using System;
using System.Collections.Generic;

namespace DataAccess.Models.EVChargers;

public partial class ChargerSummary
{
    public int Id { get; set; }

    /// <summary>
    /// รหัสประจำตัวเครื่องชาร์จ
    /// </summary>
    public string? CpId { get; set; }

    /// <summary>
    /// หมายเลขหัวชาร์จ
    /// </summary>
    public int? CnNo { get; set; }

    /// <summary>
    /// หมายเลขการใช้งาน
    /// </summary>
    public string? TagId { get; set; }

    /// <summary>
    /// หมายเลขธุรกรรม
    /// </summary>
    public int? TransId { get; set; }

    /// <summary>
    /// การเริ่มต้นการใช้งาน
    /// </summary>
    public DateTime? TransStart { get; set; }

    /// <summary>
    /// การสิ้นสุดการใช้งาน
    /// </summary>
    public DateTime? TransUpdate { get; set; }

    /// <summary>
    /// มิเตอร์เริ่มต้น
    /// </summary>
    public double? MeterStart { get; set; }

    /// <summary>
    /// มิเตอร์สินสุด
    /// </summary>
    public double? MeterUpdate { get; set; }

    /// <summary>
    /// จำนวนวินาทีที่ชาร์จ
    /// </summary>
    public int? TimeChargeringSecond { get; set; }

    /// <summary>
    /// คาบอนเครดิตที่ได้รับ
    /// </summary>
    public double? CarbonReduction { get; set; }

    /// <summary>
    /// จำนวนหน่วยไฟฟ้าที่ชาร์จ
    /// </summary>
    public double? UseMeterKw { get; set; }

    /// <summary>
    /// สถานะการชำระ
    /// </summary>
    public bool IsPaid { get; set; }

    /// <summary>
    /// วันที่ชำระ
    /// </summary>
    public DateTime? PaidDate { get; set; }

    /// <summary>
    /// วันที่สร้าง
    /// </summary>
    public DateTime? CreateDate { get; set; }

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
    /// ราคา หรือราคา On Peak
    /// </summary>
    public double Price { get; set; }

    /// <summary>
    /// ราคา Off Peak
    /// </summary>
    public double? Price2 { get; set; }

    /// <summary>
    /// ประเภทการคำนวณ 0 ต่อพลังงาน 1 ต่อชั่วโมง
    /// </summary>
    public int UnitType { get; set; }

    /// <summary>
    /// รูปแบบการคำนวน 0 Flat Rate 1 tou
    /// </summary>
    public int UnitPriceType { get; set; }

    /// <summary>
    /// รหัสใบกำกับภาษี
    /// </summary>
    public Guid? TaxInvoiceId { get; set; }

    /// <summary>
    /// รหัสข้อมูลผู้เสียภาษี
    /// </summary>
    public Guid? TaxpayerinfoId { get; set; }

    /// <summary>
    /// วิธีการชำระ เช่น qrcode creditcard อนุมัติโดยadmin
    /// </summary>
    public string? PaymentType { get; set; }

    /// <summary>
    /// ประเภทของkey 0=ใช้ผ่านแอพ, 1=rfid, 2=vid, 3=homeUse
    /// </summary>
    public string? UserKeyType { get; set; }

    /// <summary>
    /// รหัสผู้ใช้งาน
    /// </summary>
    public Guid? UserId { get; set; }

    /// <summary>
    /// รหัสการจอง
    /// </summary>
    public int? ChargerBookingId { get; set; }

    public virtual ICollection<ChargerApproveUsage> ChargerApproveUsages { get; set; } = new List<ChargerApproveUsage>();

    public virtual ChargerBooking? ChargerBooking { get; set; }
}
