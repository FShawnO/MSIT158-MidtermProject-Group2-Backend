//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace 期中專案
{
    using System;
    using System.Collections.Generic;
    
    public partial class tMember
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tMember()
        {
            this.tCarts = new HashSet<tCart>();
            this.tOrders = new HashSet<tOrder>();
            this.tReviews = new HashSet<tReview>();
        }
    
        public int MemberID { get; set; }
        public string MemberName { get; set; }
        public string Cellphone { get; set; }
        public string Address { get; set; }
        public Nullable<System.DateTime> Birthday { get; set; }
        public string Sex { get; set; }
        public string Password { get; set; }
        public string E_mail { get; set; }
        public Nullable<int> Points { get; set; }
        public Nullable<bool> VIP { get; set; }
        public byte[] MemberPhoto { get; set; }
        public Nullable<decimal> Wallet { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCart> tCarts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tOrder> tOrders { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tReview> tReviews { get; set; }
    }
}
