//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ApiTask.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class MGApi
    {
        public int idMG { get; set; }
        public string NameMG { get; set; }
        public Nullable<int> idCLL { get; set; }
    
        public virtual CLLApi CLLApi { get; set; }
    }
}