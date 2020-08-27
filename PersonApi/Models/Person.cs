using System;
using System.ComponentModel.DataAnnotations;
using PersonApi.Interfaces;

namespace PersonApi.Models
{
    public class Person : Entity
    {

        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }
        
        [Required]
        public string Gender { get; set; }
        
        public bool IsSmart { get; set; }
        
        [Required]
        public DateTimeOffset CreatedOn { get; set; }
        
        public DateTimeOffset? DeletedOn { get; set; }

        public string FullName
        {
            get => (FirstName + " " + LastName);
        }
    }
}