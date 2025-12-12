using System;
using System.Collections.Generic;

namespace DataAccess.Models.EVChargers;

public partial class Notification
{
    /// <summary>
    /// รหัสการแจ้งเตือน
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// รหัสผู้ใช้งาน
    /// </summary>
    public Guid? UserId { get; set; }

    /// <summary>
    /// รหัสบริษัท
    /// </summary>
    public Guid? CompanyId { get; set; }

    /// <summary>
    /// รหัสสิทธิ์
    /// </summary>
    public Guid? RoleId { get; set; }

    /// <summary>
    /// สถานะการอ่าน
    /// </summary>
    public bool IsRead { get; set; }

    /// <summary>
    /// สถานะการใช้งาน
    /// </summary>
    public bool Status { get; set; }

    /// <summary>
    /// วันที่อัพเดท
    /// </summary>
    public DateTime UpdateDate { get; set; }

    /// <summary>
    /// รหัสข้อความ
    /// </summary>
    public Guid MessageId { get; set; }

    /// <summary>
    /// สถานะการส่ง
    /// </summary>
    public bool IsSend { get; set; }

    /// <summary>
    /// 0 เริ่มชาร์จสำเร็จ   1 หยุดชาร์จสำเร็จ     2 จองสำเร็จ.    3 ยกเลิกจองสำเร็จ.    4 ก่อนชาร์จเสร็จ 5 นาที.    5 ชาร์จครบเวลาที่จองแล้ว.      - 6 ถูกยกเลิกจองกรณีไม่มาในเวลาที่กำหนด.  7 เครื่องออฟไลน์.  8 เครื่องออนไลน์    - 9 รีบชำระเงินสำเร็จ  charger   - 10 เสร็จสิ้นการใช้งาน    - 11 การเปลี่ยนแปลงราคาเครื่องชาร์จ    - 12 การสั่ง restart    - 13 ตั้งค่า Set profile    14 ลบ user ในระบบ     - 15 รับชำระเงินสำเร็จ booking
    /// </summary>
    public int SendType { get; set; }

    /// <summary>
    /// ค่าสำหรับใช้งานการอ้างอิง ป้องกันการส่งซ้ำ
    /// </summary>
    public string? RefValue { get; set; }

    public virtual Company? Company { get; set; }

    public virtual Message Message { get; set; } = null!;

    public virtual Role? Role { get; set; }
}
