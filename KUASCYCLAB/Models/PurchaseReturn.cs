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
    public partial class PurchaseReturn
    {
        [Key]
        [Display(Name = "進貨退出單編號")]
        public System.Guid PurchaseReturnsID { get; set; }
        [Display(Name = "退貨日期")]
        public System.DateTime PurchaseReturnsDate { get; set; }
        [Display(Name = "退貨數量")]
        public string PurchaseReturnsQuantity { get; set; }
        [Display(Name = "退貨總數量")]
        public string PurchaseReturnsTotalQuantity { get; set; }
        [Display(Name = "退貨原因")]
        public string PurchaseReturnsReason { get; set; }
        [Display(Name = "捕獲限定日期")]
        public System.DateTime ReplenishmentLimitedDate { get; set; }
        [Display(Name = "備註")]
        public string Remark { get; set; }
        public System.Guid PurchaseID { get; set; }

        public virtual Purchase Purchase { get; set; }
    }
}
