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
    public partial class Product
    {
        public Product()
        {
            this.BOMLists = new HashSet<BOMList>();
            this.Inquiries = new HashSet<Inquiry>();
            this.InventoryRecords = new HashSet<InventoryRecord>();
            this.InventoryRecords1 = new HashSet<InventoryRecord>();
        }
        [Key]
        [Display(Name = "商品編號")]
        public System.Guid ProductID { get; set; }
        [Display(Name = "商品名稱")]
        public string ProductName { get; set; }
        [Display(Name = "商品規格")]
        public string ProductSpecifications { get; set; }
        [Display(Name = "商品單位")]
        public string ProductUnit { get; set; }

        public virtual ICollection<BOMList> BOMLists { get; set; }
        public virtual ICollection<Inquiry> Inquiries { get; set; }
        public virtual ICollection<InventoryRecord> InventoryRecords { get; set; }
        public virtual ICollection<InventoryRecord> InventoryRecords1 { get; set; }
    }
}