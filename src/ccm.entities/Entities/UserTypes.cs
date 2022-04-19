using System.ComponentModel.DataAnnotations;

namespace ccm.entities.Entities
{
    public class UserTypes : CommonEntity
    {
        [Required(ErrorMessage = "Name is required!")]
        public string Name {get;set;}
        [Required(ErrorMessage = "Description is required!")]
        public string Description {get;set;}
    }
}