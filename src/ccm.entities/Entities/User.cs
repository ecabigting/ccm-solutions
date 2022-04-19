

using System.ComponentModel.DataAnnotations;

namespace ccm.entities.Entities
{
    public class User : CommonEntity
    {
        [Required(ErrorMessage = "Field is Required!")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Invalid Email!")]
        public string Email {get;set;}
        [Required(ErrorMessage = "Field is Required!")]
        public string FirstName{get;set;}
        [Required(ErrorMessage = "Field is Required!")]
        public string LastName {get;set;}
        [Required(ErrorMessage = "Field is Required!")]
        public DateTimeOffset DateOfBirth {get;set;}
        [Required(ErrorMessage = "Field is Required!")]
        public UserTypes UserType {get;set;}

    }
}