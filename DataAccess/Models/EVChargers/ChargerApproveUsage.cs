using System;
using System.Collections.Generic;

namespace DataAccess.Models.EVChargers;

public partial class ChargerApproveUsage
{
    /// <summary>
    /// รหัสข้อมูลการอนุมิตการใช้
    /// </summary>
    public int ChargerApproveUsageId { get; set; }

    /// <summary>
    /// ข้อมูลการใช้งานที่อนุมัติ
    /// </summary>
    public int SummaryId { get; set; }

    /// <summary>
    /// รหัสบริษัทที่อนุมัติ
    /// </summary>
    public Guid CompanyId { get; set; }

    /// <summary>
    /// วันที่สร้าง
    /// </summary>
    public DateTime CreateDate { get; set; }

    /// <summary>
    /// ผู้สร้าง
    /// </summary>
    public Guid CreateBy { get; set; }

    /// <summary>
    /// สถานะการลบ
    /// </summary>
    public bool IsDelete { get; set; }

    public virtual ChargerSummary Summary { get; set; } = null!;
}
