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
    public partial class Purchase
    {
        public Purchase()
        {
            this.PurchaseInvoices = new HashSet<PurchaseInvoice>();
            this.PurchaseRequestPayments = new HashSet<PurchaseRequestPayment>();
            this.PurchaseReturns = new HashSet<PurchaseReturn>();
            this.StorageVouchers = new HashSet<StorageVoucher>();
        }
        [Key]
        [Display(Name = "進貨單編號")]
        public System.Guid PurchaseID { get; set; }
        [Required]
        [Display(Name = "進貨日期")]
        public System.DateTime PurchaseDate { get; set; }
        [Required]
        [Display(Name = "限定收穫日期")]
        public System.DateTime LimitedReceiptDate { get; set; }
        [Required]
        [Display(Name = "進貨金額")]
        public string PurchaseAmount { get; set; }
        [Required]
        [Display(Name = "總進貨金額")]
        public string TotalPurchaseAmount { get; set; }
        [Required]
        [Display(Name = "收穫日期")]
        public string ReceiptLocation { get; set; }
        [Display(Name = "備註")]
        public string Remark { get; set; }
        [Required]
        [Display(Name = "採購部處理員工姓名")]
        public string PurchasingDepartmentEmployee { get; set; }
        [Required]
        [Display(Name = "生產部處理員工姓名")]
        public string SupplierEmployee { get; set; }
        [Required]
        [Display(Name = "供應商")]
        public System.Guid SupplierID { get; set; }
        [Required]
        [Display(Name = "進貨申請單")]
        public System.Guid PurchaseRequisitionID { get; set; }

        public virtual PurchaseRequisition PurchaseRequisition { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<PurchaseInvoice> PurchaseInvoices { get; set; }
        public virtual ICollection<PurchaseRequestPayment> PurchaseRequestPayments { get; set; }
        public virtual ICollection<PurchaseReturn> PurchaseReturns { get; set; }
        public virtual ICollection<StorageVoucher> StorageVouchers { get; set; }
    }
}
