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
    
    public partial class Sequence
    {
        public Sequence()
        {
            this.Sequence1 = new HashSet<Sequence>();
        }
    
        public int Sequence_Id { get; set; }
        public Nullable<int> Next_Id { get; set; }
        public int Item_Id { get; set; }
        public int SequenceType_Id { get; set; }
        public int Application_Id { get; set; }
        public int DownloadTime { get; set; }
    
        public virtual Application Application { get; set; }
        public virtual ICollection<Sequence> Sequence1 { get; set; }
        public virtual Sequence Sequence2 { get; set; }
        public virtual SequenceType SequenceType { get; set; }
    }
}
