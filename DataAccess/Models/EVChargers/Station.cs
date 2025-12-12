using System;
using System.Collections.Generic;

namespace DataAccess.Models.EVChargers;

public partial class Station
{
    /// <summary>
    /// รหัสถานี
    /// </summary>
    public int StationId { get; set; }

    /// <summary>
    /// รหัสอ้างอิงสถานี
    /// </summary>
    public string StCode { get; set; } = null!;

    /// <summary>
    /// ชื่อสถานีภาษาไทย
    /// </summary>
    public string? StationNameTh { get; set; }

    /// <summary>
    /// ชื่อสถานีภาษาอังกฤษ
    /// </summary>
    public string? StationNameEn { get; set; }

    /// <summary>
    /// ที่อยู่ภาษาไทย
    /// </summary>
    public string? StationAddressTh { get; set; }

    /// <summary>
    /// ที่อยู่ภาษาอังกฤษ
    /// </summary>
    public string? StationAddressEn { get; set; }

    /// <summary>
    /// ละติจูด
    /// </summary>
    public string StationLatitude { get; set; } = null!;

    /// <summary>
    /// ลองจิจูด
    /// </summary>
    public string StationLongitude { get; set; } = null!;

    /// <summary>
    /// สถานะการเปิดปิดการใช้งานสถานี
    /// </summary>
    public bool StationStatus { get; set; }

    /// <summary>
    /// สถานะการลบ
    /// </summary>
    public bool IsDelete { get; set; }

    /// <summary>
    /// ลบโดย
    /// </summary>
    public int? DeleteBy { get; set; }

    /// <summary>
    /// ลบวันที่
    /// </summary>
    public DateTime? DeleteDate { get; set; }

    public virtual ICollection<CompanyStation> CompanyStations { get; set; } = new List<CompanyStation>();
}
