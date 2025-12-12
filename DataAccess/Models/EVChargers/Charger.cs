using System;
using System.Collections.Generic;

namespace DataAccess.Models.EVChargers;

public partial class Charger
{
    /// <summary>
    /// รหัสเครื่องชาร์จ
    /// </summary>
    public int ChargerId { get; set; }

    /// <summary>
    /// ชื่อเครื่องชาร์จ
    /// </summary>
    public string? ChargerName { get; set; }

    /// <summary>
    /// รหัสประจำตัวเครื่องชาร์จ
    /// </summary>
    public string? CpId { get; set; }

    /// <summary>
    /// หมายเลขประจำตัวเครื่องชาร์จ
    /// </summary>
    public string? CpCode { get; set; }

    /// <summary>
    /// หมายเลขรุ่น
    /// </summary>
    public string? ModelNumber { get; set; }

    /// <summary>
    /// หมายเลขซีเรียล
    /// </summary>
    public string? SerialNumber { get; set; }

    /// <summary>
    /// วันที่ิติดตั้ง
    /// </summary>
    public DateTime? InstallationDate { get; set; }

    /// <summary>
    /// วันที่ฮาร์ดแวร์การรับประกัน
    /// </summary>
    public DateTime? WarrantyHardwareDate { get; set; }

    /// <summary>
    /// วันที่ให้บริการการรับประกัน
    /// </summary>
    public DateTime? WarrantyServiceDate { get; set; }

    /// <summary>
    /// หมายกล่อง
    /// </summary>
    public string? BoxSerialNo { get; set; }

    /// <summary>
    /// ยี้ห้อเครื่องชาร์จ
    /// </summary>
    public string? Vendor { get; set; }

    /// <summary>
    /// เฟิร์มแวร์
    /// </summary>
    public string? Firmware { get; set; }

    /// <summary>
    /// หมายเลขมิเตอร์
    /// </summary>
    public string? MeterSerial { get; set; }

    /// <summary>
    /// ประเภทมิเตอร์
    /// </summary>
    public string? MeterType { get; set; }

    /// <summary>
    /// เวลาการเชื่อมต่อ
    /// </summary>
    public DateTime? Heartbeat { get; set; }

    /// <summary>
    /// การเชื่อมต่อกับ csms
    /// </summary>
    public string? Connection { get; set; }

    /// <summary>
    /// รหัสถานีจาก CSMS
    /// </summary>
    public string? StCode { get; set; }

    /// <summary>
    /// วันที่ลบ
    /// </summary>
    public DateTime? DeleteDate { get; set; }

    /// <summary>
    /// สถานะการลบ
    /// </summary>
    public bool? IsDelete { get; set; }

    /// <summary>
    /// สถานะการใช้งาน
    /// </summary>
    public bool? Status { get; set; }

    /// <summary>
    /// หมายเลขโปรไฟล์
    /// </summary>
    public int? ProfileNumber { get; set; }

    /// <summary>
    /// เปอร์เซ็นการชาร์จ
    /// </summary>
    public int? LoadBalance { get; set; }

    /// <summary>
    /// ประเภทเครื่องชาร์จ
    /// </summary>
    public int? ChargerTypeId { get; set; }

    /// <summary>
    /// ค่าพลังงานสูงสุด
    /// </summary>
    public int MaxPower { get; set; }

    /// <summary>
    /// ค่าพลังงานที่กำหนด
    /// </summary>
    public int SetPower { get; set; }

    /// <summary>
    /// สถานะการตั้งค่าอัตโนมัติของการตั้งค่าการใช้พลังงาน
    /// </summary>
    public bool IsAuto { get; set; }

    /// <summary>
    /// ประเภทของเครื่องชาร์จ 0 = สถานี 1 = ใช้ในบ้าน
    /// </summary>
    public int Type { get; set; }

    /// <summary>
    /// สถานะของการเริ่มชาร์จเมื่อทำการเชื่อมต่อหัวชาร์จ
    /// </summary>
    public bool IsPlugAndCharge { get; set; }

    public virtual ICollection<ChargePoint> ChargePoints { get; set; } = new List<ChargePoint>();

    public virtual ICollection<ChargerUser> ChargerUsers { get; set; } = new List<ChargerUser>();
}
