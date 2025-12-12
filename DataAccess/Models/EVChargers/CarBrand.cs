using System;
using System.Collections.Generic;

namespace DataAccess.Models.EVChargers;

public partial class CarBrand
{
    /// <summary>
    /// รหัสยี้ห้อรถ
    /// </summary>
    public int CarBrandId { get; set; }

    /// <summary>
    /// ชื่อรุ่นรถ
    /// </summary>
    public string CarBrandName { get; set; } = null!;

    /// <summary>
    /// ชื่อยี้ห้อรถ
    /// </summary>
    public string Brand { get; set; } = null!;

    /// <summary>
    /// รุ่นรถ
    /// </summary>
    public string Model { get; set; } = null!;

    /// <summary>
    /// ความจุกิโลเมตร
    /// </summary>
    public double RangeKm { get; set; }

    /// <summary>
    /// ระยะกิโลวัตต์
    /// </summary>
    public double BatteryKwh { get; set; }

    /// <summary>
    /// จำนวนลิตรต่อกิโลเมตร
    /// </summary>
    public double LiteKm { get; set; }

    /// <summary>
    /// สถานะกราใช้งาน
    /// </summary>
    public bool CarBrandStatus { get; set; }
}
