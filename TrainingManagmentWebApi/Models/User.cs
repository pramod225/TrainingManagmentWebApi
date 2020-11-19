using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrainingManagmentWebApi.Models
{
    public class User
    {
        [Key]
        public int userId { get; set; }
       
        [StringLength(10, ErrorMessage = "Max 10 characters allowed")]
        public string userName { get; set; }
        [RegularExpression("([a-zA-Z ]+)")]
        [Required]
        public string firstName { get; set; }
        [RegularExpression("([a-zA-Z ]+)")]
        public string lastName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string emailID { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateofJoin { get; set; }
        public int managerID { get; set; }
        [Display(Name = "Role")]
        public int roleID { get; set; }
    }
}