//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace 後台
{
    using System;
    using System.Collections.Generic;
    
    public partial class tProdAppearance
    {
        public int PAppearanceID { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public string Shape { get; set; }
        public Nullable<int> ProductID { get; set; }
    
        public virtual tProduct tProduct { get; set; }
    }
}
