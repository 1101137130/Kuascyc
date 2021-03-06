//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace KUASCYCLAB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public partial class MaterialInventoryRecord
    {
        public MaterialInventoryRecord()
        {
            this.IncomeStatements = new HashSet<IncomeStatement>();
        }
        [Key]
        [Display(Name = "原料存貨紀錄")]
        public System.Guid MaterialInventoryRecordID { get; set; }
        [Required]
        [Display(Name = "原料名稱")]
        public string MaterialName { get; set; }
        [Required]
        [Display(Name = "原料型號")]
        public string MaterialSpecifications { get; set; }
        [Required]
        [Display(Name = "原料庫存量")]
        public string Inventory { get; set; }
        [Required]
        [Display(Name = "安全存量")]
        public string SafetyStock { get; set; }
        [Required]
        [Display(Name = "最後紀錄日期")]
        public Nullable<System.DateTime> LastRecordedDate { get; set; }
        [Required]
        [Display(Name = "倉管記錄人姓名")]
        public string CangguanLastRecordName { get; set; }
        [Required]
        [Display(Name = "供應商")]
        public System.Guid VendorID { get; set; }
        [Required]
        [Display(Name = "入庫單人員")]
        public System.Guid ReceiptID { get; set; }
        [Required]
        [Display(Name = "產品")]
        public System.Guid ProductionOrderID { get; set; }

        public virtual ICollection<IncomeStatement> IncomeStatements { get; set; }
        public virtual ProductionOrder ProductionOrder { get; set; }
        public virtual StorageVoucher StorageVoucher { get; set; }
        [Display(Name = "供應商#1")]
        public virtual Supplier Supplier { get; set; }
        [Display(Name = "供應商#2")]
        public virtual Supplier Supplier1 { get; set; }
    }
}
