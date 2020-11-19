using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrainingManagmentWebApi.Models
{
    public class Batch
    {
        public int id { get; set; }
        [Required]
        [Display(Name = "Batch Code")]
        public string BatchCode { get; set; }
        [Required]
        [Display(Name = "Course Id")]
        public int CourseId { get; set; }
        [Required]
        [Display(Name = "Start Date")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime BatchStartDate { get; set; }
        [Required]
        [Display(Name = "No of Seats")]
        public int BatchNoOfSeats { get; set; }
    }
}