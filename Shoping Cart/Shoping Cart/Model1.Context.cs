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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class myshopDBEntities1 : DbContext
    {
        public myshopDBEntities1()
            : base("name=myshopDBEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tblcategory> tblcategories { get; set; }
        public virtual DbSet<tblimage> tblimages { get; set; }
        public virtual DbSet<tblorderdetail> tblorderdetails { get; set; }
        public virtual DbSet<tblorder> tblorders { get; set; }
        public virtual DbSet<tblproduct> tblproducts { get; set; }
        public virtual DbSet<tbluser> tblusers { get; set; }
    }
}
