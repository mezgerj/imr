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
    
    public partial class Content
    {
        public int Content_Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Application_Id { get; set; }
        public int ContentType_Id { get; set; }
        public string Path { get; set; }
        public string Url { get; set; }
        public int DownloadTime { get; set; }
        public Nullable<int> Seq { get; set; }
        public Nullable<int> Place { get; set; }
    
        public virtual Application Application { get; set; }
        public virtual ContentType ContentType { get; set; }
    }
}
