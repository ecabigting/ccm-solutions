using System;
using System.ComponentModel.DataAnnotations;

namespace ccm.entities.Entities.User
{
    public class User : Common
    {
        [Required(ErrorMessage = "Field is required!")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Invalid Email!")]
        public string Email {get;set;}
        [Required(ErrorMessage = "Field is Required!")]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", ErrorMessage = "Must contain atleast one upper case, one lower case, one symbol, and 8 characters long")]
        public string Password {get;set;}
        [Required(ErrorMessage = "Field is required!")]
        public string FirstName{get;set;}
        [Required(ErrorMessage = "Field is required!")]
        public string LastName {get;set;}
        [Required(ErrorMessage = "Field is required!")]
        public DateTimeOffset DateOfBirth {get;set;}
        [Required(ErrorMessage = "Field is required!")]
        public string MobileNumber {get;set;}
        [Required(ErrorMessage ="Field is required!")]
        public string LandLineNumber {get;set;}
        [Required(ErrorMessage = "Field is required!")]        
        public UserType UserType {get;set;}
    }
}