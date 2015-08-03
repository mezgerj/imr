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
    public class UsersContext : DbContext
    {
        public UsersContext()
            : base("Copy_IMR_TestEntities5")
        {
        }

        public DbSet<Supporter> Supporter { get; set; }
    }

    [Table("Supporters")]
    [MetadataType(typeof(SupporterMetadata))]
    public partial class Supporter
    {
        
    }

    public class SupporterMetadata
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Supporter_Id { get; set; }

        [Required(ErrorMessage = "Please enter a user name")]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter an email address")]
        [Display(Name = "Email Address")]
        public string Email { get; set; }
    }

    public class RegisterExternalLoginModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        public string ExternalLoginData { get; set; }
    }

    public class LocalPasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RetrieveModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }
    }

    [Table("Supporters")]
    public class RegisterModel
    {
        public int UserID { get; set; }

        [Required(ErrorMessage="Please provide username", AllowEmptyStrings=false)]
        [Display(Name = "Username")]
        public string UserName { get; set; }
        
        [Required(ErrorMessage="Please provide password", AllowEmptyStrings=false)]
        [StringLength(100, ErrorMessage = "The password must be at least 6 characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        
        /*
        [Required(ErrorMessage="You must provide a company name.", AllowEmptyStrings=false)]
        */
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
        
        [Display(Name = "Company Phone")]
        public string CompanyPhone { get; set; }

        [Display(Name = "Company Email")]
        public string CompanyEmail { get; set; }

        public string CompanyUrl { get; set; }

        public string CompanyStreet { get; set; }

        public string CompanyCity { get; set; }

        public string CompanyState { get; set; }

        public string CompanyCountry { get; set; }

        public string CompanyPostalCode { get; set; }

        public string CompanyDescription { get; set; }

        [Required(ErrorMessage="Please enter the first name associated with the account.", AllowEmptyStrings=false)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage="Please enter the last name associated with the account.", AllowEmptyStrings=false)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "User Phone")]
        public string UserPhone { get; set; }

        [Required(ErrorMessage="Please enter an email address for the account.", AllowEmptyStrings=false)]
        [Display(Name = "User Email")]
        [DataType(DataType.EmailAddress)]
        //[RegularExpression(@"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2-3})$", ErrorMessage="Please provide a valid email address & format.")]
        public string UserEmail { get; set; }

        public string UserStreet { get; set; }

        public string UserCity { get; set; }

        public string UserState { get; set; }

        public string UserCountry { get; set; }

        public string UserPostalCode { get; set; }
    }

    public class ExternalLogin
    {
        public string Provider { get; set; }
        public string ProviderDisplayName { get; set; }
        public string ProviderUserId { get; set; }
    }

    public class CreateUser
    {
        [Required(ErrorMessage = "Please enter  UserName")]
        [Display(Name = "UserName")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter a First Name")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter a Last Name")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter an email address")]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please select a role")]
        [Display(Name = "Role")]
        public String Role { get; set; }

        [Required(ErrorMessage = "Please select a Comapny")]
        public int Company_Id { get; set; }
    }
}
