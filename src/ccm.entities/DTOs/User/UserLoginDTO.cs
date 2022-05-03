using System;
using System.ComponentModel.DataAnnotations;

namespace ccm.entities.DTOs.User
{
    public class UserLoginDTO
    {
        [Required(ErrorMessage = "Field is required!")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Invalid Email!")]
        public string Email {get;set;}
        [Required(ErrorMessage = "Field is Required!")]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", ErrorMessage = "Must contain atleast one upper case, one lower case, one symbol, and 8 characters long")]
        public string Password {get;set;}
    }
}