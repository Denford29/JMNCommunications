using System;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Web.Mvc;
using JMNCommunications.Models;
using Umbraco.Core.Logging;
using Umbraco.Web;
using Umbraco.Web.Mvc;

namespace JMNCommunications.Controllers
    {
    public class ContactSurfaceController : SurfaceController
        {

        /// <summary>
        /// get the contact form
        /// </summary>
        /// <returns></returns>
        public ActionResult GetContactForm()
            {
            return PartialView("Contact/Form");
            }

        /// <summary>
        /// method to process toe posted form
        /// </summary>
        /// <param name="formContactModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ContactSubmit(ContactModel formContactModel)
            {
            var formData = Request.Form;
            var captchaRequest = formData["g-recaptcha-response"];
            if (string.IsNullOrWhiteSpace(captchaRequest) || !ModelState.IsValid)
                {
                TempData["contactError"] =
                    "Opps... Form Error, There was an error with your details please check them and try again.";
                return CurrentUmbracoPage();
                }

            var emailAddress = "jasonnicholls@hotmail.com";
            var siteSetting = Umbraco.TypedContentAtRoot().FirstOrDefault(x => x.ContentType.Alias == "GlobalSettings");
            if (siteSetting != null && siteSetting.Id > 0 && siteSetting.Descendants("SiteDetails").Any())
                {
                var siteDetailsPage = siteSetting.Descendants("SiteDetails").FirstOrDefault();
                if (siteDetailsPage != null && siteDetailsPage.Id > 0)
                    {
                    if (siteDetailsPage.HasProperty("siteContactEmail") && siteDetailsPage.HasValue("siteContactEmail"))
                        {
                        emailAddress = siteDetailsPage.GetPropertyValue("siteContactEmail").ToString();
                        }
                    }
                }
            var hasEmailError = false;
            try
                {
                const string mailBody = "Thank you for contacting us on JMN Communications, " +
                    "we have got your enquiry and a member of the team will get back to you as soon as posible." +
                    "<br /> <br />Regards, <br /> Web Team";
                var userEmailMessage = new MailMessage
                {
                    Subject = "Your Contact on JMN Communications",
                    Body = mailBody,
                    From = new MailAddress("admin@jmncommunications.com.au", "Admin")
                };
                userEmailMessage.To.Add(new MailAddress(formContactModel.EmailAddress.Trim(),
                    formContactModel.FullName.Trim()));
                userEmailMessage.Bcc.Add("denfordmutseriwa@yahoo.com");
                userEmailMessage.IsBodyHtml = true;
                var userSmtpClient = new SmtpClient();
                userSmtpClient.Send(userEmailMessage);
                }
            catch (Exception ex)
                {
                var errorMessage = ex.Message + "<br /><br />" + ex.StackTrace + "<br /><br />" + ex.InnerException;
                LogHelper.Error(MethodBase.GetCurrentMethod().DeclaringType, errorMessage, ex);

                var errorEmaillMessage = new MailMessage
                {
                    Subject = "Website error on JMN Communications",
                    Body = errorMessage,
                    From = new MailAddress("admin@jmncommunications.com.au", "Web Team")
                };
                errorEmaillMessage.To.Add(new MailAddress("denfordmutseriwa@yahoo.com", "Denford"));
                errorEmaillMessage.IsBodyHtml = true;
                var errorSmtpClient = new SmtpClient();
                errorSmtpClient.Send(errorEmaillMessage);

                hasEmailError = true;
                }

            try
                {
                string adminMailBody =
                    "The contact form has been submitted on the website with the details below. <br /><br />";
                adminMailBody += "Full Name : " + formContactModel.FullName.Trim() + "<br />";
                adminMailBody += "Email Address : " + formContactModel.EmailAddress.Trim() + "<br />";
                adminMailBody += "Phone Number : " + formContactModel.PhoneNumber.Trim() + "<br />";
                adminMailBody += "Message : " + formContactModel.Message.Trim() + "<br />";
                adminMailBody += "<br />Regards,<br />Web Team";

                var adminEmaillMessage = new MailMessage
                {
                    Subject = "The contact form has been submited on JMN Communications",
                    Body = adminMailBody,
                    From = new MailAddress("admin@jmncommunications.com.au", "JMN Communications Team")
                };
                adminEmaillMessage.To.Add(new MailAddress(emailAddress, "Admin"));
                adminEmaillMessage.Bcc.Add("denfordmutseriwa@yahoo.com");
                adminEmaillMessage.IsBodyHtml = true;
                var adminSmtpClient = new SmtpClient();
                adminSmtpClient.Send(adminEmaillMessage);
                }
            catch (Exception ex)
                {
                var errorMessage = ex.Message + "<br /><br />" + ex.StackTrace + "<br /><br />" + ex.InnerException;
                LogHelper.Error(MethodBase.GetCurrentMethod().DeclaringType, errorMessage, ex);

                var errorEmaillMessage = new MailMessage
                {
                    Subject = "Admin email error on JMN Communications",
                    Body = errorMessage,
                    From = new MailAddress("admin@jmncommunications.com.au", "JMN Communications Team")
                };
                errorEmaillMessage.To.Add(new MailAddress("denfordmutseriwa@yahoo.com", "Denford"));
                errorEmaillMessage.IsBodyHtml = true;
                var errorSmtpClient = new SmtpClient();
                errorSmtpClient.Send(errorEmaillMessage);

                hasEmailError = true;
                }

            if (hasEmailError)
                {
                TempData["contactError"] =
                    "Opps... Contact Error, there was a problem submitting your request.";
                return RedirectToCurrentUmbracoPage();
                }
            else
                {
                TempData["contactSuccess"] =
                "Your contact request has been submitted successfully, a member of the team will get in touch with you shortly...";
                return CurrentUmbracoPage();
                }
            }

        }
    }