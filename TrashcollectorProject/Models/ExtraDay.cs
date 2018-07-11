﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrashcollectorProject.Models
{
    public class Day
    {
        [Key]
        public int ID { get; set; }
        public string PickupDay { get; set; }
    }
}