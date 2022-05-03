using System;
using System.ComponentModel.DataAnnotations;
using ccm.entities.DTOs.User;

namespace ccm.entities.Entities.User
{
    public class UserLogin : Common
    {
        [Required(ErrorMessage = "Field is required!")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Invalid Email!")]
        public string Email {get;set;}
        [Required(ErrorMessage = "Field is Required!")]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{12,}$", ErrorMessage = "Invalid password!")]
        public string Password {get;set;}
        [Required(ErrorMessage = "Field is Required!")]
        public UserTypeDTO Type {get;set;}
        public Guid UserID {get;set;}
    }
}