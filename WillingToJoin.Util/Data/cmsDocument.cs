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
    
    public partial class cmsDocument
    {
        public int nodeId { get; set; }
        public bool published { get; set; }
        public int documentUser { get; set; }
        public System.Guid versionId { get; set; }
        public string text { get; set; }
        public Nullable<System.DateTime> releaseDate { get; set; }
        public Nullable<System.DateTime> expireDate { get; set; }
        public System.DateTime updateDate { get; set; }
        public Nullable<int> templateId { get; set; }
        public bool newest { get; set; }
    
        public virtual umbracoNode umbracoNode { get; set; }
    }
}
