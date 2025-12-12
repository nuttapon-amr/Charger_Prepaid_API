using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace DataAccess.Models.EVChargers;

public partial class EvchargersContext : DbContext
{
    public EvchargersContext()
    {
    }

    public EvchargersContext(DbContextOptions<EvchargersContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ApplicationClosed> ApplicationCloseds { get; set; }

    public virtual DbSet<ApplicationVersion> ApplicationVersions { get; set; }

    public virtual DbSet<Banner> Banners { get; set; }

    public virtual DbSet<BookingTimeSlot> BookingTimeSlots { get; set; }

    public virtual DbSet<CarBrand> CarBrands { get; set; }

    public virtual DbSet<ChargePoint> ChargePoints { get; set; }

    public virtual DbSet<Charger> Chargers { get; set; }

    public virtual DbSet<ChargerApproveUsage> ChargerApproveUsages { get; set; }

    public virtual DbSet<ChargerBooking> ChargerBookings { get; set; }

    public virtual DbSet<ChargerCmd> ChargerCmds { get; set; }

    public virtual DbSet<ChargerHeartBeat> ChargerHeartBeats { get; set; }

    public virtual DbSet<ChargerPurchase> ChargerPurchases { get; set; }

    public virtual DbSet<ChargerSummary> ChargerSummaries { get; set; }

    public virtual DbSet<ChargerUser> ChargerUsers { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<CompanyStation> CompanyStations { get; set; }

    public virtual DbSet<Faq> Faqs { get; set; }

    public virtual DbSet<Fcm> Fcms { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<Message> Messages { get; set; }

    public virtual DbSet<News> News { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<PrePaidToken> PrePaidTokens { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<RoleMenu> RoleMenus { get; set; }

    public virtual DbSet<Station> Stations { get; set; }

    public virtual DbSet<TemplateProfilePower> TemplateProfilePowers { get; set; }

    public virtual DbSet<UnitPrice> UnitPrices { get; set; }

    public virtual DbSet<UnitPriceSchedule> UnitPriceSchedules { get; set; }

    public virtual DbSet<UserKey> UserKeys { get; set; }

    public virtual DbSet<UsersConnectCompany> UsersConnectCompanies { get; set; }
 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<ApplicationClosed>(entity =>
        {
            entity.HasKey(e => e.ApplicationClosedId).HasName("PRIMARY");

            entity.ToTable("ApplicationClosed");

            entity.Property(e => e.ApplicationClosedId).HasComment("ลำดับการปิดแอปพลิเคชั่น");
            entity.Property(e => e.CreateDate)
                .HasComment("วันที่สร้าง")
                .HasColumnType("datetime");
            entity.Property(e => e.EndDate)
                .HasComment("วันที่สิ้นสุดการปิดการใช้งาน")
                .HasColumnType("datetime");
            entity.Property(e => e.FunctionName)
                .HasMaxLength(255)
                .HasComment("ชื่อฟังก์ชั่น");
            entity.Property(e => e.IsDelete).HasComment("สถานะการลบ");
            entity.Property(e => e.StartDate)
                .HasComment("วันที่ปิดการใช้งาน")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<ApplicationVersion>(entity =>
        {
            entity.HasKey(e => e.ApplicationVersionId).HasName("PRIMARY");

            entity.ToTable("ApplicationVersion");

            entity.Property(e => e.ApplicationVersionId).HasComment("ลำดับเวอร์ชั่นแอปพลิเคชั่น");
            entity.Property(e => e.CreateDate)
                .HasComment("วันที่สร้าง")
                .HasColumnType("datetime");
            entity.Property(e => e.IsDelete).HasComment("สถานะการลบ");
            entity.Property(e => e.VersionNumber)
                .HasMaxLength(255)
                .HasComment("หมายเลขเวอร์ชั่น");
        });

        modelBuilder.Entity<Banner>(entity =>
        {
            entity.HasKey(e => e.BannerId).HasName("PRIMARY");

            entity
                .ToTable("Banner")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.BannerId).HasComment("รหัสแบนเนอร์");
            entity.Property(e => e.ClickLink)
                .HasComment("ลิงค์เว็บไซต์")
                .HasColumnType("text");
            entity.Property(e => e.FileId).HasComment("รหัสไฟล์");
            entity.Property(e => e.IsShow).HasComment("สถานะการแสดง");
            entity.Property(e => e.TypeName)
                .HasMaxLength(100)
                .HasComment("ชื่อประเภท");
        });

        modelBuilder.Entity<BookingTimeSlot>(entity =>
        {
            entity.HasKey(e => e.BookingTimeSlotId).HasName("PRIMARY");

            entity.ToTable("BookingTimeSlot");

            entity.HasIndex(e => e.ChargePointId, "ChargePointId");

            entity.Property(e => e.BookingTimeSlotId)
                .HasComment("รหัสข้อมูล")
                .UseCollation("utf8mb4_unicode_ci");
            entity.Property(e => e.BookingTimeSlotMinute)
                .HasMaxLength(20)
                .HasComment("ช่วงเวลาของช่องslot หน่วยนาที")
                .UseCollation("utf8mb4_unicode_ci");
            entity.Property(e => e.ChargePointId)
                .HasComment("รหัสหัวชาร์จ")
                .UseCollation("utf8mb3_unicode_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.CreateBy).HasComment("สร้างโดย");
            entity.Property(e => e.CreateDate)
                .HasComment("วันที่สร้าง")
                .HasColumnType("datetime");
            entity.Property(e => e.SlotPrice)
                .HasComment("ราคาต่อ slot")
                .HasColumnType("double(10,2)");
            entity.Property(e => e.UpdateBy)
                .HasComment("รหัสผู้ปรับปรุงข้อมูล")
                .UseCollation("utf8mb4_unicode_ci");
            entity.Property(e => e.UpdateDate)
                .HasComment("วันที่ปรับปรุงข้อมูล")
                .HasColumnType("datetime");

            entity.HasOne(d => d.ChargePoint).WithMany(p => p.BookingTimeSlots)
                .HasForeignKey(d => d.ChargePointId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("BookingTimeSlot_ibfk_1");
        });

        modelBuilder.Entity<CarBrand>(entity =>
        {
            entity.HasKey(e => e.CarBrandId).HasName("PRIMARY");

            entity
                .ToTable("CarBrand")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_unicode_ci");

            entity.Property(e => e.CarBrandId).HasComment("รหัสยี้ห้อรถ");
            entity.Property(e => e.BatteryKwh)
                .HasComment("ระยะกิโลวัตต์")
                .HasColumnType("double(10,2)");
            entity.Property(e => e.Brand)
                .HasMaxLength(255)
                .HasComment("ชื่อยี้ห้อรถ");
            entity.Property(e => e.CarBrandName)
                .HasMaxLength(255)
                .HasComment("ชื่อรุ่นรถ");
            entity.Property(e => e.CarBrandStatus).HasComment("สถานะกราใช้งาน");
            entity.Property(e => e.LiteKm)
                .HasComment("จำนวนลิตรต่อกิโลเมตร")
                .HasColumnType("double(12,8)");
            entity.Property(e => e.Model)
                .HasMaxLength(255)
                .HasComment("รุ่นรถ");
            entity.Property(e => e.RangeKm)
                .HasComment("ความจุกิโลเมตร")
                .HasColumnType("double(10,2)");
        });

        modelBuilder.Entity<ChargePoint>(entity =>
        {
            entity.HasKey(e => e.ChargePointId).HasName("PRIMARY");

            entity
                .ToTable("ChargePoint")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_unicode_ci");

            entity.HasIndex(e => e.ChargerId, "ChargerId");

            entity.Property(e => e.ChargePointId).HasComment("รหัสหัสชาร์จ");
            entity.Property(e => e.ChargerId).HasComment("รหัสชาร์จเจอร์");
            entity.Property(e => e.ChargerPointType)
                .HasMaxLength(255)
                .HasComment("ประเภทหัวชาร์จ");
            entity.Property(e => e.CnNo).HasComment("หมายเลขหัวชาร์จ");
            entity.Property(e => e.Connection)
                .HasMaxLength(255)
                .HasComment("สถานะการเชื่อมต่อ");
            entity.Property(e => e.DeleteDate)
                .HasComment("วันที่ลบ")
                .HasColumnType("datetime");
            entity.Property(e => e.IsAuto).HasComment("สถานะการตั้งค่าอัตโนมัติ");
            entity.Property(e => e.IsDelete).HasComment("สถานะการลบ");
            entity.Property(e => e.IsWalkIn).HasComment("สถานะการจอง 0=ต้องจองก่อน 1= ไม่ต้องจองก่อน");
            entity.Property(e => e.MaxPower).HasComment("ค่าพลังงานสูงสุด");
            entity.Property(e => e.SetPower).HasComment("ค่าพลังงานที่กำหนด");
            entity.Property(e => e.Status).HasComment("สถานะการใช้งาน");

            entity.HasOne(d => d.Charger).WithMany(p => p.ChargePoints)
                .HasForeignKey(d => d.ChargerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ChargePoint_ibfk_1");
        });

        modelBuilder.Entity<Charger>(entity =>
        {
            entity.HasKey(e => e.ChargerId).HasName("PRIMARY");

            entity
                .ToTable("Charger")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_unicode_ci");

            entity.Property(e => e.ChargerId).HasComment("รหัสเครื่องชาร์จ");
            entity.Property(e => e.BoxSerialNo)
                .HasMaxLength(255)
                .HasComment("หมายกล่อง");
            entity.Property(e => e.ChargerName)
                .HasMaxLength(255)
                .HasComment("ชื่อเครื่องชาร์จ");
            entity.Property(e => e.ChargerTypeId).HasComment("ประเภทเครื่องชาร์จ");
            entity.Property(e => e.Connection)
                .HasMaxLength(255)
                .HasComment("การเชื่อมต่อกับ csms");
            entity.Property(e => e.CpCode)
                .HasMaxLength(255)
                .HasComment("หมายเลขประจำตัวเครื่องชาร์จ");
            entity.Property(e => e.CpId)
                .HasMaxLength(255)
                .HasComment("รหัสประจำตัวเครื่องชาร์จ");
            entity.Property(e => e.DeleteDate)
                .HasComment("วันที่ลบ")
                .HasColumnType("datetime");
            entity.Property(e => e.Firmware)
                .HasMaxLength(255)
                .HasComment("เฟิร์มแวร์");
            entity.Property(e => e.Heartbeat)
                .HasComment("เวลาการเชื่อมต่อ")
                .HasColumnType("datetime");
            entity.Property(e => e.InstallationDate)
                .HasComment("วันที่ิติดตั้ง")
                .HasColumnType("datetime");
            entity.Property(e => e.IsAuto).HasComment("สถานะการตั้งค่าอัตโนมัติของการตั้งค่าการใช้พลังงาน");
            entity.Property(e => e.IsDelete).HasComment("สถานะการลบ");
            entity.Property(e => e.IsPlugAndCharge).HasComment("สถานะของการเริ่มชาร์จเมื่อทำการเชื่อมต่อหัวชาร์จ");
            entity.Property(e => e.LoadBalance).HasComment("เปอร์เซ็นการชาร์จ");
            entity.Property(e => e.MaxPower).HasComment("ค่าพลังงานสูงสุด");
            entity.Property(e => e.MeterSerial)
                .HasMaxLength(255)
                .HasComment("หมายเลขมิเตอร์");
            entity.Property(e => e.MeterType)
                .HasMaxLength(255)
                .HasComment("ประเภทมิเตอร์");
            entity.Property(e => e.ModelNumber)
                .HasMaxLength(255)
                .HasComment("หมายเลขรุ่น");
            entity.Property(e => e.ProfileNumber)
                .HasComment("หมายเลขโปรไฟล์")
                .HasColumnName("profileNumber");
            entity.Property(e => e.SerialNumber)
                .HasMaxLength(255)
                .HasComment("หมายเลขซีเรียล");
            entity.Property(e => e.SetPower).HasComment("ค่าพลังงานที่กำหนด");
            entity.Property(e => e.StCode)
                .HasMaxLength(255)
                .HasComment("รหัสถานีจาก CSMS")
                .HasColumnName("stCode")
                .UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.Status).HasComment("สถานะการใช้งาน");
            entity.Property(e => e.Type).HasComment("ประเภทของเครื่องชาร์จ 0 = สถานี 1 = ใช้ในบ้าน");
            entity.Property(e => e.Vendor)
                .HasMaxLength(255)
                .HasComment("ยี้ห้อเครื่องชาร์จ");
            entity.Property(e => e.WarrantyHardwareDate)
                .HasComment("วันที่ฮาร์ดแวร์การรับประกัน")
                .HasColumnType("datetime");
            entity.Property(e => e.WarrantyServiceDate)
                .HasComment("วันที่ให้บริการการรับประกัน")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<ChargerApproveUsage>(entity =>
        {
            entity.HasKey(e => e.ChargerApproveUsageId).HasName("PRIMARY");

            entity.ToTable("ChargerApproveUsage");

            entity.HasIndex(e => e.SummaryId, "SummaryId");

            entity.Property(e => e.ChargerApproveUsageId).HasComment("รหัสข้อมูลการอนุมิตการใช้");
            entity.Property(e => e.CompanyId)
                .HasComment("รหัสบริษัทที่อนุมัติ")
                .UseCollation("utf8mb4_unicode_ci");
            entity.Property(e => e.CreateBy).HasComment("ผู้สร้าง");
            entity.Property(e => e.CreateDate)
                .HasComment("วันที่สร้าง")
                .HasColumnType("datetime");
            entity.Property(e => e.IsDelete).HasComment("สถานะการลบ");
            entity.Property(e => e.SummaryId).HasComment("ข้อมูลการใช้งานที่อนุมัติ");

            entity.HasOne(d => d.Summary).WithMany(p => p.ChargerApproveUsages)
                .HasForeignKey(d => d.SummaryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ChargerApproveUsage_ibfk_1");
        });

        modelBuilder.Entity<ChargerBooking>(entity =>
        {
            entity.HasKey(e => e.ChargerBookingId).HasName("PRIMARY");

            entity
                .ToTable("ChargerBooking")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_unicode_ci");

            entity.HasIndex(e => e.ChargePointId, "ChargePointId");

            entity.Property(e => e.ChargerBookingId).HasComment("รหัสการจอง");
            entity.Property(e => e.Amount)
                .HasPrecision(10, 2)
                .HasComment("จำนวนเงิน");
            entity.Property(e => e.BookingTimeSlotMinute)
                .HasMaxLength(20)
                .HasComment("ช่วงเวลาของช่องslot หน่วยนาที")
                .UseCollation("utf8mb4_unicode_ci")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.CancelBy)
                .HasComment("ยกเลิกโดย")
                .UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.CancelDate)
                .HasComment("วันที่ยกเลิก")
                .HasColumnType("datetime");
            entity.Property(e => e.CancelReason)
                .HasMaxLength(255)
                .HasComment("เหตุผลการยกเลิกการจอง");
            entity.Property(e => e.CancelReasonType).HasComment("ประเภทการยกเลิก 0=user ยกเลิก 1=มาไม่ทันกำหนดเวลา 2=ผู้ดูแลยกเลิก");
            entity.Property(e => e.ChargePointId).HasComment("รหัสหัวชาร์จ");
            entity.Property(e => e.CreateDate)
                .HasComment("วันที่สร้าง")
                .HasColumnType("datetime");
            entity.Property(e => e.EndDate)
                .HasComment("ช่วงเวลาสิ้นสุดการชาร์จ")
                .HasColumnType("datetime");
            entity.Property(e => e.Fee)
                .HasPrecision(10, 2)
                .HasComment("ค่าบริการ");
            entity.Property(e => e.IsCancel).HasComment("สถานะการยกเลิก");
            entity.Property(e => e.IsPaid).HasComment("สถานะการชำระ");
            entity.Property(e => e.Net)
                .HasPrecision(10, 2)
                .HasComment("สุทธิ");
            entity.Property(e => e.PaidDate)
                .HasComment("วันที่ชำระ")
                .HasColumnType("datetime");
            entity.Property(e => e.PercentageFeeRate)
                .HasComment("อัตราค่าธรรมเนียมร้อยละ")
                .HasColumnType("double(6,2)");
            entity.Property(e => e.Price)
                .HasComment("ราคา")
                .HasColumnType("double(10,2)");
            entity.Property(e => e.StartDate)
                .HasComment("ช่วงเวลาที่เริ่มจองและชาร์จ")
                .HasColumnType("datetime");
            entity.Property(e => e.Status).HasComment("สถานะการจอง 0=กำลังจอง 1=จองเรียบร้อย 2=เลิกจอง 3=ใช้งานเสร็จ");
            entity.Property(e => e.TaxInvoiceId).HasComment("รหัสใบกำกับภาษี");
            entity.Property(e => e.TaxpayerinfoId)
                .HasComment("รหัสข้อมูลผู้เสียภาษี")
                .UseCollation("utf8mb4_unicode_ci")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.TotalSlot).HasComment("จำนวน block ที่จอง");
            entity.Property(e => e.UserId).HasComment("รหัสผู้ใช้งาน");

            entity.HasOne(d => d.ChargePoint).WithMany(p => p.ChargerBookings)
                .HasForeignKey(d => d.ChargePointId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ChargerBooking_ibfk_1");
        });

        modelBuilder.Entity<ChargerCmd>(entity =>
        {
            entity.HasKey(e => e.ChargerCmdId).HasName("PRIMARY");

            entity
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_unicode_ci");

            entity.Property(e => e.ChargerCmdId).HasComment("รหัสคำสั่ง");
            entity.Property(e => e.ChargerCmdCreateDate)
                .HasComment("วันที่สร้าง")
                .HasColumnType("datetime");
            entity.Property(e => e.ChargerCmdMessage)
                .HasComment("ข้อความคำสั่ง")
                .HasColumnType("text");
            entity.Property(e => e.ChargerCmdStatus).HasComment("สถานะการส่งคำสั่ง");
            entity.Property(e => e.UserId).HasComment("รหัสผู้ใช้งาน ผู้ส่งคำสั่ง");
        });

        modelBuilder.Entity<ChargerHeartBeat>(entity =>
        {
            entity.HasKey(e => e.ChargerHeartBeatId).HasName("PRIMARY");

            entity
                .ToTable("ChargerHeartBeat")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_unicode_ci");

            entity.HasIndex(e => e.ChargerBookingId, "ChargerBookingId");

            entity.Property(e => e.ChargerHeartBeatId).HasComment("รหัสการทำงานของเครื่องชาร์จ");
            entity.Property(e => e.BatteryPercent)
                .HasPrecision(7, 3)
                .HasComment("เปอร์เซ็นต์");
            entity.Property(e => e.ChargerBookingId).HasComment("รหัสการของ");
            entity.Property(e => e.CnNo)
                .HasComment("หมายเลขหัวชาร์จ")
                .HasColumnName("cnNo");
            entity.Property(e => e.CnStatus)
                .HasMaxLength(255)
                .HasComment("สถานะของหัวชาร์จ")
                .HasColumnName("cnStatus");
            entity.Property(e => e.Connection)
                .HasMaxLength(255)
                .HasComment("การเชื่อมต่อกับ csms")
                .HasColumnName("connection");
            entity.Property(e => e.CpCode)
                .HasMaxLength(255)
                .HasComment("หมายเลขประจำตัวเครื่องชาร์จ")
                .HasColumnName("cpCode");
            entity.Property(e => e.CpId)
                .HasMaxLength(255)
                .HasComment("รหัสประจำตัวเครื่องชาร์จ")
                .HasColumnName("cpId");
            entity.Property(e => e.CurrentImport)
                .HasPrecision(7, 3)
                .HasComment("กำลังไฟปัจจุบัน")
                .HasColumnName("currentImport");
            entity.Property(e => e.CurrentImportUnit)
                .HasMaxLength(255)
                .HasComment("หน่วยของกำลังไฟ")
                .HasColumnName("currentImportUnit");
            entity.Property(e => e.Heartbeat)
                .HasComment("เวลาการเชื่อมต่อ")
                .HasColumnType("datetime")
                .HasColumnName("heartbeat");
            entity.Property(e => e.MeterStart)
                .HasComment("มิเตอร์เริ่มต้น")
                .HasColumnType("double(10,3)")
                .HasColumnName("meterStart");
            entity.Property(e => e.MeterUpdate)
                .HasComment("มิเตอร์สินสุด")
                .HasColumnType("double(10,3)")
                .HasColumnName("meterUpdate");
            entity.Property(e => e.PowerActive)
                .HasPrecision(10, 3)
                .HasComment("ค่าพลังงานที่ชาร์จ")
                .HasColumnName("powerActive");
            entity.Property(e => e.TagId)
                .HasMaxLength(255)
                .HasComment("หมายเลขการใช้งาน")
                .HasColumnName("tagId");
            entity.Property(e => e.Temp)
                .HasPrecision(7, 3)
                .HasComment("อุณหภูมิ")
                .HasColumnName("temp");
            entity.Property(e => e.TempUnit)
                .HasMaxLength(255)
                .HasComment("หน่วยอุณหภูมิ")
                .HasColumnName("tempUnit");
            entity.Property(e => e.Timestamp)
                .HasComment("การประทับเวลา")
                .HasColumnType("datetime")
                .HasColumnName("timestamp");
            entity.Property(e => e.TransId)
                .HasComment("หมายเลขธุรกรรม")
                .HasColumnName("transId");
            entity.Property(e => e.TransStart)
                .HasComment("การเริ่มต้นการใช้งาน")
                .HasColumnType("datetime")
                .HasColumnName("transStart");
            entity.Property(e => e.TransUpdate)
                .HasComment("การสิ้นสุดการใช้งาน")
                .HasColumnType("datetime")
                .HasColumnName("transUpdate");
            entity.Property(e => e.Voltage)
                .HasPrecision(7, 3)
                .HasComment("โวลต์")
                .HasColumnName("voltage");
            entity.Property(e => e.VoltageUnit)
                .HasMaxLength(255)
                .HasComment("หน่วยของโวลต์")
                .HasColumnName("voltageUnit");

            entity.HasOne(d => d.ChargerBooking).WithMany(p => p.ChargerHeartBeats)
                .HasForeignKey(d => d.ChargerBookingId)
                .HasConstraintName("ChargerHeartBeat_ibfk_1");
        });

        modelBuilder.Entity<ChargerPurchase>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PRIMARY");

            entity
                .ToTable("ChargerPurchase")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.ChargePointId, "ChargePointId");

            entity.HasIndex(e => e.UserId, "UserId");

            entity.Property(e => e.PaymentId).HasComment("รหัสการชำระเงิน");
            entity.Property(e => e.Amount)
                .HasPrecision(10, 2)
                .HasComment("จำนวนเงิน");
            entity.Property(e => e.ChargePointId)
                .HasComment("รหัสหัวชาร์จ")
                .UseCollation("utf8mb3_unicode_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.ChargerBookingId).HasComment("รหัสการจอง");
            entity.Property(e => e.CreateDate)
                .HasComment("วันที่สร้าง")
                .HasColumnType("datetime");
            entity.Property(e => e.Fee)
                .HasPrecision(10, 2)
                .HasComment("ค่าบริการ");
            entity.Property(e => e.IsDelete).HasComment("สถานะการลบ");
            entity.Property(e => e.IsPaid).HasComment("สถานะการชำระเงิน");
            entity.Property(e => e.Net)
                .HasPrecision(10, 2)
                .HasComment("สุทธิ");
            entity.Property(e => e.PaidDate)
                .HasComment("วันที่ชำระเงิน")
                .HasColumnType("datetime");
            entity.Property(e => e.PaymentType)
                .HasMaxLength(50)
                .HasComment("วิธีการชำระ เช่น qrcode creditcard");
            entity.Property(e => e.PercentageFeeRate)
                .HasComment("อัตราค่าธรรมเนียมร้อยละ")
                .HasColumnType("double(6,2)");
            entity.Property(e => e.Ref1)
                .HasMaxLength(255)
                .HasComment("หมายเลขอ้างอิง1");
            entity.Property(e => e.Ref2)
                .HasMaxLength(255)
                .HasComment("หมายเลขอ้างอิง2");
            entity.Property(e => e.TransId)
                .HasComment("รหัสธุรกรรม")
                .HasColumnName("transId");
            entity.Property(e => e.UserId).HasComment("รหัสผู้ใช้งาน");

            entity.HasOne(d => d.ChargePoint).WithMany(p => p.ChargerPurchases)
                .HasForeignKey(d => d.ChargePointId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ChargerPurchase_ibfk_1");
        });

        modelBuilder.Entity<ChargerSummary>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("ChargerSummary")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_unicode_ci");

            entity.HasIndex(e => e.ChargerBookingId, "ChargerBookingId");

            entity.Property(e => e.Amount)
                .HasPrecision(10, 2)
                .HasComment("จำนวนเงิน");
            entity.Property(e => e.CarbonReduction)
                .HasComment("คาบอนเครดิตที่ได้รับ")
                .HasColumnType("double(16,10)");
            entity.Property(e => e.ChargerBookingId).HasComment("รหัสการจอง");
            entity.Property(e => e.CnNo)
                .HasComment("หมายเลขหัวชาร์จ")
                .HasColumnName("cnNo");
            entity.Property(e => e.CpId)
                .HasMaxLength(255)
                .HasComment("รหัสประจำตัวเครื่องชาร์จ")
                .HasColumnName("cpId");
            entity.Property(e => e.CreateDate)
                .HasComment("วันที่สร้าง")
                .HasColumnType("datetime");
            entity.Property(e => e.Fee)
                .HasPrecision(10, 2)
                .HasComment("ค่าบริการ");
            entity.Property(e => e.IsPaid).HasComment("สถานะการชำระ");
            entity.Property(e => e.MeterStart)
                .HasComment("มิเตอร์เริ่มต้น")
                .HasColumnType("double(10,3)")
                .HasColumnName("meterStart");
            entity.Property(e => e.MeterUpdate)
                .HasComment("มิเตอร์สินสุด")
                .HasColumnType("double(10,3)")
                .HasColumnName("meterUpdate");
            entity.Property(e => e.Net)
                .HasPrecision(10, 2)
                .HasComment("สุทธิ");
            entity.Property(e => e.PaidDate)
                .HasComment("วันที่ชำระ")
                .HasColumnType("datetime");
            entity.Property(e => e.PaymentType)
                .HasMaxLength(50)
                .HasComment("วิธีการชำระ เช่น qrcode creditcard อนุมัติโดยadmin")
                .UseCollation("utf8mb4_unicode_ci")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.PercentageFeeRate)
                .HasComment("อัตราค่าธรรมเนียมร้อยละ")
                .HasColumnType("double(6,2)");
            entity.Property(e => e.Price)
                .HasComment("ราคา หรือราคา On Peak")
                .HasColumnType("double(10,2)");
            entity.Property(e => e.Price2)
                .HasComment("ราคา Off Peak")
                .HasColumnType("double(10,2)");
            entity.Property(e => e.TagId)
                .HasMaxLength(255)
                .HasComment("หมายเลขการใช้งาน")
                .HasColumnName("tagId");
            entity.Property(e => e.TaxInvoiceId).HasComment("รหัสใบกำกับภาษี");
            entity.Property(e => e.TaxpayerinfoId)
                .HasComment("รหัสข้อมูลผู้เสียภาษี")
                .UseCollation("utf8mb4_unicode_ci")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.TimeChargeringSecond)
                .HasComment("จำนวนวินาทีที่ชาร์จ")
                .HasColumnName("timeChargeringSecond");
            entity.Property(e => e.TransId)
                .HasComment("หมายเลขธุรกรรม")
                .HasColumnName("transId");
            entity.Property(e => e.TransStart)
                .HasComment("การเริ่มต้นการใช้งาน")
                .HasColumnType("datetime")
                .HasColumnName("transStart");
            entity.Property(e => e.TransUpdate)
                .HasComment("การสิ้นสุดการใช้งาน")
                .HasColumnType("datetime")
                .HasColumnName("transUpdate");
            entity.Property(e => e.UnitPriceType).HasComment("รูปแบบการคำนวน 0 Flat Rate 1 tou");
            entity.Property(e => e.UnitType).HasComment("ประเภทการคำนวณ 0 ต่อพลังงาน 1 ต่อชั่วโมง");
            entity.Property(e => e.UseMeterKw)
                .HasComment("จำนวนหน่วยไฟฟ้าที่ชาร์จ")
                .HasColumnType("double(16,6)");
            entity.Property(e => e.UserId).HasComment("รหัสผู้ใช้งาน");
            entity.Property(e => e.UserKeyType)
                .HasMaxLength(10)
                .HasComment("ประเภทของkey 0=ใช้ผ่านแอพ, 1=rfid, 2=vid, 3=homeUse")
                .UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            entity.HasOne(d => d.ChargerBooking).WithMany(p => p.ChargerSummaries)
                .HasForeignKey(d => d.ChargerBookingId)
                .HasConstraintName("ChargerSummary_ibfk_1");
        });

        modelBuilder.Entity<ChargerUser>(entity =>
        {
            entity.HasKey(e => e.ChargerUserId).HasName("PRIMARY");

            entity
                .ToTable("ChargerUser")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_unicode_ci");

            entity.HasIndex(e => e.ChargerId, "ChargeId");

            entity.Property(e => e.ChargerUserId).HasComment("รหัสเครื่องชาร์จกับผู้ใช้งาน");
            entity.Property(e => e.ChargerId).HasComment("รหัสเครื่องชาร์จ");
            entity.Property(e => e.CreateBy).HasComment("สร้างโดย");
            entity.Property(e => e.CreateDate)
                .HasComment("สร้างวันที่")
                .HasColumnType("datetime");
            entity.Property(e => e.DeleteBy)
                .HasMaxLength(255)
                .HasComment("ลบโดย");
            entity.Property(e => e.DeleteDate)
                .HasComment("วันที่ลบ")
                .HasColumnType("datetime");
            entity.Property(e => e.IsDelete).HasComment("สถานะการลบ");
            entity.Property(e => e.Status).HasComment("สถานะการใช้งาน");
            entity.Property(e => e.UserId).HasComment("รหัสผู้ใช้งาน");

            entity.HasOne(d => d.Charger).WithMany(p => p.ChargerUsers)
                .HasForeignKey(d => d.ChargerId)
                .HasConstraintName("fk_chargerId");
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.CompanyId).HasName("PRIMARY");

            entity
                .ToTable("Company")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.CompanyId).HasComment("รหัสบริษัท");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasComment("ที่อยู่");
            entity.Property(e => e.Branch)
                .HasMaxLength(255)
                .HasComment("สาขา");
            entity.Property(e => e.CompanyName)
                .HasMaxLength(255)
                .HasComment("ชื่อบริษัท");
            entity.Property(e => e.CompanyType)
                .HasMaxLength(10)
                .HasComment("ประเภทของบริษัท 1=มีการชำระเงินผ่านแอพsmartEz 2=ชำระเงินภายนอกไม่ใช้แอพsmartEz 3=ไม่มีเรื่องเกี่ยวกับเงิน");
            entity.Property(e => e.CreateBy).HasComment("สร้างโดย");
            entity.Property(e => e.CreateDate)
                .HasComment("วันที่สร้าง")
                .HasColumnType("datetime");
            entity.Property(e => e.DeleteBy).HasComment("ลบโดย");
            entity.Property(e => e.DeleteDate)
                .HasComment("วันที่ลบ")
                .HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(45)
                .HasComment("อีเมล");
            entity.Property(e => e.GroupName)
                .HasMaxLength(255)
                .HasComment("ชื่อกลุ่ม");
            entity.Property(e => e.IsActive).HasComment("สถานะการใช้งาน");
            entity.Property(e => e.IsDelete).HasComment("สถานะการลบ");
            entity.Property(e => e.PaymentCode)
                .HasMaxLength(20)
                .HasComment("อ้างอิงรหัสการชำระของ payment gateway");
            entity.Property(e => e.PercentageFeeRate)
                .HasComment("อัตราค่าธรรมเนียมร้อยละ")
                .HasColumnType("double(6,2)");
            entity.Property(e => e.Phonenumber)
                .HasMaxLength(10)
                .HasComment("เบอร์โทร");
            entity.Property(e => e.SubDistrictId)
                .HasMaxLength(6)
                .HasComment("รหัสตำบล");
            entity.Property(e => e.TaxIdCard)
                .HasMaxLength(13)
                .HasComment("เลขผู้เสียภาษี");
            entity.Property(e => e.UpdateBy).HasComment("อัพเดทโดย");
            entity.Property(e => e.UpdateDate)
                .HasComment("วันที่อัพเดท")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<CompanyStation>(entity =>
        {
            entity.HasKey(e => e.CompanyStationId).HasName("PRIMARY");

            entity.HasIndex(e => e.CompanyId, "CompanyId");

            entity.HasIndex(e => e.StationId, "StationId");

            entity.Property(e => e.CompanyStationId).HasComment("รหัสบริษัทกับสถานี");
            entity.Property(e => e.CompanyId)
                .HasComment("รหัสบริษัท")
                .UseCollation("utf8mb4_unicode_ci");
            entity.Property(e => e.CreateBy)
                .HasComment("สร้างโดย")
                .UseCollation("utf8mb4_unicode_ci");
            entity.Property(e => e.CreateDate)
                .HasComment("วันที่สร้าง")
                .HasColumnType("datetime");
            entity.Property(e => e.DeleteBy).HasComment("ลบโดย");
            entity.Property(e => e.DeleteDate)
                .HasComment("ลบวันที่")
                .HasColumnType("datetime");
            entity.Property(e => e.IsDelete).HasComment("สถานะการลบ");
            entity.Property(e => e.IsPrivateStation).HasComment("สถานะการเป็นสถานีแบบปิด");
            entity.Property(e => e.StationId).HasComment("รหัสถานี");
            entity.Property(e => e.TimeOpen)
                .HasMaxLength(255)
                .HasComment("เวลาเปิดสถานี")
                .UseCollation("utf8mb3_unicode_ci")
                .HasCharSet("utf8mb3");

            entity.HasOne(d => d.Company).WithMany(p => p.CompanyStations)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("CompanyStations_ibfk_1");

            entity.HasOne(d => d.Station).WithMany(p => p.CompanyStations)
                .HasForeignKey(d => d.StationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("CompanyStations_ibfk_2");
        });

        modelBuilder.Entity<Faq>(entity =>
        {
            entity.HasKey(e => e.FaqId).HasName("PRIMARY");

            entity.ToTable("Faq");

            entity.Property(e => e.CreateDate)
                .HasComment("วันที่สร้าง")
                .HasColumnType("datetime");
            entity.Property(e => e.FaqAnswers)
                .HasMaxLength(255)
                .HasComment("คำตอบ");
            entity.Property(e => e.FaqCategories)
                .HasMaxLength(255)
                .HasComment("หมวดหมู่");
            entity.Property(e => e.FaqOrder).HasComment("ลำดับ");
            entity.Property(e => e.FaqQuestionsAnswersCategories)
                .HasMaxLength(255)
                .HasComment("คำภาม")
                .HasColumnName("FaqQuestions\nAnswers\nCategories");
            entity.Property(e => e.IsDelete).HasComment("สถานะการลบ");
        });

        modelBuilder.Entity<Fcm>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("Fcm")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasComment("รหัสการแจ้งเตือน");
            entity.Property(e => e.CreateDate)
                .HasComment("วันที่สร้าง")
                .HasColumnType("datetime");
            entity.Property(e => e.DeleteDate)
                .HasComment("วันที่ลบ")
                .HasColumnType("datetime");
            entity.Property(e => e.FcmToken)
                .HasMaxLength(255)
                .HasComment("โทเคน");
            entity.Property(e => e.IsDelete).HasComment("วันที่ลบ");
            entity.Property(e => e.UserId).HasComment("รหัสผู้ใช้งาน");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.MenuId).HasName("PRIMARY");

            entity
                .ToTable("Menu")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.MenuId).HasComment("รหัสเมนู");
            entity.Property(e => e.IsDelete).HasComment("สถานะการลบ");
            entity.Property(e => e.IsMenu).HasComment("สถานะการเป็นเมนู");
            entity.Property(e => e.MenuName)
                .HasMaxLength(100)
                .HasComment("ชื่อเมนู");
            entity.Property(e => e.MenuPathIcon)
                .HasMaxLength(255)
                .HasComment("ตำแหน่งของ icon");
            entity.Property(e => e.MenuPathUrl)
                .HasMaxLength(255)
                .HasComment("ตำแหน่ง path url");
            entity.Property(e => e.MenuTitle)
                .HasMaxLength(100)
                .HasComment("ชื่อหัวข้อเมนู");
            entity.Property(e => e.OrderNumber).HasComment("ลำดับเมนู");
        });

        modelBuilder.Entity<Message>(entity =>
        {
            entity.HasKey(e => e.MessageId).HasName("PRIMARY");

            entity
                .ToTable("Message")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.MessageId).HasComment("รหัสข้อความ");
            entity.Property(e => e.CreateBy).HasComment("สร้างโดย");
            entity.Property(e => e.CreateDate)
                .HasComment("วันที่สร้าง")
                .HasColumnType("datetime");
            entity.Property(e => e.DeleteBy).HasComment("ลบโดย");
            entity.Property(e => e.DeleteDate)
                .HasComment("ลบวันที่")
                .HasColumnType("datetime");
            entity.Property(e => e.Message1)
                .HasComment("ข้อความ")
                .HasColumnType("text")
                .HasColumnName("Message");
            entity.Property(e => e.MessageTitle)
                .HasMaxLength(255)
                .HasComment("หัวข้อข้อความ");
            entity.Property(e => e.UpdateBy).HasComment("อัพเดทโดย");
            entity.Property(e => e.UpdateDate)
                .HasComment("อัพเดทวันที่")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<News>(entity =>
        {
            entity.HasKey(e => e.NewsId).HasName("PRIMARY");

            entity.Property(e => e.NewsId).HasComment("รหัสข่าว");
            entity.Property(e => e.CrateBy).HasComment("สร้างโดย");
            entity.Property(e => e.CreateDate)
                .HasComment("วันที่สร้าง")
                .HasColumnType("datetime");
            entity.Property(e => e.DeleteBy).HasComment("ลบโดย");
            entity.Property(e => e.DeleteDate)
                .HasComment("วันที่ลบ")
                .HasColumnType("datetime");
            entity.Property(e => e.EndDate)
                .HasComment("วันที่สิ้นสุดแสดง")
                .HasColumnType("datetime");
            entity.Property(e => e.IsDelete).HasComment("สถานะการลบ");
            entity.Property(e => e.NewsMessage)
                .HasMaxLength(255)
                .HasComment("ข้อความข่าว");
            entity.Property(e => e.StartDate)
                .HasComment("วันที่เริ่มต้นแสดง")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("Notification")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.CompanyId, "CompanyId");

            entity.HasIndex(e => e.MessageId, "MessageId");

            entity.HasIndex(e => e.RoleId, "RoleId");

            entity.Property(e => e.Id).HasComment("รหัสการแจ้งเตือน");
            entity.Property(e => e.CompanyId).HasComment("รหัสบริษัท");
            entity.Property(e => e.IsRead).HasComment("สถานะการอ่าน");
            entity.Property(e => e.IsSend).HasComment("สถานะการส่ง");
            entity.Property(e => e.MessageId).HasComment("รหัสข้อความ");
            entity.Property(e => e.RefValue)
                .HasMaxLength(255)
                .HasComment("ค่าสำหรับใช้งานการอ้างอิง ป้องกันการส่งซ้ำ");
            entity.Property(e => e.RoleId).HasComment("รหัสสิทธิ์");
            entity.Property(e => e.SendType).HasComment("0 เริ่มชาร์จสำเร็จ   1 หยุดชาร์จสำเร็จ     2 จองสำเร็จ.    3 ยกเลิกจองสำเร็จ.    4 ก่อนชาร์จเสร็จ 5 นาที.    5 ชาร์จครบเวลาที่จองแล้ว.      - 6 ถูกยกเลิกจองกรณีไม่มาในเวลาที่กำหนด.  7 เครื่องออฟไลน์.  8 เครื่องออนไลน์    - 9 รีบชำระเงินสำเร็จ  charger   - 10 เสร็จสิ้นการใช้งาน    - 11 การเปลี่ยนแปลงราคาเครื่องชาร์จ    - 12 การสั่ง restart    - 13 ตั้งค่า Set profile    14 ลบ user ในระบบ     - 15 รับชำระเงินสำเร็จ booking");
            entity.Property(e => e.Status).HasComment("สถานะการใช้งาน");
            entity.Property(e => e.UpdateDate)
                .HasComment("วันที่อัพเดท")
                .HasColumnType("datetime");
            entity.Property(e => e.UserId).HasComment("รหัสผู้ใช้งาน");

            entity.HasOne(d => d.Company).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("Notification_ibfk_2");

            entity.HasOne(d => d.Message).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.MessageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Notification_ibfk_1");

            entity.HasOne(d => d.Role).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("Notification_ibfk_3");
        });

        modelBuilder.Entity<PrePaidToken>(entity =>
        {
            entity.HasKey(e => e.PrePaidId).HasName("PRIMARY");

            entity.ToTable("PrePaidToken");

            entity.Property(e => e.PrePaidId).HasColumnName("PrePaidID");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ExpiresDate).HasColumnType("datetime");
            entity.Property(e => e.LastUsedDate).HasColumnType("datetime");
            entity.Property(e => e.TokenId).HasColumnName("TokenID");
            entity.Property(e => e.Username).HasMaxLength(100);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PRIMARY");

            entity
                .ToTable("Role")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.RoleId).HasComment("รหัสสิทธิ์");
            entity.Property(e => e.Description)
                .HasMaxLength(45)
                .HasComment("รายละเอียด");
            entity.Property(e => e.IsActive).HasComment("สถานะการใช้งาน");
            entity.Property(e => e.IsAdmin).HasComment("สถานะการเป็นแอดมิน");
            entity.Property(e => e.IsBoard).HasComment("สถานะการเป็นบอร์ด");
            entity.Property(e => e.IsOperator).HasComment("สถานะการเป็นโอเปเรเตอร์");
            entity.Property(e => e.IsSuperAdmin).HasComment("สถานะการเป็นแอดมินสูงสุด");
            entity.Property(e => e.RoleName)
                .HasMaxLength(45)
                .HasComment("ชื่อสิทธิ์");
        });

        modelBuilder.Entity<RoleMenu>(entity =>
        {
            entity.HasKey(e => e.RoleMenuId).HasName("PRIMARY");

            entity
                .ToTable("RoleMenu")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.MenuId, "MenuId_idx");

            entity.HasIndex(e => e.RoleId, "RoleId");

            entity.Property(e => e.RoleMenuId).HasComment("รหัสสิทธิ์กับเมนู");
            entity.Property(e => e.IsAdd).HasComment("สถานะการเพิ่ม");
            entity.Property(e => e.IsDelete).HasComment("สถานะการลบ");
            entity.Property(e => e.IsEdit).HasComment("สถานะการแก้ไข");
            entity.Property(e => e.IsView).HasComment("สถานะการดู");
            entity.Property(e => e.MenuId).HasComment("รหัสเมนู");
            entity.Property(e => e.RoleId).HasComment("รหัสสิทธิ์");

            entity.HasOne(d => d.Menu).WithMany(p => p.RoleMenus)
                .HasForeignKey(d => d.MenuId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RoleMenu_ibfk_2");

            entity.HasOne(d => d.Role).WithMany(p => p.RoleMenus)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RoleMenu_ibfk_3");
        });

        modelBuilder.Entity<Station>(entity =>
        {
            entity.HasKey(e => e.StationId).HasName("PRIMARY");

            entity.Property(e => e.StationId).HasComment("รหัสถานี");
            entity.Property(e => e.DeleteBy).HasComment("ลบโดย");
            entity.Property(e => e.DeleteDate)
                .HasComment("ลบวันที่")
                .HasColumnType("datetime");
            entity.Property(e => e.IsDelete).HasComment("สถานะการลบ");
            entity.Property(e => e.StCode)
                .HasMaxLength(20)
                .HasComment("รหัสอ้างอิงสถานี");
            entity.Property(e => e.StationAddressEn)
                .HasMaxLength(1000)
                .HasComment("ที่อยู่ภาษาอังกฤษ");
            entity.Property(e => e.StationAddressTh)
                .HasMaxLength(1000)
                .HasComment("ที่อยู่ภาษาไทย");
            entity.Property(e => e.StationLatitude)
                .HasMaxLength(20)
                .HasComment("ละติจูด");
            entity.Property(e => e.StationLongitude)
                .HasMaxLength(20)
                .HasComment("ลองจิจูด");
            entity.Property(e => e.StationNameEn)
                .HasMaxLength(250)
                .HasComment("ชื่อสถานีภาษาอังกฤษ");
            entity.Property(e => e.StationNameTh)
                .HasMaxLength(250)
                .HasComment("ชื่อสถานีภาษาไทย");
            entity.Property(e => e.StationStatus).HasComment("สถานะการเปิดปิดการใช้งานสถานี");
        });

        modelBuilder.Entity<TemplateProfilePower>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("TemplateProfilePower")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_unicode_ci");

            entity.Property(e => e.Id).HasComment("รหัสโปรไฟล์");
            entity.Property(e => e.EndTime)
                .HasMaxLength(10)
                .HasComment("ช่วงเวลาสิ้นสุด");
            entity.Property(e => e.IsDelete).HasComment("สถานะการลบ");
            entity.Property(e => e.Percent).HasComment("จำนวนเปอร์เซ็นต์");
            entity.Property(e => e.ProfileNumber).HasComment("หมายเลขโปรไฟล์");
            entity.Property(e => e.StartTime)
                .HasMaxLength(10)
                .HasComment("ช่วงเวลาเริ่มต้น");
        });

        modelBuilder.Entity<UnitPrice>(entity =>
        {
            entity.HasKey(e => e.UnitPriceId).HasName("PRIMARY");

            entity
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_unicode_ci");

            entity.HasIndex(e => e.ChargePointId, "ChargerPointId");

            entity.Property(e => e.UnitPriceId).HasComment("รหัสราคา");
            entity.Property(e => e.ChargePointId).HasComment("รหัสหัวชาร์จ");
            entity.Property(e => e.CreateDate)
                .HasComment("วันที่สร้าง")
                .HasColumnType("datetime");
            entity.Property(e => e.IsDelete).HasComment("สถานะการลบ");
            entity.Property(e => e.Price)
                .HasComment("ราคา หรือราคา On Peak")
                .HasColumnType("double(10,2)");
            entity.Property(e => e.Price2)
                .HasComment("ราคา Off Peak")
                .HasColumnType("double(10,2)");
            entity.Property(e => e.UnitPriceType).HasComment("รูปแบบการคำนวน 0 Flat Rate 1 tou");
            entity.Property(e => e.UnitType).HasComment("ประเภทการคำนวณ 0 ต่อพลังงาน 1 ต่อชั่วโมง");

            entity.HasOne(d => d.ChargePoint).WithMany(p => p.UnitPrices)
                .HasForeignKey(d => d.ChargePointId)
                .HasConstraintName("UnitPrices_ibfk_1");
        });

        modelBuilder.Entity<UnitPriceSchedule>(entity =>
        {
            entity.HasKey(e => e.UnitPriceScheduleId).HasName("PRIMARY");

            entity.ToTable("UnitPriceSchedule");

            entity.HasIndex(e => e.ChargePointId, "ChargePointId");

            entity.Property(e => e.UnitPriceScheduleId).HasComment("รหัสการตั้งราคาตามช่วงเวลา");
            entity.Property(e => e.ChargePointId)
                .HasComment("รหัสหัวชาร์จ")
                .UseCollation("utf8mb3_unicode_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.CreateDate)
                .HasComment("วันที่สร้าง")
                .HasColumnType("datetime");
            entity.Property(e => e.IsDelete).HasComment("สถานะการลบ");
            entity.Property(e => e.Price)
                .HasComment("ราคาต่อหน่วย")
                .HasColumnType("double(10,2)");
            entity.Property(e => e.ScheduleEndTime)
                .HasMaxLength(10)
                .HasComment("เวลาสิ้นสุด")
                .UseCollation("utf8mb3_unicode_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.ScheduleStartTime)
                .HasMaxLength(10)
                .HasComment("เวลาเริ่มต้น")
                .UseCollation("utf8mb3_unicode_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.ScheduleStatus).HasComment("สถานะการตั้งเวลา");
            entity.Property(e => e.UnitType).HasComment("ประเภทการคำนวณ 0 ต่อพลังงาน 1 ต่อชั่วโมง");

            entity.HasOne(d => d.ChargePoint).WithMany(p => p.UnitPriceSchedules)
                .HasForeignKey(d => d.ChargePointId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("UnitPriceSchedule_ibfk_1");
        });

        modelBuilder.Entity<UserKey>(entity =>
        {
            entity.HasKey(e => e.UserKeyId).HasName("PRIMARY");

            entity.Property(e => e.UserKeyId).HasComment("รหัสประจำตัวkey");
            entity.Property(e => e.CreateBy).HasComment("ผู้สร้าง");
            entity.Property(e => e.CreateDate)
                .HasComment("วันที่สร้าง")
                .HasColumnType("datetime");
            entity.Property(e => e.DeleteDate)
                .HasComment("วันที่ลบ")
                .HasColumnType("datetime");
            entity.Property(e => e.IsDelete).HasComment("สถานะการลบ");
            entity.Property(e => e.IsSupportOffline).HasComment("รองรับการยืนยันตัวตนแบบ offline ac=20 card,dc=50 card");
            entity.Property(e => e.UpdateBy).HasComment("ผู้ปรังปรุง");
            entity.Property(e => e.UpdateDate)
                .HasComment("วันที่ปรับปรุง")
                .HasColumnType("datetime");
            entity.Property(e => e.UserId).HasComment("รหัสผู้ใช้งาน");
            entity.Property(e => e.UserKeyType)
                .HasMaxLength(10)
                .HasComment("ประเภทของkey 1=rfid 2=vid");
            entity.Property(e => e.UserKeyValue)
                .HasMaxLength(30)
                .HasComment("ค่าkey");
        });

        modelBuilder.Entity<UsersConnectCompany>(entity =>
        {
            entity.HasKey(e => e.UsersConnectCompanyId).HasName("PRIMARY");

            entity.ToTable("UsersConnectCompany");

            entity.Property(e => e.UsersConnectCompanyId).HasComment("รหัสการเชื่อมต่อ");
            entity.Property(e => e.CompanyId)
                .HasComment("รหัสบริษัท")
                .UseCollation("utf8mb4_unicode_ci");
            entity.Property(e => e.CreateBy).HasComment("ผู้สร้าง");
            entity.Property(e => e.CreateDate)
                .HasComment("วันที่สร้าง")
                .HasColumnType("datetime");
            entity.Property(e => e.DeleteDate)
                .HasComment("วันที่ลบ")
                .HasColumnType("datetime");
            entity.Property(e => e.ExpirationDate)
                .HasComment("วันที่หมดอายุ ถ้าไม่มีค่าหมายถึงไม่มีวันหมดอายุ")
                .HasColumnType("datetime");
            entity.Property(e => e.IsApprove).HasComment("สถานะการอนุญิต");
            entity.Property(e => e.IsDelete).HasComment("สถานะการลบ");
            entity.Property(e => e.UpdateBy).HasComment("ผู้ปรังปรุง");
            entity.Property(e => e.UpdateDate)
                .HasComment("วันที่ปรับปรุง")
                .HasColumnType("datetime");
            entity.Property(e => e.UserId).HasComment("รหัสผู้ใช้งาน");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
