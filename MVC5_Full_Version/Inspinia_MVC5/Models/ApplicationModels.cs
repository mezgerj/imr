using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;
using System.Web.Mvc;

namespace Inspinia_MVC5.Models
{
    public class ApplicationsContext : DbContext
    {
        public ApplicationsContext()
            : base("Copy_IMR_TestEntities5")
        {
        }

        public DbSet<Application> Application { get; set; }
    }

    [Table("Applications")]
    [MetadataType(typeof(ApplicationMetadata))]
    public partial class Application
    {
        Copy_IMR_TestEntities6 db = new Copy_IMR_TestEntities6();

        public IQueryable<Supporter> findSupporters()
        {
            return from app in db.Applications
                   join mid in db.Application_Supporters
                       on app.Application_Id equals mid.Application_Id
                   join user in db.Supporters
                       on mid.Supporter_Id equals user.Supporter_Id
                   where app.Application_Id.Equals(Application_Id)
                   select user;
        }
    }

    public class ApplicationMetadata
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Application_Id { get; set; }

        [Required(ErrorMessage = "Please enter an application name")]
        [Display(Name = "Application Name")]
        public string Name { get; set; }

        //[Required(ErrorMessage = "Please enter an email address")]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Company_Id")]
        public int Company_Id { get; set; }

        [Display(Name = "Application Token")]
        public string ApplicationToken { get; set; }

        //public virtual Company company { get; set; }
    }
}
