using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoanFundManagement.Models
{
    public class Tvam
    {
        [Key]
        public int KeyVam { get; set; }  // کلید وام

        [Required]
        [StringLength(50)]
        public string VamNumber { get; set; }  // شماره وام

        [ForeignKey(nameof(Person))] // کلید خارجی به شخص (وام گیرنده)
        public int RowPerson { get; set; }  // شناسه شخص (کلید خارجی)

        public virtual Person Person { get; set; }  // رابطه با مدل شخص (وام گیرنده)

        [Required]
        [Range(1, double.MaxValue)]
        public decimal VamAmount { get; set; }  // مبلغ وام

        [Required]
        public DateTime VamDate { get; set; }  // تاریخ وام

        public int NumberVam { get; set; }  // تعداد وام‌ها

        [ForeignKey(nameof(Zamen))] // کلید خارجی به ضامن
        public int? Zamenid { get; set; }  // شناسه ضامن (کلید خارجی)

        public virtual Person Zamen { get; set; }  // رابطه با ضامن

        public string Zamenname { get; set; }  // نام ضامن (می‌تواند اختیاری باشد)

        public string Paytype { get; set; }  // نوع پرداخت (نقدی، چک و...)

        [StringLength(50)]
        public string CHkserial { get; set; }  // سریال چک
    }
}
