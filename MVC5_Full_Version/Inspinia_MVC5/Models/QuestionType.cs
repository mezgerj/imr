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
    
    public partial class QuestionType
    {
        public QuestionType()
        {
            this.QAs = new HashSet<QA>();
        }
    
        public int Type_Id { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<QA> QAs { get; set; }
    }
}
