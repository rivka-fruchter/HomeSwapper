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
    
    public partial class apartmentPlacement
    {
        public int placementCode { get; set; }
        public int apartmentCode { get; set; }
        public int familyCode { get; set; }
        public Nullable<System.DateTime> startDate { get; set; }
        public Nullable<System.DateTime> endDate { get; set; }
        public Nullable<double> Precent { get; set; }
    
        public virtual apartment apartment { get; set; }
        public virtual Familiy Familiy { get; set; }
    }
}
