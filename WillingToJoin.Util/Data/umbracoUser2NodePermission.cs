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
    
    public partial class umbracoUser2NodePermission
    {
        public int userId { get; set; }
        public int nodeId { get; set; }
        public string permission { get; set; }
    
        public virtual umbracoNode umbracoNode { get; set; }
        public virtual umbracoUser umbracoUser { get; set; }
    }
}
