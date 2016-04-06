using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MiniProjectWebService.Models
{
    public enum Day { Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday };

    public class Activity
    {
        //auto properties
        public int ActivityId { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string NameOfActivity { get; set; }

        [Required]
        public Day DayOfActivity { get; set; }

        [Required]
        public DateTime TimeOfActivity { get; set; }

        [Required]
        public decimal ActivityPrice { get; set; }

        [Required]
        public string InstructorFirstName { get; set; }

        [Required]
        public string InstructorLastName { get; set; }

        [Required]
        public string InstructorContactNumber { get; set; }

        [EmailAddress]
        public string InstructorEmail { get; set; }


        //navigation properties
        //one activity can have many enrollments - use ICollection
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}