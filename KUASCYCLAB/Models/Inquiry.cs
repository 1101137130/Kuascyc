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
    public partial class Inquiry
    {
        public Inquiry()
        {
            this.Quotations = new HashSet<Quotation>();
        }
        [Key]
        [Display(Name = "詢價單編號")]
        public System.Guid InquiryID { get; set; }
        [Required]
        [Display(Name = "詢價者姓名")]
        public string InquiryName { get; set; }
        [Required]
        [Display(Name = "詢價日期")]
        public System.DateTime InquiryDate { get; set; }
        [Required]
        [Display(Name = "連絡電話")]
        public string ContactsPhone { get; set; }
        [Required]
        [Display(Name = "E-Mail")]
        public string E_MAIL { get; set; }
        [Required]
        [Display(Name = "商品數量")]
        public string Qty { get; set; }
        [Display(Name = "商品總數量")]
        public string TotalQty { get; set; }
        [Display(Name = "備註")]
        public string Remark { get; set; }
        [Required]
        [Display(Name = "詢價商品")]
        public System.Guid ProductID { get; set; }

        public virtual Product Product { get; set; }
        public virtual ICollection<Quotation> Quotations { get; set; }
    }
}
