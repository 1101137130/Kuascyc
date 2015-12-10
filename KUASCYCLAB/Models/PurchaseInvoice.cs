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
    public partial class PurchaseInvoice
    {
        public PurchaseInvoice()
        {
            this.IncomeStatements = new HashSet<IncomeStatement>();
            this.IncomeStatements1 = new HashSet<IncomeStatement>();
        }
        [Key]
        [Display(Name = "進項發票編號")]
        public System.Guid PurchaseInvoiceID { get; set; }
        [Required]
        [Display(Name = "統一編號")]
        public string InvoiceNumber { get; set; }
        [Required]
        [Display(Name = "開票日期")]
        public System.DateTime InvoiceDate { get; set; }
        [Required]
        [Display(Name = "進項稅費")]
        public string VATcharges { get; set; }
        [Required]
        [Display(Name = "採購部申請員工姓名")]
        public string PurchasingDepartmentEmployee { get; set; }
        [Required]
        [Display(Name = "會計部處理員工姓名")]
        public string AccountingDepartmentEmployee { get; set; }
        [Required]
        [Display(Name = "進貨單備註*")]
        public System.Guid PurchaseID { get; set; }

        public virtual ICollection<IncomeStatement> IncomeStatements { get; set; }
        public virtual ICollection<IncomeStatement> IncomeStatements1 { get; set; }
        public virtual Purchase Purchase { get; set; }
    }
}
