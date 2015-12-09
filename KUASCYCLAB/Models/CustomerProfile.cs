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
    public partial class CustomerProfile
    {
        public CustomerProfile()
        {
            this.SalesOrders = new HashSet<SalesOrder>();
        }
        [Key]
        [Display(Name = "客戶編號")]
        public System.Guid CustomerID { get; set; }
        [Display(Name = "客戶名稱")]
        public string CustomerName { get; set; }
        [Display(Name = "聯絡電話")]
        public string ContactsPhone { get; set; }
        public string E_MAIL { get; set; }
        [Display(Name = "住址")]
        public string Address { get; set; }
        [Display(Name = "負責人姓名")]
        public string ResponsiblePerson { get; set; }
        [Display(Name = "匯款帳號")]
        public string RemittanceAccount { get; set; }

        public virtual ICollection<SalesOrder> SalesOrders { get; set; }
    }
}
