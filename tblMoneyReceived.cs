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
    
    public partial class tblMoneyReceived
    {
        public string CustCode { get; set; }
        public Nullable<int> SalesId { get; set; }
        public System.DateTime ReceivedDate { get; set; }
        public decimal ReceiveAmount { get; set; }
        public string PayMode { get; set; }
        public string ChequeNo { get; set; }
        public Nullable<System.DateTime> ChequeDt { get; set; }
        public string IssueBank { get; set; }
        public string DepositBank { get; set; }
        public string ChequeDetails { get; set; }
        public string Particulars { get; set; }
        public string Remarks { get; set; }
        public System.DateTime lmdt { get; set; }
        public string userid { get; set; }
        public int track_id { get; set; }
    }
}
