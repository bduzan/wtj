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
    
    public partial class umbracoLanguage
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public umbracoLanguage()
        {
            this.cmsLanguageTexts = new HashSet<cmsLanguageText>();
        }
    
        public int id { get; set; }
        public string languageISOCode { get; set; }
        public string languageCultureName { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cmsLanguageText> cmsLanguageTexts { get; set; }
    }
}
