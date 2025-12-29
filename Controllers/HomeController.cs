using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Results;
using System.Web.Mvc;
using System.Web.Services;
using WebApplication1.Models;
using WebApplication1.Service;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {

        private readonly DbService _dbService;
        public HomeController() {

          
            _dbService = new DbService();
        }

        public ActionResult Index()
        {
            var tasks = new List<TaskItem>
                {
                    new TaskItem { Task = "Task 1", H1 = "Emails", H2 = "Team Meeting", H3 = "Planning" },
                    new TaskItem { Task = "Task 2", H1 = "Code Review", H2 = "Bug Fixing", H3 = "Testing" },
                    new TaskItem { Task = "Task 3", H1 = "Documentation", H2 = "Research", H3 = "UI Updates" },
                    new TaskItem { Task = "Task 4", H1 = "API Integration", H2 = "Debugging", H3 = "Code Cleanup" },
                    new TaskItem { Task = "Task 5", H1 = "Client Call", H2 = "Prepare Report", H3 = "Deploy Build" },
                    new TaskItem { Task = "Task 6", H1 = "Database Update", H2 = "Backup", H3 = "Indexing" },
                    new TaskItem { Task = "Task 7", H1 = "Frontend Fix", H2 = "Layout Adjustments", H3 = "QA Check" },
                    new TaskItem { Task = "Task 8", H1 = "Server Setup", H2 = "Monitoring", H3 = "Log Review" },
                    new TaskItem { Task = "Task 9", H1 = "API Test", H2 = "Token Refresh", H3 = "Validation" },
                    new TaskItem { Task = "Task 10", H1 = "Design Review", H2 = "Prototype Update", H3 = "Approval" },

                   
                    new TaskItem { Task = "Task 11", H1 = "", H2 = "", H3 = "" },
                    new TaskItem { Task = "Task 12", H1 = "", H2 = "", H3 = "" },
                    new TaskItem { Task = "Task 13", H1 = "", H2 = "", H3 = "" },
                    new TaskItem { Task = "Task 14", H1 = "", H2 = "", H3 = "" },
                    new TaskItem { Task = "Task 15", H1 = "", H2 = "", H3 = "" },
                    new TaskItem { Task = "Task 16", H1 = "", H2 = "", H3 = "" },
                    new TaskItem { Task = "Task 17", H1 = "", H2 = "", H3 = "" },
                    new TaskItem { Task = "Task 18", H1 = "", H2 = "", H3 = "" },
                    new TaskItem { Task = "Task 19", H1 = "", H2 = "", H3 = "" },
                    new TaskItem { Task = "Task 20", H1 = "", H2 = "", H3 = "" }
                };

            ViewBag.tasks= tasks;

            return View();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Calendar()
        {
            var tasks = new List<TaskItemForCalender>()
        {
            new TaskItemForCalender { Task="Emails", FromDate=DateTime.Parse("2025-01-03"), ToDate=DateTime.Parse("2025-01-05") },
            new TaskItemForCalender { Task="Meeting", FromDate=DateTime.Parse("2025-01-10"), ToDate=DateTime.Parse("2025-01-12") },
        };

            ViewBag.Month = 1;  // January
            ViewBag.Year = 2025;

            return View(tasks);
        }


     
            public ActionResult CalenderIndex(int month = 12, int year = 2025)
            {
                // Sample rows (lines)
                var rows = new List<string>
            {
                "Sewing-L6","Sewing-L7","Sewing-L8","Sewing-L9","Sewing-L10",
                "Sewing-L11","Sewing-L12","Sewing-L13","Sewing-L14","Sewing-L15",
                "Parking 1","Parking 2","Parking 3"
            };

                // Sample tasks
                var tasks = new List<TaskItemForCalender>
            {
                new TaskItemForCalender { Line="Sewing-L6", Task="RpC-25-00421", FromDate=new DateTime(2025,12,2), ToDate=new DateTime(2025,12,6), Color="#d9534f" },
                new TaskItemForCalender { Line="Sewing-L7", Task="RpC-25-00222", FromDate=new DateTime(2025,12,3), ToDate=new DateTime(2025,12,5), Color="#d9534f" },
                new TaskItemForCalender { Line="Sewing-L8", Task="RpC-25-00333", FromDate=new DateTime(2025,12,4), ToDate=new DateTime(2025,12,28), Color="#d9534f" },
                new TaskItemForCalender { Line="Sewing-L9", Task="RpC-25-00200", FromDate=new DateTime(2025,12,10), ToDate=new DateTime(2025,12,26), Color="#d9534f" },
                new TaskItemForCalender { Line="Sewing-L10", Task="FAL-25-00320", FromDate=new DateTime(2025,12,6), ToDate=new DateTime(2025,12,27), Color="#d9534f" },
                new TaskItemForCalender { Line="Sewing-L11", Task="RpC-25-00396", FromDate=new DateTime(2025,12,9), ToDate=new DateTime(2025,12,28), Color="#d9534f" },
                new TaskItemForCalender { Line="Sewing-L11", Task="RpC-25-00398", FromDate=new DateTime(2025,12,2,11,30,00), ToDate=new DateTime(2025,12,5,17,45,0), Color="BLUE" }

            };

                ViewBag.Rows = rows;
                ViewBag.Month = month;
                ViewBag.Year = year;
                ViewBag.tasks = tasks;

            return View();
            }


        public ActionResult CalenderDrag(DateTime? FromDate = null, DateTime? ToDate = null)
        {
            
            var lines = new List<SewingLine>
    {
        new SewingLine { LINE_ID = 1, LINE_NAME="Sewing-L6",MAN_POWER = 13,ManWorkLimite=7000},
        new SewingLine { LINE_ID = 2, LINE_NAME="Sewing-L7",MAN_POWER = 19,ManWorkLimite=1200},
        new SewingLine { LINE_ID = 3, LINE_NAME="Sewing-L8",MAN_POWER = 23 ,ManWorkLimite=800},
        new SewingLine { LINE_ID = 4, LINE_NAME="Parking 1",MAN_POWER = 53 ,ManWorkLimite=900},
        new SewingLine { LINE_ID = 5, LINE_NAME="Parking 2",MAN_POWER = 630,ManWorkLimite=10000},
        new SewingLine { LINE_ID = 6, LINE_NAME="Sewing-L6",MAN_POWER = 13,ManWorkLimite=7000},
        new SewingLine { LINE_ID = 7, LINE_NAME="Sewing-L7",MAN_POWER = 19,ManWorkLimite=1200},
        new SewingLine { LINE_ID = 8, LINE_NAME="Sewing-L8",MAN_POWER = 23 ,ManWorkLimite=800},
        new SewingLine { LINE_ID = 9, LINE_NAME="Parking 1",MAN_POWER = 53 ,ManWorkLimite=900},
        new SewingLine { LINE_ID = 10, LINE_NAME="Parking 2",MAN_POWER = 630,ManWorkLimite=10000},
    };

          
       var taskForMains = new List<TaskIteMForDragAndDROP>
    {
        new TaskIteMForDragAndDROP {Id = 1,TaskName="RpC-25-00421", FromDate=DateTime.Parse("2025-02-02"), ToDate=DateTime.Parse("2025-02-06"), SewingLineId=49000000, ColorCode="red", Quantity = 20000,EndHour=1,StartHour=3},
        new TaskIteMForDragAndDROP {Id = 2,TaskName="RpC-25-00222", FromDate=DateTime.Parse("2025-02-03"), ToDate=DateTime.Parse("2025-02-05"), SewingLineId=70300000, ColorCode="black" , Quantity = 40000,EndHour=1,StartHour=3},
        new TaskIteMForDragAndDROP {Id = 3,TaskName="RpC-25-00398", FromDate=DateTime.Parse("2025-02-02"), ToDate=DateTime.Parse("2025-02-06"), SewingLineId=48400000, ColorCode="blue",Quantity=90000,EndHour=1,StartHour=3},
        new TaskIteMForDragAndDROP {Id = 4,TaskName="RpC-25-00220", FromDate=DateTime.Parse("2025-02-17"), ToDate=DateTime.Parse("2025-02-23"), SewingLineId=60400000, ColorCode="black",Quantity=80000,EndHour=1,StartHour=3},
        new TaskIteMForDragAndDROP {Id = 5,  TaskName="RpC-25-00397", FromDate=DateTime.Parse("2025-02-12"), ToDate=DateTime.Parse("2025-02-16"), SewingLineId=51600000, ColorCode="blue",Quantity=60000,EndHour=1,StartHour=3}
            };


            var tasks = new List<TaskIteMForDragAndDROP>
    {
        new TaskIteMForDragAndDROP {Id = 1,TaskName="RpC-25-00421", FromDate=DateTime.Parse("2025-02-02"), ToDate=DateTime.Parse("2025-02-06"), SewingLineId=1, ColorCode="red", Quantity = 20000,EndHour=3,StartHour=1},
        new TaskIteMForDragAndDROP {Id = 2,TaskName="RpC-25-00222", FromDate=DateTime.Parse("2025-02-03"), ToDate=DateTime.Parse("2025-02-05"), SewingLineId=2, ColorCode="black" , Quantity = 40000,EndHour=3,StartHour=1},
        new TaskIteMForDragAndDROP {Id = 3,TaskName="RpC-25-00398", FromDate=DateTime.Parse("2025-02-02"), ToDate=DateTime.Parse("2025-02-06"), SewingLineId=3, ColorCode="blue",Quantity=90000,EndHour=3,StartHour=1},
        new TaskIteMForDragAndDROP {Id = 4,TaskName="RpC-25-00220", FromDate=DateTime.Parse("2025-02-17"), ToDate=DateTime.Parse("2025-02-23"), SewingLineId=4, ColorCode="black",Quantity=80000,EndHour=3,StartHour=1},
        new TaskIteMForDragAndDROP {Id = 5,  TaskName="RpC-25-00397", FromDate=DateTime.Parse("2025-02-12"), ToDate=DateTime.Parse("2025-02-16"), SewingLineId=5, ColorCode="blue",Quantity=60000,EndHour=3,StartHour=1}
            };

            string filePath = Server.MapPath("~/Content/File/LineJson.json");
            string jsonData = System.IO.File.ReadAllText(filePath);
            var data = JsonConvert.DeserializeObject<List<SewingLineDto>>(jsonData);

            string taskFilePath = Server.MapPath("~/Content/File/taskJson.json");
            string taskJsonData = System.IO.File.ReadAllText(taskFilePath);

            var taskData = JsonConvert.DeserializeObject<List<PlanProductionModel>>(taskJsonData);

            
            ViewBag.Lines = data;
            ViewBag.Tasks = taskData;
            DateTime startDate = FromDate ?? new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            DateTime endDate = ToDate ?? startDate.AddMonths(1).AddDays(-1);

            ViewBag.StartDate = startDate;
            ViewBag.EndDate = endDate;

            return View();
        }



       

        public JsonResult SwingLineForPlan()
        {
            
            string filePath = Server.MapPath("~/Content/File/LineJson.json");

            string jsonData = System.IO.File.ReadAllText(filePath);
            var data = JsonConvert.DeserializeObject<List<SewingLineDto>>(jsonData);

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Orders()
        {
            string filePath = Server.MapPath("~/Content/File/Orders.json");

            string jsonData = System.IO.File.ReadAllText(filePath);

            
            var orderData = JsonConvert.DeserializeObject<List<JObject>>(jsonData);

            var result = orderData.Select(x => new
            {
                OrderId = (int)x["OrderId"],
                OrderCompany = (String)x["OrderCompany"],
                Quantity = (int)x["Quantity"],
                MaximumDays = (int)x["MaximumDays"]
            }).ToList();

            return Json(result, JsonRequestBehavior.AllowGet);
        }



        public ActionResult UpdateCalenderDrag(DateTime? FromDate = null, DateTime? ToDate = null)
        {

            var lines = new List<SewingLine>
    {
        new SewingLine { LINE_ID = 1, LINE_NAME="Sewing-L6",MAN_POWER = 13,ManWorkLimite=7000},
        new SewingLine { LINE_ID = 2, LINE_NAME="Sewing-L7",MAN_POWER = 19,ManWorkLimite=1200},
        new SewingLine { LINE_ID = 3, LINE_NAME="Sewing-L8",MAN_POWER = 23 ,ManWorkLimite=800},
        new SewingLine { LINE_ID = 4, LINE_NAME="Parking 1",MAN_POWER = 53 ,ManWorkLimite=900},
        new SewingLine { LINE_ID = 5, LINE_NAME="Parking 2",MAN_POWER = 630,ManWorkLimite=10000},
        new SewingLine { LINE_ID = 6, LINE_NAME="Sewing-L6",MAN_POWER = 13,ManWorkLimite=7000},
        new SewingLine { LINE_ID = 7, LINE_NAME="Sewing-L7",MAN_POWER = 19,ManWorkLimite=1200},
        new SewingLine { LINE_ID = 8, LINE_NAME="Sewing-L8",MAN_POWER = 23 ,ManWorkLimite=800},
        new SewingLine { LINE_ID = 9, LINE_NAME="Parking 1",MAN_POWER = 53 ,ManWorkLimite=900},
        new SewingLine { LINE_ID = 10, LINE_NAME="Parking 2",MAN_POWER = 630,ManWorkLimite=10000},
    };


            var taskForMains = new List<TaskIteMForDragAndDROP>
    {
        new TaskIteMForDragAndDROP {Id = 1,TaskName="RpC-25-00421", FromDate=DateTime.Parse("2025-02-02"), ToDate=DateTime.Parse("2025-02-06"), SewingLineId=49000000, ColorCode="red", Quantity = 20000,EndHour=1,StartHour=3},
        new TaskIteMForDragAndDROP {Id = 2,TaskName="RpC-25-00222", FromDate=DateTime.Parse("2025-02-03"), ToDate=DateTime.Parse("2025-02-05"), SewingLineId=70300000, ColorCode="black" , Quantity = 40000,EndHour=1,StartHour=3},
        new TaskIteMForDragAndDROP {Id = 3,TaskName="RpC-25-00398", FromDate=DateTime.Parse("2025-02-02"), ToDate=DateTime.Parse("2025-02-06"), SewingLineId=48400000, ColorCode="blue",Quantity=90000,EndHour=1,StartHour=3},
        new TaskIteMForDragAndDROP {Id = 4,TaskName="RpC-25-00220", FromDate=DateTime.Parse("2025-02-17"), ToDate=DateTime.Parse("2025-02-23"), SewingLineId=60400000, ColorCode="black",Quantity=80000,EndHour=1,StartHour=3},
        new TaskIteMForDragAndDROP {Id = 5,  TaskName="RpC-25-00397", FromDate=DateTime.Parse("2025-02-12"), ToDate=DateTime.Parse("2025-02-16"), SewingLineId=51600000, ColorCode="blue",Quantity=60000,EndHour=1,StartHour=3}
            };


            var tasks = new List<TaskIteMForDragAndDROP>
    {
        new TaskIteMForDragAndDROP {Id = 1,TaskName="RpC-25-00421", FromDate=DateTime.Parse("2025-02-02"), ToDate=DateTime.Parse("2025-02-06"), SewingLineId=1, ColorCode="red", Quantity = 20000,EndHour=3,StartHour=1},
        new TaskIteMForDragAndDROP {Id = 2,TaskName="RpC-25-00222", FromDate=DateTime.Parse("2025-02-03"), ToDate=DateTime.Parse("2025-02-05"), SewingLineId=2, ColorCode="black" , Quantity = 40000,EndHour=3,StartHour=1},
        new TaskIteMForDragAndDROP {Id = 3,TaskName="RpC-25-00398", FromDate=DateTime.Parse("2025-02-02"), ToDate=DateTime.Parse("2025-02-06"), SewingLineId=3, ColorCode="blue",Quantity=90000,EndHour=3,StartHour=1},
        new TaskIteMForDragAndDROP {Id = 4,TaskName="RpC-25-00220", FromDate=DateTime.Parse("2025-02-17"), ToDate=DateTime.Parse("2025-02-23"), SewingLineId=4, ColorCode="black",Quantity=80000,EndHour=3,StartHour=1},
        new TaskIteMForDragAndDROP {Id = 5,  TaskName="RpC-25-00397", FromDate=DateTime.Parse("2025-02-12"), ToDate=DateTime.Parse("2025-02-16"), SewingLineId=5, ColorCode="blue",Quantity=60000,EndHour=3,StartHour=1}
            };

            string filePath = Server.MapPath("~/Content/File/LineJson.json");
            string jsonData = System.IO.File.ReadAllText(filePath);
            var data = JsonConvert.DeserializeObject<List<SewingLineDto>>(jsonData);

            string taskFilePath = Server.MapPath("~/Content/File/taskJson.json");
            string taskJsonData = System.IO.File.ReadAllText(taskFilePath);

            var taskData = JsonConvert.DeserializeObject<List<PlanProductionModel>>(taskJsonData);


            ViewBag.Lines = data;
            ViewBag.Tasks = taskData;
            DateTime startDate = FromDate ?? new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            DateTime endDate = ToDate ?? startDate.AddMonths(1).AddDays(-1);

            ViewBag.StartDate = startDate;
            ViewBag.EndDate = endDate;

            return View();
        }

        public ActionResult MouseCalenderDrag(DateTime? FromDate = null, DateTime? ToDate = null)
        {

            string query = "SELECT * FROM LINE;SELECT * FROM [PLAN];";

            var ds = _dbService.GetDataFromQueryWithOutParam(query);


            var linesFromDB = ds.Tables[0].AsEnumerable().Select(x => new SewingLineDto
            {
             
                LINE_ID = x.Field<int>("LINE_ID"),
                LINE_NAME = x.Field<string>("LINE_NAME"),
                MAN_POWER = x.Field<int>("ManPower"),
                ManWorkLimite = x.Field<int>("ManWorkLimite"),
                SEWING_LINE_SERIAL = x.Field<decimal>("SEWING_LINE_SERIAL"),
                FLOOR_ID = x.Field<int>("FLOOR_ID"),
                COMPANY_NAME = x.Field<string>("COMPANY_NAME"),
                EFFICIENCY = x.Field<string>("EFFICENCY"),
            }).ToList();

            var tasksFromDB = ds.Tables[1].AsEnumerable().Select(x => new PlanProductionModel 
            {

                JobNo = x.Field<string>("JOB_NO"),
                PlanId = x.Field<int>("PlanID"),
                StartDate = x.Field<string>("StartDate"),
                EndDate = x.Field<string>("EndDate"),
                StartHour = x.Field<int>("StartHour"),
                EndHour = x.Field<int>("EndHour"),
                LineId = x.Field<int>("LINE_ID"),
                PlanQuantity = x.Field<int>("PLAN_QUANTITY"),
                StyleRefNo = x.Field<string>("STYLE_REF_NO"),
                Duration = x.Field<double>("DURATION"),
            }).ToList();




            ViewBag.Lines = linesFromDB;
            ViewBag.Tasks = tasksFromDB;
            DateTime startDate = FromDate ?? new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            DateTime endDate = ToDate ?? startDate.AddMonths(1).AddDays(-1);

            ViewBag.StartDate = startDate;
            ViewBag.EndDate = endDate;

            return View();
        }


        public JsonResult GetTotalLines()
        {
            string query = "SELECT * FROM LINE;SELECT * FROM [PLAN];";

            var ds = _dbService.GetDataFromQueryWithOutParam(query);


                var lines = ds.Tables[0].AsEnumerable().Select(x =>  new
                {
                    ID = x["ID"],
                    LINE_ID = x["LINE_ID"],
                    LINE_NAME = x["LINE_NAME"],
                    ManPower = x["ManPower"]
                }).ToList();

            var tasks = ds.Tables[1].AsEnumerable().Select(x => new
            {
                ID = x["ID"],
                LINE_ID = x["JOB_NO"],
                LINE_NAME = x["PlanID"],
                ManPower = x["EndHour"]
            }).ToList();


            var queryTest = "SELECT * FROM LINE WHERE ID = @ID";

            var parameters = new Dictionary<string, object>
                {
                    { "@ID", 1 }
                };

            var result = _dbService.GetDataFromQueryWithParam(queryTest, parameters).Tables[0].AsEnumerable().Select(x => new
            {
                ID = x["ID"],
                LINE_ID = x["LINE_ID"],
                LINE_NAME = x["LINE_NAME"],
                ManPower = x["ManPower"]
            }).FirstOrDefault();

            return Json(new { lines, tasks , result }, JsonRequestBehavior.AllowGet);
        }




        public ActionResult Error()
        {
            return View();
        }


     }
}