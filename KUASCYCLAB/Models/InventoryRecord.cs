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
    public partial class InventoryRecord
    {
        public InventoryRecord()
        {
            this.IncomeStatements = new HashSet<IncomeStatement>();
        }
        [Key]
        [Display(Name = "商品存貨紀錄編號")]
        public System.Guid InventoryRecordID { get; set; }
        [Required]
        [Display(Name = "商品庫存量")]
        public string ProductStocks { get; set; }
        [Required]
        [Display(Name = "安全存量")]
        public string SafetyStock { get; set; }
        [Required]
        [Display(Name = "最後紀錄日期")]
        public System.DateTime LastRecordedDate { get; set; }
        [Required]
        [Display(Name = "倉管記錄人姓名")]
        public string WarehouseRecordName { get; set; }
        [Required]
        [Display(Name = "商品")]
        public System.Guid ProductID { get; set; }
        [Required]
        [Display(Name = "生產負責人姓名")]
        public System.Guid InventorySingle { get; set; }
        [Required]
        [Display(Name = "供應商")]
        public System.Guid ShipperID { get; set; }

        public virtual ICollection<IncomeStatement> IncomeStatements { get; set; }
        public virtual InventoryReceipt InventoryReceipt { get; set; }
        public virtual Product Product { get; set; }
        public virtual Product Product1 { get; set; }
        public virtual PackingList PackingList { get; set; }
        public virtual PackingList PackingList1 { get; set; }
    }
}
