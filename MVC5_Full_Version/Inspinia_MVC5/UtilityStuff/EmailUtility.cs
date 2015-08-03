using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using Inspinia_MVC5.Models;

namespace Inspinia_MVC5.Utility
{
    public class EmailUtility
    {
        private const string ConfirmTitle = "Confirmation from IMR_Framwork";
        private const string ApproveTitle = "Registration request has been Approved from IMR_Framwork";
        private const string DeclineTitle = "Registration request has been Declined from IMR_Framework";
        private const string AdminTitle = "Admin Account Infomation from IMR_Framework";
        private const string UserCreationTitle = "User Account Created by IMR_Framework";
        private const string PasswordResetTitle = "User Password Reset by IMR_Framework";
        public static void SendConfirmEmail(string emailAddress)
        {
            //WebMail.EnableSsl = true;
            WebMail.EnableSsl = false;
            WebMail.Send(emailAddress, ConfirmTitle, "This is automated email sent from IMR_Framework for confirmation.");
        }

        public static void SendApproveEmail(string emailAddress)
        {
            //WebMail.EnableSsl = true;
            WebMail.EnableSsl = false;
            WebMail.Send(emailAddress, ApproveTitle, "Your company has been approved");
        }

        public static void SendDeclineEmail(string emailAddress)
        {
            //WebMail.EnableSsl = true;
            WebMail.EnableSsl = false;
            WebMail.Send(emailAddress, DeclineTitle, "Your company has been declined");
        }

        public static void SendAdminEmail(string emailAddress, string lastName, string userName, string passsword)
        {
            //WebMail.EnableSsl = true;
            WebMail.EnableSsl = false;
            WebMail.Send(emailAddress, AdminTitle, "Dear Mr/Mrs. " + lastName + "<br />Your username: " + userName + "<br />Your Password: " + passsword);
        }

        public static void SendUserCreationEmail(string emailAddress, string lastName, string userName, string passsword)
        {
            //WebMail.EnableSsl = true;
            WebMail.EnableSsl = false;
            WebMail.Send(emailAddress, UserCreationTitle, "Dear Mr/Mrs. " + lastName +
                "<br />Your Account has been created <br /> Your username: " + userName +
                "<br />Your Password: " + passsword + "<br />Please visit our website at https://imr.azurewebsites.net to login.<br />"
            + "Developers should visit https://imr-api.azurewebsites.net for informaiton on how to use the API.");
        }

        public static void SendPasswordResetEmail(string emailAddress, string lastName, string userName,
            string passsword)
        {
            WebMail.EnableSsl = false;
            WebMail.Send(emailAddress, PasswordResetTitle, "Dear Mr/Mrs. " + lastName +
                "<br />Your Password has been created <br /> Your username: " + userName +
                "<br />Your Password: " + passsword
                + "<br />Please visit our website at https://imr.azurewebsites.net to login.<br />"
            + "Developers should visit https://imr-api.azurewebsites.net for informaiton on how to use the API.");
        }
    }
}