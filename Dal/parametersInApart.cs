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
    
    public partial class parametersInApart
    {
        public int code { get; set; }
        public Nullable<int> codeApart { get; set; }
        public Nullable<int> codeParameter { get; set; }
    
        public virtual apartment apartment { get; set; }
        public virtual parameter parameter { get; set; }
    }
}
