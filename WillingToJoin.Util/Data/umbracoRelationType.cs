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
    
    public partial class umbracoRelationType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public umbracoRelationType()
        {
            this.umbracoRelations = new HashSet<umbracoRelation>();
        }
    
        public int id { get; set; }
        public bool dual { get; set; }
        public System.Guid parentObjectType { get; set; }
        public System.Guid childObjectType { get; set; }
        public string name { get; set; }
        public string alias { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<umbracoRelation> umbracoRelations { get; set; }
    }
}
