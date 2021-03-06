//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dal
{
    using System;
    using System.Collections.Generic;
    
    public partial class Familiy
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Familiy()
        {
            this.apartmentPlacement = new HashSet<apartmentPlacement>();
            this.familyConstraint = new HashSet<familyConstraint>();
            this.userDetails = new HashSet<userDetails>();
        }
    
        public int familyCode { get; set; }
        public string familyName { get; set; }
        public string phone { get; set; }
        public Nullable<int> apartmentCode { get; set; }
        public string email { get; set; }
    
        public virtual apartment apartment { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<apartmentPlacement> apartmentPlacement { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<familyConstraint> familyConstraint { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<userDetails> userDetails { get; set; }
    }
}
