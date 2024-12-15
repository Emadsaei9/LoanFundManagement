using LoanFundManagement.Models;
using Microsoft.EntityFrameworkCore;

public class LoanFundDbContext : DbContext
{
    public LoanFundDbContext(DbContextOptions<LoanFundDbContext> options) : base(options)
    {
    }

    // جداول
    public DbSet<Person> Persons { get; set; }
    public DbSet<Tvam> Tvams { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // تنظیمات مدل Person
        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(p => p.PersonId); // کلید اصلی
            entity.Property(p => p.FirstName).IsRequired().HasMaxLength(50); // نام
            entity.Property(p => p.LastName).IsRequired().HasMaxLength(50); // نام خانوادگی

            // ارتباط یک به چند با وام‌های ضامن
            entity.HasMany(p => p.GuarantorLoans)
                  .WithOne(t => t.Zamen)  // رابطه با ضامن در مدل Tvam
                  .HasForeignKey(t => t.Zamenid);  // کلید خارجی
        });

        // تنظیمات مدل Tvam
        modelBuilder.Entity<Tvam>(entity =>
        {
            entity.HasKey(t => t.KeyVam); // کلید اصلی
            entity.Property(t => t.VamNumber).IsRequired().HasMaxLength(50); // شماره وام
            entity.Property(t => t.VamAmount).IsRequired().HasColumnType("decimal(18,2)"); // مبلغ وام
            entity.Property(t => t.VamDate).IsRequired(); // تاریخ وام

            // ارتباط با شخص به عنوان وام گیرنده
            entity.HasOne(t => t.Person)
                  .WithMany()  // شخص می‌تواند چندین وام داشته باشد
                  .HasForeignKey(t => t.RowPerson)
                  .OnDelete(DeleteBehavior.Restrict);  // تنظیم رفتار حذف در صورت حذف شخص

            // ارتباط با ضامن
            entity.HasOne(t => t.Zamen)
                  .WithMany(p => p.GuarantorLoans)  // ضامن می‌تواند چندین وام ضامن باشد
                  .HasForeignKey(t => t.Zamenid)
                  .OnDelete(DeleteBehavior.SetNull);  // وقتی ضامن حذف می‌شود، شناسه ضامن در وام‌ها به null تغییر کند
        });
    }
}
