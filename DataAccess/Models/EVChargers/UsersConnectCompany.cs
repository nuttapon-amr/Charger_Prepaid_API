using System;
using System.Collections.Generic;

namespace DataAccess.Models.EVChargers;

public partial class UsersConnectCompany
{
    /// <summary>
    /// รหัสการเชื่อมต่อ
    /// </summary>
    public Guid UsersConnectCompanyId { get; set; }

    /// <summary>
    /// รหัสบริษัท
    /// </summary>
    public Guid CompanyId { get; set; }

    /// <summary>
    /// รหัสผู้ใช้งาน
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// วันที่หมดอายุ ถ้าไม่มีค่าหมายถึงไม่มีวันหมดอายุ
    /// </summary>
    public DateTime? ExpirationDate { get; set; }

    /// <summary>
    /// วันที่สร้าง
    /// </summary>
    public DateTime CreateDate { get; set; }

    /// <summary>
    /// ผู้สร้าง
    /// </summary>
    public Guid CreateBy { get; set; }

    /// <summary>
    /// วันที่ปรับปรุง
    /// </summary>
    public DateTime UpdateDate { get; set; }

    /// <summary>
    /// ผู้ปรังปรุง
    /// </summary>
    public Guid UpdateBy { get; set; }

    /// <summary>
    /// สถานะการลบ
    /// </summary>
    public bool IsDelete { get; set; }

    /// <summary>
    /// วันที่ลบ
    /// </summary>
    public DateTime? DeleteDate { get; set; }

    /// <summary>
    /// สถานะการอนุญิต
    /// </summary>
    public bool IsApprove { get; set; }
}
