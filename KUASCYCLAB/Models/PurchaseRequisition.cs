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
    public partial class PurchaseRequisition
    {
        public PurchaseRequisition()
        {
            this.Purchases = new HashSet<Purchase>();
        }
        [Key]
        [Display(Name = "進貨申請單編號")]
        public System.Guid PurchaseRequisitionID { get; set; }
        [Display(Name = "申請日期")]
        public System.DateTime ApplicationDate { get; set; }
        [Display(Name = "進貨數量")]
        public string PurchaseQuantity { get; set; }
        [Display(Name = "進貨總數量")]
        public string TotalPurchaseQuantity { get; set; }
        [Display(Name = "備註")]
        public string Remark { get; set; }
        [Display(Name = "倉管部申請員工姓名")]
        public string CangguanEmployee { get; set; }
        [Display(Name = "採購部處理員工姓名")]
        public string PurchasingDepartmentEmployee { get; set; }

        public virtual ICollection<Purchase> Purchases { get; set; }
    }
}
