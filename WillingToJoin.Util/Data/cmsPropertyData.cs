//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WillingToJoin.Util.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class cmsPropertyData
    {
        public int id { get; set; }
        public int contentNodeId { get; set; }
        public Nullable<System.Guid> versionId { get; set; }
        public int propertytypeid { get; set; }
        public Nullable<int> dataInt { get; set; }
        public Nullable<decimal> dataDecimal { get; set; }
        public Nullable<System.DateTime> dataDate { get; set; }
        public string dataNvarchar { get; set; }
        public string dataNtext { get; set; }
    
        public virtual cmsPropertyType cmsPropertyType { get; set; }
        public virtual umbracoNode umbracoNode { get; set; }
    }
}
