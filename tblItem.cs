//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ElectronicsMS
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblItem
    {
        public string ItemCode { get; set; }
        public Nullable<int> SrlCode { get; set; }
        public string ItemName { get; set; }
        public string ItemNameBangla { get; set; }
        public string ItemCatId { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        public string Origin { get; set; }
        public Nullable<int> ItemSize { get; set; }
        public string ItemType { get; set; }
        public string ItemUnit { get; set; }
        public Nullable<decimal> PurRate { get; set; }
        public Nullable<decimal> SalesRate { get; set; }
        public Nullable<int> MinQty { get; set; }
        public Nullable<int> MaxQty { get; set; }
        public Nullable<int> Pack { get; set; }
        public byte[] Photo { get; set; }
        public string UserId { get; set; }
        public Nullable<System.DateTime> Lmdt { get; set; }
    }
}