using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class SewingLineDto
    {
        public long LINE_ID { get; set; }
        public string LINE_NAME { get; set; }
        public int MAIN_LINE_ID { get; set; }
        public string USER_IDS { get; set; }
        public string ITEMS { get; set; }
        public decimal SEWING_LINE_SERIAL { get; set; }
        public int LOCATION_ID { get; set; }
        public int FLOOR_ID { get; set; }
        public string COMPANY_NAME { get; set; }
        public int MAN_POWER { get; set; }
        public string EFFICIENCY { get; set; }

        public int ManWorkLimite = 1000;
    }

}