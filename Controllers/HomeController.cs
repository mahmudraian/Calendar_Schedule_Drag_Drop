using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
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
        new SewingLine { Id = 1, LineName="Sewing-L6",ManPower = 13,ManWorkLimite=7000},
        new SewingLine { Id = 2, LineName="Sewing-L7",ManPower = 19,ManWorkLimite=1200},
        new SewingLine { Id = 3, LineName="Sewing-L8",ManPower = 23 ,ManWorkLimite=800},
        new SewingLine { Id = 4, LineName="Parking 1",ManPower = 53 ,ManWorkLimite=900},
        new SewingLine { Id = 5, LineName="Parking 2",ManPower = 630,ManWorkLimite=10000},
    };

            // Sample tasks
            var tasks = new List<TaskIteMForDragAndDROP>
    {
        new TaskIteMForDragAndDROP {Id = 1,TaskName="RpC-25-00421", FromDate=DateTime.Parse("2025-02-02"), ToDate=DateTime.Parse("2025-02-06"), SewingLineId=49000000, ColorCode="red", Quantity = 20000},
        new TaskIteMForDragAndDROP {Id = 2,TaskName="RpC-25-00222", FromDate=DateTime.Parse("2025-02-03"), ToDate=DateTime.Parse("2025-02-05"), SewingLineId=70300000, ColorCode="black" , Quantity = 40000},
        new TaskIteMForDragAndDROP {Id = 3,TaskName="RpC-25-00398", FromDate=DateTime.Parse("2025-02-02"), ToDate=DateTime.Parse("2025-02-06"), SewingLineId=48400000, ColorCode="blue",Quantity=90000},
        new TaskIteMForDragAndDROP {Id = 4,TaskName="RpC-25-00220", FromDate=DateTime.Parse("2025-02-17"), ToDate=DateTime.Parse("2025-02-23"), SewingLineId=60400000, ColorCode="black",Quantity=80000},
        new TaskIteMForDragAndDROP {Id = 5,  TaskName="RpC-25-00397", FromDate=DateTime.Parse("2025-02-12"), ToDate=DateTime.Parse("2025-02-16"), SewingLineId=51600000, ColorCode="blue",Quantity=60000}
            };

            string filePath = Server.MapPath("~/Content/File/LineJson.json");
            string jsonData = System.IO.File.ReadAllText(filePath);
            var data = JsonConvert.DeserializeObject<List<SewingLineDto>>(jsonData);

            ViewBag.Lines = data;
            ViewBag.Tasks = tasks;

            // Use provided FromDate and ToDate, or fallback to current month
            DateTime startDate = FromDate ?? new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            DateTime endDate = ToDate ?? startDate.AddMonths(1).AddDays(-1);


            

            ViewBag.StartDate = startDate;
            ViewBag.EndDate = endDate;

            return View();
        }



        public ActionResult SewingCalendar(int? month, int? year)
        {
            var now = DateTime.Today;

            int selectedMonth = month ?? now.Month;
            int selectedYear = year ?? now.Year;

            ViewBag.Month = selectedMonth;
            ViewBag.Year = selectedYear;

            var lines = new List<SewingLine>
        {
            new SewingLine { Id = 1, LineName="Sewing-L6"},
            new SewingLine { Id = 2, LineName="Sewing-L7"},
            new SewingLine { Id = 3, LineName="Sewing-L8"},
            new SewingLine { Id = 4, LineName="Parking 1"},
            new SewingLine { Id = 5, LineName="Parking 2"},
        };

            var tasks = new List<TaskIteMForDragAndDROP>
        {
            new TaskIteMForDragAndDROP { TaskName="RpC-25-00421", FromDate=DateTime.Parse("2025-02-02"), ToDate=DateTime.Parse("2025-02-06"), SewingLineId=1, ColorCode="red"},
            new TaskIteMForDragAndDROP { TaskName="RpC-25-00222", FromDate=DateTime.Parse("2025-02-03"), ToDate=DateTime.Parse("2025-02-05"), SewingLineId=2, ColorCode="BLACK"},
            new TaskIteMForDragAndDROP { TaskName="RpC-25-00398", FromDate=DateTime.Parse("2025-02-02"), ToDate=DateTime.Parse("2025-02-06"), SewingLineId=4, ColorCode="blue"}
        };



            ViewBag.Lines = lines;
            ViewBag.Tasks = tasks;

            return View();
        }

        public JsonResult SwingLineForPlan()
        {
            
            string filePath = Server.MapPath("~/Content/File/LineJson.json");

            string jsonData = System.IO.File.ReadAllText(filePath);
            var data = JsonConvert.DeserializeObject<List<SewingLineDto>>(jsonData);

            return Json(data, JsonRequestBehavior.AllowGet);
        }

    }
}