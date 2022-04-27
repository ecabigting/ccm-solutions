using System;
using System.ComponentModel.DataAnnotations;

namespace ccm.entities.Entities.User
{
    public class UserProfile : Common
    {
        [Required(ErrorMessage = "Field is required!")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Invalid Email!")]
        public string Email {get;set;}
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
        public UserTypes UserType {get;set;}
    }
}