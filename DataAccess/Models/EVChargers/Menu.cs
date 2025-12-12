using System;
using System.Collections.Generic;

namespace DataAccess.Models.EVChargers;

public partial class Menu
{
    /// <summary>
    /// รหัสเมนู
    /// </summary>
    public Guid MenuId { get; set; }

    /// <summary>
    /// ชื่อเมนู
    /// </summary>
    public string MenuName { get; set; } = null!;

    /// <summary>
    /// ชื่อหัวข้อเมนู
    /// </summary>
    public string MenuTitle { get; set; } = null!;

    /// <summary>
    /// ตำแหน่ง path url
    /// </summary>
    public string MenuPathUrl { get; set; } = null!;

    /// <summary>
    /// ตำแหน่งของ icon
    /// </summary>
    public string MenuPathIcon { get; set; } = null!;

    /// <summary>
    /// ลำดับเมนู
    /// </summary>
    public int OrderNumber { get; set; }

    /// <summary>
    /// สถานะการเป็นเมนู
    /// </summary>
    public bool IsMenu { get; set; }

    /// <summary>
    /// สถานะการลบ
    /// </summary>
    public bool IsDelete { get; set; }

    public virtual ICollection<RoleMenu> RoleMenus { get; set; } = new List<RoleMenu>();
}
