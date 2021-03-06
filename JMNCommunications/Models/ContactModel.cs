﻿using System.ComponentModel.DataAnnotations;

namespace JMNCommunications.Models
    {
    public class ContactModel
        {
        [Required(ErrorMessage = "Please enter your full name")]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Please enter your phone number")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please enter your email address")]
        [EmailAddress(ErrorMessage = "Please check your email address, doesn't look valid")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Please enter your enquiry, provide as much details as posible")]
        [Display(Name = "Message")]
        public string Message { get; set; }
        }
    }