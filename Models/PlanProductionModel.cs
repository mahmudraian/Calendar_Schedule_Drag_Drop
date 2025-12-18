using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class PlanProductionModel
    {
        [JsonProperty("plan_id")]
        public int PlanId { get; set; }

        [JsonProperty("IS_PRODUCTION")]
        public bool IsProduction { get; set; }

        [JsonProperty("THIS_PRODUCTION")]
        public int ThisProduction { get; set; }

        [JsonProperty("BUYER_NAME")]
        public string BuyerName { get; set; }

        [JsonProperty("JOB_NO")]
        public string JobNo { get; set; }

        [JsonProperty("STYLE_REF_NO")]
        public string StyleRefNo { get; set; }

        [JsonProperty("PO_NUMBER")]
        public string PoNumber { get; set; }

        [JsonProperty("PO_QUANTITY")]
        public int PoQuantity { get; set; }

        [JsonProperty("start_date")]
        public string StartDate { get; set; }

        [JsonProperty("start_hour")]
        public int StartHour { get; set; }

        [JsonProperty("end_date")]
        public string EndDate { get; set; }

        [JsonProperty("end_hour")]
        public int EndHour { get; set; }

        [JsonProperty("duration")]
        public double Duration { get; set; }

        [JsonProperty("plan_qnty")]
        public int PlanQuantity { get; set; }

        [JsonProperty("item_name")]
        public string ItemName { get; set; }

        [JsonProperty("TOP_BORDER_COLOR")]
        public string TopBorderColor { get; set; }

        [JsonProperty("LEFT_COLOR")]
        public string LeftColor { get; set; }

        [JsonProperty("RIGHT_COLOR")]
        public string RightColor { get; set; }

        [JsonProperty("line_id")]
        public int LineId { get; set; }

    }
}