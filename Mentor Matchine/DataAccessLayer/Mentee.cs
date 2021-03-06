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
    
    public partial class Mentee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Mentee()
        {
            this.Matches = new HashSet<Matches>();
            this.MenteeLanguage = new HashSet<MenteeLanguage>();
        }
    
        public int MenteeID { get; set; }
        public Nullable<int> NationalityID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Nullable<System.DateTime> ArrivalDate { get; set; }
        public Nullable<int> Age { get; set; }
        public string Gender { get; set; }
        public byte HasMentor { get; set; }
        public byte Disability { get; set; }
        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Matches> Matches { get; set; }
        public virtual Nationality Nationality { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MenteeLanguage> MenteeLanguage { get; set; }
    }
}
