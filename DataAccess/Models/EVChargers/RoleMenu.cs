using System;
using System.Collections.Generic;

namespace DataAccess.Models.EVChargers;

public partial class RoleMenu
{
    /// <summary>
    /// รหัสสิทธิ์กับเมนู
    /// </summary>
    public Guid RoleMenuId { get; set; }

    /// <summary>
    /// สถานะการดู
    /// </summary>
    public bool IsView { get; set; }

    /// <summary>
    /// สถานะการเพิ่ม
    /// </summary>
    public bool IsAdd { get; set; }

    /// <summary>
    /// สถานะการแก้ไข
    /// </summary>
    public bool IsEdit { get; set; }

    /// <summary>
    /// สถานะการลบ
    /// </summary>
    public bool IsDelete { get; set; }

    /// <summary>
    /// รหัสสิทธิ์
    /// </summary>
    public Guid RoleId { get; set; }

    /// <summary>
    /// รหัสเมนู
    /// </summary>
    public Guid MenuId { get; set; }

    public virtual Menu Menu { get; set; } = null!;

    public virtual Role Role { get; set; } = null!;
}
