//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Mentor_Matchine.DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class Lang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Lang()
        {
            this.MenteeLanguage = new HashSet<MenteeLanguage>();
            this.MentorLanguage = new HashSet<MentorLanguage>();
        }
    
        public int LanguageID { get; set; }
        public string SpokenLang { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MenteeLanguage> MenteeLanguage { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MentorLanguage> MentorLanguage { get; set; }
    }
}
