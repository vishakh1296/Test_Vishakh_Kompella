//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Shoping_Cart
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblorderdetail
    {
        public int did { get; set; }
        public int oid { get; set; }
        public int pid { get; set; }
        public decimal pprice { get; set; }
        public int pqty { get; set; }
        public decimal pamount { get; set; }
    
        public virtual tblorder tblorder { get; set; }
        public virtual tblproduct tblproduct { get; set; }
    }
}
