using System;
using System.Collections.Generic;

namespace DataAccess.Models.EVChargers;

public partial class UnitPrice
{
    /// <summary>
    /// รหัสราคา
    /// </summary>
    public Guid UnitPriceId { get; set; }

    /// <summary>
    /// ราคา หรือราคา On Peak
    /// </summary>
    public double Price { get; set; }

    /// <summary>
    /// ราคา Off Peak
    /// </summary>
    public double? Price2 { get; set; }

    /// <summary>
    /// รหัสหัวชาร์จ
    /// </summary>
    public Guid? ChargePointId { get; set; }

    /// <summary>
    /// ประเภทการคำนวณ 0 ต่อพลังงาน 1 ต่อชั่วโมง
    /// </summary>
    public int UnitType { get; set; }

    /// <summary>
    /// รูปแบบการคำนวน 0 Flat Rate 1 tou
    /// </summary>
    public int UnitPriceType { get; set; }

    /// <summary>
    /// วันที่สร้าง
    /// </summary>
    public DateTime CreateDate { get; set; }

    /// <summary>
    /// สถานะการลบ
    /// </summary>
    public bool IsDelete { get; set; }

    public virtual ChargePoint? ChargePoint { get; set; }
}
