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
    
    public partial class Box
    {
        public int BoxID { get; set; }
        public string BoxType { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public Nullable<decimal> Price { get; set; }
        public string Size { get; set; }
        public Nullable<int> MaterialID { get; set; }
        public Nullable<int> SuitableProductsID { get; set; }
        public Nullable<int> PStlyeID { get; set; }
    
        public virtual GiftPackageStyle GiftPackageStyle { get; set; }
        public virtual packageMaterial packageMaterial { get; set; }
    }
}
