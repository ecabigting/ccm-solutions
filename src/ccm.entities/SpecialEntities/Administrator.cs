using System.ComponentModel.DataAnnotations;
using ccm.entities.Entities;

namespace ccm.entities.SpecialEntities
{
    public class Administrator : Common
    {       
        [Required(ErrorMessage = "Field is Required!")]
        public string Username {get;set;}
        [Required(ErrorMessage = "Field is Required!")]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{12,}$", ErrorMessage = "Invalid password!")]
        public string Password {get;set;}
        [Required(ErrorMessage = "Field is Required!")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Invalid Email!")]
        public string Email {get;set;}
        public DateTimeOffset PasswordExpirationDate {get;set;}
    }
}