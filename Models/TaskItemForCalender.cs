using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class TaskItemForCalender
    {
        public string Line { get; set; }      // e.g. "Sewing-L6"
        public string Task { get; set; }      // e.g. "RpC-25-00421"
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string Color { get; set; }

    }
}