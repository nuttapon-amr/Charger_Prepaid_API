using System;
using System.Collections.Generic;

namespace DataAccess.Models.EVChargers;

public partial class Faq
{
    public int FaqId { get; set; }

    /// <summary>
    /// ลำดับ
    /// </summary>
    public int FaqOrder { get; set; }

    /// <summary>
    /// คำภาม
    /// </summary>
    public string FaqQuestionsAnswersCategories { get; set; } = null!;

    /// <summary>
    /// คำตอบ
    /// </summary>
    public string FaqAnswers { get; set; } = null!;

    /// <summary>
    /// หมวดหมู่
    /// </summary>
    public string FaqCategories { get; set; } = null!;

    /// <summary>
    /// วันที่สร้าง
    /// </summary>
    public DateTime CreateDate { get; set; }

    /// <summary>
    /// สถานะการลบ
    /// </summary>
    public bool IsDelete { get; set; }
}
