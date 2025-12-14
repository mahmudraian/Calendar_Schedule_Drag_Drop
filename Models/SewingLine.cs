using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class SewingLine
    {
        public int LINE_ID { get; set; }
        public string LINE_NAME { get; set; }
        public int MAN_POWER { get; set; }

        public int ManWorkLimite { get; set; }
    }
}