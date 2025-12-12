using System;
using System.Collections.Generic;

namespace DataAccess.Models.EVChargers;

public partial class CompanyStation
{
    /// <summary>
    /// รหัสบริษัทกับสถานี
    /// </summary>
    public Guid CompanyStationId { get; set; }

    /// <summary>
    /// รหัสบริษัท
    /// </summary>
    public Guid CompanyId { get; set; }

    /// <summary>
    /// รหัสถานี
    /// </summary>
    public int StationId { get; set; }

    /// <summary>
    /// เวลาเปิดสถานี
    /// </summary>
    public string TimeOpen { get; set; } = null!;

    /// <summary>
    /// วันที่สร้าง
    /// </summary>
    public DateTime CreateDate { get; set; }

    /// <summary>
    /// สร้างโดย
    /// </summary>
    public Guid? CreateBy { get; set; }

    /// <summary>
    /// สถานะการลบ
    /// </summary>
    public bool IsDelete { get; set; }

    /// <summary>
    /// ลบโดย
    /// </summary>
    public Guid? DeleteBy { get; set; }

    /// <summary>
    /// ลบวันที่
    /// </summary>
    public DateTime? DeleteDate { get; set; }

    /// <summary>
    /// สถานะการเป็นสถานีแบบปิด
    /// </summary>
    public bool IsPrivateStation { get; set; }

    public virtual Company Company { get; set; } = null!;

    public virtual Station Station { get; set; } = null!;
}
