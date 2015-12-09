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
    public partial class BOMList
    {
        public BOMList()
        {
            this.ProductionOrders = new HashSet<ProductionOrder>();
        }
        [Key]
        [Display(Name = "BOM表編號")]
        public System.Guid BOMID { get; set; }
        [Display(Name = "所需原物料名稱")]
        public string MaterialName { get; set; }
        [Display(Name = "所需原物料數量")]
        public string MaterialQuantity { get; set; }
        public System.Guid ProductID { get; set; }

        public virtual Product Product { get; set; }
        public virtual ICollection<ProductionOrder> ProductionOrders { get; set; }
    }
}