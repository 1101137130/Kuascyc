//------------------------------------------------------------------------------
// <auto-generated>
//    這個程式碼是由範本產生。
//
//    對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//    如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace KUASCYCLAB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public partial class SalesIncome
    {
        public SalesIncome()
        {
            this.SalesIncomeRecords = new HashSet<SalesIncomeRecord>();
        }
        [Key]
        [Display(Name = "銷貨入款單編號")]
        public System.Guid SalesIncomeID { get; set; }
        [Required]
        [Display(Name = "入款日期")]
        public System.DateTime Date { get; set; }
        [Display(Name = "備註")]
        public string Remark { get; set; }
        [Required]
        [Display(Name = "付款人姓名")]
        public string Payer { get; set; }
        [Required]
        [Display(Name = "會計部處理員工姓名")]
        public string AccountingDepartmentEmployee { get; set; }
        [Required]
        [Display(Name = "銷貨請款單編號")]
        public System.Guid SalesRequestPaymentID { get; set; }

        public virtual SalesRequestPayment SalesRequestPayment { get; set; }
        public virtual ICollection<SalesIncomeRecord> SalesIncomeRecords { get; set; }
    }
}
