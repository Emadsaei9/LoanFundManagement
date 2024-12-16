using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LoanFundManagement.Models
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(10)]
        public string NationalCode { get; set; }

        [StringLength(11)]
        public string Mobile { get; set; }

        [StringLength(15)]
        public string Tel { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        [StringLength(50)]
        public string FatherName { get; set; }

        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }

        [StringLength(20)]
        public string BirthCertificateNo { get; set; }

        [StringLength(100)]
        public string BirthPlace { get; set; }

        [StringLength(20)]
        public string AccountNumber { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        [StringLength(500)]
        public string Note { get; set; }

        public bool IsGuarantor { get; set; }

        // اضافه کردن این فیلد برای نگهداری وام‌هایی که به عنوان ضامن در آنها حضور دارد
        public virtual ICollection<Tvam> GuarantorLoans { get; set; } = new List<Tvam>();  // مقدار پیش‌فرض یک لیست خالی

    }
}
