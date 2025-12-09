using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class SewingLine
    {
        public int Id { get; set; }
        public string LineName { get; set; }
        public int ManPower { get; set; }

        public int ManWorkLimite { get; set; }
    }
}