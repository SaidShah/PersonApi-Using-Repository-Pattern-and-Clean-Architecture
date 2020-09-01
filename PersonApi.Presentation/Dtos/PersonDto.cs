using System;
using System.ComponentModel.DataAnnotations;

namespace PersonApi.Dtos
{
    public class PersonDto
    {
        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }
        
        [Required]
        public string Gender { get; set; }
        
        [Required]
        public bool IsSmart { get; set; }
        
        public DateTimeOffset CreatedOn { get; set; }
        
        public DateTimeOffset? DeletedOn { get; set; }

    }
}