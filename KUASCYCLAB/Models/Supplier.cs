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
    public partial class Supplier
    {
        public Supplier()
        {
            this.MaterialInventoryRecords = new HashSet<MaterialInventoryRecord>();
            this.MaterialInventoryRecords1 = new HashSet<MaterialInventoryRecord>();
            this.Purchases = new HashSet<Purchase>();
        }
        [Key]
        [Display(Name = "供應商編號")]
        public System.Guid SupplierID { get; set; }
        [Display(Name = "供應商名稱")]
        public string SupplierName { get; set; }
        [Display(Name = "聯絡電話")]
        public string SupplierPhone { get; set; }
        public string SupplierEmail { get; set; }
        [Display(Name = "住址")]
        public string SupplierAddress { get; set; }
        [Display(Name = "負責人姓名")]
        public string ResponsiblePerson { get; set; }
        [Display(Name = "有供應原料")]
        public string SupplyRawMaterial { get; set; }
        [Display(Name = "有供應原料金額")]
        public string RawMaterialPrice { get; set; }

        public virtual ICollection<MaterialInventoryRecord> MaterialInventoryRecords { get; set; }
        public virtual ICollection<MaterialInventoryRecord> MaterialInventoryRecords1 { get; set; }
        public virtual ICollection<Purchase> Purchases { get; set; }
    }
}
