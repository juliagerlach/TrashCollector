using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrashcollectorProject.Models
{
    public class ExtraDay
    {
        [Key]
        public int ID { get; set; }
        public string ExtraPickupDay { get; set; }
    }
}