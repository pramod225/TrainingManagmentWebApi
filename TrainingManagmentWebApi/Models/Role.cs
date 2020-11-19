using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrainingManagmentWebApi.Models
{
    public class Role
    {
            [Key]
            public int roleID { get; set; }
            public string roleName { get; set; }
            public List<User> users { get; set; }
        
    }
}