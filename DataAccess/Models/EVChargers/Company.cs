using System;
using System.Collections.Generic;

namespace DataAccess.Models.EVChargers;

public partial class Company
{
    /// <summary>
    /// รหัสบริษัท
    /// </summary>
    public Guid CompanyId { get; set; }

    /// <summary>
    /// ชื่อบริษัท
    /// </summary>
    public string CompanyName { get; set; } = null!;

    /// <summary>
    /// สาขา
    /// </summary>
    public string Branch { get; set; } = null!;

    /// <summary>
    /// อีเมล
    /// </summary>
    public string Email { get; set; } = null!;

    /// <summary>
    /// เบอร์โทร
    /// </summary>
    public string Phonenumber { get; set; } = null!;

    /// <summary>
    /// สถานะการลบ
    /// </summary>
    public bool IsDelete { get; set; }

    /// <summary>
    /// ลบโดย
    /// </summary>
    public Guid? DeleteBy { get; set; }

    /// <summary>
    /// วันที่ลบ
    /// </summary>
    public DateTime? DeleteDate { get; set; }

    /// <summary>
    /// สถานะการใช้งาน
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// เลขผู้เสียภาษี
    /// </summary>
    public string TaxIdCard { get; set; } = null!;

    /// <summary>
    /// ที่อยู่
    /// </summary>
    public string Address { get; set; } = null!;

    /// <summary>
    /// วันที่สร้าง
    /// </summary>
    public DateTime CreateDate { get; set; }

    /// <summary>
    /// สร้างโดย
    /// </summary>
    public Guid? CreateBy { get; set; }

    /// <summary>
    /// วันที่อัพเดท
    /// </summary>
    public DateTime? UpdateDate { get; set; }

    /// <summary>
    /// อัพเดทโดย
    /// </summary>
    public Guid? UpdateBy { get; set; }

    /// <summary>
    /// รหัสตำบล
    /// </summary>
    public string SubDistrictId { get; set; } = null!;

    /// <summary>
    /// ชื่อกลุ่ม
    /// </summary>
    public string GroupName { get; set; } = null!;

    /// <summary>
    /// อัตราค่าธรรมเนียมร้อยละ
    /// </summary>
    public double PercentageFeeRate { get; set; }

    /// <summary>
    /// ประเภทของบริษัท 1=มีการชำระเงินผ่านแอพsmartEz 2=ชำระเงินภายนอกไม่ใช้แอพsmartEz 3=ไม่มีเรื่องเกี่ยวกับเงิน
    /// </summary>
    public string CompanyType { get; set; } = null!;

    /// <summary>
    /// อ้างอิงรหัสการชำระของ payment gateway
    /// </summary>
    public string PaymentCode { get; set; } = null!;

    public virtual ICollection<CompanyStation> CompanyStations { get; set; } = new List<CompanyStation>();

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();
}
