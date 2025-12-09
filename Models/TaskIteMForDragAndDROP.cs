using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class TaskIteMForDragAndDROP
    {
        public int Id { get; set; }
        public string TaskName { get; set; }

        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int SewingLineId { get; set; }
        public SewingLine SewingLine { get; set; }
        public string ColorCode { get; set; } 

        public int Quantity { get; set; }


    }
}