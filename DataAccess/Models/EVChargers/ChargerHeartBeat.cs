using System;
using System.Collections.Generic;

namespace DataAccess.Models.EVChargers;

public partial class ChargerHeartBeat
{
    /// <summary>
    /// รหัสการทำงานของเครื่องชาร์จ
    /// </summary>
    public int ChargerHeartBeatId { get; set; }

    /// <summary>
    /// รหัสประจำตัวเครื่องชาร์จ
    /// </summary>
    public string? CpId { get; set; }

    /// <summary>
    /// หมายเลขประจำตัวเครื่องชาร์จ
    /// </summary>
    public string? CpCode { get; set; }

    /// <summary>
    /// เวลาการเชื่อมต่อ
    /// </summary>
    public DateTime? Heartbeat { get; set; }

    /// <summary>
    /// การเชื่อมต่อกับ csms
    /// </summary>
    public string? Connection { get; set; }

    /// <summary>
    /// หมายเลขหัวชาร์จ
    /// </summary>
    public int? CnNo { get; set; }

    /// <summary>
    /// สถานะของหัวชาร์จ
    /// </summary>
    public string? CnStatus { get; set; }

    /// <summary>
    /// การประทับเวลา
    /// </summary>
    public DateTime? Timestamp { get; set; }

    /// <summary>
    /// หมายเลขธุรกรรม
    /// </summary>
    public int? TransId { get; set; }

    /// <summary>
    /// หมายเลขการใช้งาน
    /// </summary>
    public string? TagId { get; set; }

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
    /// โวลต์
    /// </summary>
    public decimal? Voltage { get; set; }

    /// <summary>
    /// หน่วยของโวลต์
    /// </summary>
    public string? VoltageUnit { get; set; }

    /// <summary>
    /// กำลังไฟปัจจุบัน
    /// </summary>
    public decimal? CurrentImport { get; set; }

    /// <summary>
    /// หน่วยของกำลังไฟ
    /// </summary>
    public string? CurrentImportUnit { get; set; }

    /// <summary>
    /// อุณหภูมิ
    /// </summary>
    public decimal? Temp { get; set; }

    /// <summary>
    /// หน่วยอุณหภูมิ
    /// </summary>
    public string? TempUnit { get; set; }

    /// <summary>
    /// เปอร์เซ็นต์
    /// </summary>
    public decimal? BatteryPercent { get; set; }

    /// <summary>
    /// รหัสการของ
    /// </summary>
    public int? ChargerBookingId { get; set; }

    /// <summary>
    /// ค่าพลังงานที่ชาร์จ
    /// </summary>
    public decimal? PowerActive { get; set; }

    public virtual ChargerBooking? ChargerBooking { get; set; }
}
