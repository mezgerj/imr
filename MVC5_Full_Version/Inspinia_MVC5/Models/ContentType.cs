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
    
    public partial class ContentType
    {
        public ContentType()
        {
            this.Contents = new HashSet<Content>();
        }
    
        public int ContentType_Id { get; set; }
        public string TypeName { get; set; }
    
        public virtual ICollection<Content> Contents { get; set; }
    }
}
