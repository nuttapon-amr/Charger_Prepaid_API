using System;
using System.Collections.Generic;

namespace DataAccess.Models.EVChargers;

public partial class Role
{
    /// <summary>
    /// รหัสสิทธิ์
    /// </summary>
    public Guid RoleId { get; set; }

    /// <summary>
    /// ชื่อสิทธิ์
    /// </summary>
    public string RoleName { get; set; } = null!;

    /// <summary>
    /// รายละเอียด
    /// </summary>
    public string Description { get; set; } = null!;

    /// <summary>
    /// สถานะการใช้งาน
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// สถานะการเป็นแอดมิน
    /// </summary>
    public bool IsAdmin { get; set; }

    /// <summary>
    /// สถานะการเป็นแอดมินสูงสุด
    /// </summary>
    public bool IsSuperAdmin { get; set; }

    /// <summary>
    /// สถานะการเป็นโอเปเรเตอร์
    /// </summary>
    public bool IsOperator { get; set; }

    /// <summary>
    /// สถานะการเป็นบอร์ด
    /// </summary>
    public bool IsBoard { get; set; }

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public virtual ICollection<RoleMenu> RoleMenus { get; set; } = new List<RoleMenu>();
}
