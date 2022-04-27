using System;
using System.ComponentModel.DataAnnotations;

namespace ccm.entities.Entities.Student
{
    public class Scholarhip : Common
    {
        [Required(ErrorMessage = "Name is required!")]
        public string Name {get;set;}
        [Required(ErrorMessage = "Description is required!")]
        public string Description {get;set;}
        
        //
        // To Do fees computation
        //public Fees Fee {get;set;}
    }
}