using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrainingManagmentClient.Models
{
    public class Course
    {

        public int id { get; set; }
        [Display(Name = "Course Code")]
        [Required]
        public string CourseCode { get; set; }
        [Required]
        [Display(Name = "Course Name")]
        public string CourseName { get; set; }
        [Display(Name = "Course Description")]

        public string CourseDescription { get; set; }
        [Display(Name = "Course Duration")]
        [Required]
        public string CourseDuration { get; set; }
        public List<Batch> batches { get; set; }
    }
}