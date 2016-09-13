using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeWebApp.Models
{
    public class HomeIndexViewModel
    {
        public IList<EmployeeViewModel> Employees { get; set; }  
    }

    public class EmployeeViewModel
    {
        [Required]
        public String Name { get; set; }

        [DisplayFormat(DataFormatString = "{0:M/d/yyyy}")]
        public DateTime Birthdate { get; set; }

        public decimal Salary { get; set; }

        [DisplayFormat(DataFormatString = "{0:M/d/yyyy}")]
        public DateTime DateHired { get; set; }
    }
}