using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace Inspinia_MVC5.Models
{
    public class CompanyContext : DbContext
    {
        public CompanyContext()
            : base("Copy_IMR_TestEntities4")
        {
        }

        public DbSet<Company> Company { get; set; }
    }

    [Table("Companies")]
    [MetadataType(typeof(CompanyMetadata))]
    public partial class Company
    {
    }

    public class CompanyMetadata
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Company_Id { get; set; }

        [Required(ErrorMessage = "Please enter a user name")]
        [Display(Name = "Company Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter an email address")]
        [Display(Name = "Company Email")]
        public string Email { get; set; }

        [Display(Name = "Company Phone")]
        public string Phone { get; set; }

        [Display(Name = "Street Name & Address")]
        public string Street { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "State")]
        public string State { get; set; }

        [Display(Name = "Country")]
        public string Country { get; set; }

        [Display(Name = "Postal Code")]
        public Int32? PostalCode { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter a Status")]
        [Display(Name = "Status")]
        public string Status { get; set; }

        [Display(Name = "Admin Id")]
        public Int32? Admin_Id { get; set; }

        [Display(Name = "Company URL")]
        public string Company_Url { get; set; }
    }
}