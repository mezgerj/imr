//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Inspinia_MVC5.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Application_Supporters
    {
        public int Application_Id { get; set; }
        public int Supporter_Id { get; set; }
        public string Data { get; set; }
    
        public virtual Application Application { get; set; }
        public virtual Supporter Supporter { get; set; }
    }
}
