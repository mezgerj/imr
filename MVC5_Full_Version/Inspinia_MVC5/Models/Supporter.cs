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
    
    public partial class Supporter
    {
        public Supporter()
        {
            this.Application_Supporters = new HashSet<Application_Supporters>();
            this.Companies = new HashSet<Company>();
            this.webpages_Roles = new HashSet<webpages_Roles>();
        }
    
        public int Supporter_Id { get; set; }
        public string UserName { get; set; }
        public Nullable<int> Company_Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string Password { get; set; }
        public bool FirstTime { get; set; }
        public int Role_Id { get; set; }
        public bool RememberMe { get; set; }
    
        public virtual ICollection<Application_Supporters> Application_Supporters { get; set; }
        public virtual ICollection<Company> Companies { get; set; }
        public virtual Company Company { get; set; }
        public virtual Supporter_Roles Supporter_Roles { get; set; }
        public virtual ICollection<webpages_Roles> webpages_Roles { get; set; }
    }
}
