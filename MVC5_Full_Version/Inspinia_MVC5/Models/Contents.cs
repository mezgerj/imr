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
public class ContentContext : DbContext
    {
        public ContentContext()
            : base("Copy_IMR_TestEntities4")
        {
        }

        public DbSet<Content> Content { get; set; }
    }

    [Table("Contents")]
    [MetadataType(typeof(ContentMetadata))]
    public partial class Content
    {
    }

    public class ContentMetadata
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Content_Id { get; set; }

        [Required(ErrorMessage = "Please enter a title")]
        [Display(Name = "Title")]
        public string Title { get; set; }
        
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter an application Id")]
        [Display(Name = "Application_Id")]
        public int Application_Id { get; set; }

        [Required(ErrorMessage = "Please enter an content type Id")]
        [Display(Name = "ContentType_Id")]
        public int ContentType_Id { get; set; }
        
        [Display(Name = "Path")]
        public string Path { get; set; }

        [Display(Name = "URL")]
        public string Url { get; set; }

        [Required(ErrorMessage = "Please enter a download time")]
        [Display(Name = "Download Time")]
        public int DownloadTime { get; set; }

        [Display(Name = "Sequence")]
        public int Seq { get; set; }

        [Display(Name = "Place")]
        public int Place { get; set; }
    }
}