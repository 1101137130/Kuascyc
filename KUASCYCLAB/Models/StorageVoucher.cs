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
    public partial class StorageVoucher
    {
        public StorageVoucher()
        {
            this.MaterialInventoryRecords = new HashSet<MaterialInventoryRecord>();
        }
        [Key]
        [Display(Name = "入庫單編號")]
        public System.Guid StorageVoucherID { get; set; }
        [Display(Name = "倉管部負責人姓名")]
        public string WarehouseStaff { get; set; }
        [Display(Name = "採購部負責人姓名")]
        public string Purchase { get; set; }
        [Display(Name = "入庫日期")]
        public System.DateTime StorageDate { get; set; }
        [Display(Name = "進貨單編號")]
        public System.Guid PurchaseID { get; set; }

        public virtual ICollection<MaterialInventoryRecord> MaterialInventoryRecords { get; set; }
        public virtual Purchase Purchase1 { get; set; }
    }
}
