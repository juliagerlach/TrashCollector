using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrashcollectorProject.Models
{
    public class ExtraDay
    {
        [Key]
        public int ID { get; set; }
        public string ExtraPickupDay { get; set; }

        public static implicit operator FormCollection(ExtraDay v)
        {
            throw new NotImplementedException();
        }
    }
}