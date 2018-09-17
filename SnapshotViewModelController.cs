using JobPlacementDashboard.Models;
using JobPlacementDashboard.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace JobPlacementDashboard.Controllers
{
    public class SnapshotViewModelController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SnapshotViewModel
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Snapshot()
        {
            var weeklyAppsList = new List<JPApplication>();

            var weeklyHiresList = new List<JPHire>();

            var newJpStudentsList = new List<JPStudent>();

            var jpStudentCount = 0;
            var jpStudentCount_Portland = 0;
            var jpStudentCount_Denver = 0;
            var jpStudentCount_Seattle = 0;
            var jpStudentCount_Remote = 0;

            int unhiredGradCount = 0;
            int unhiredGradCount_Portland = 0;
            int unhiredGradCount_Denver = 0;
            int unhiredGradCount_Seattle = 0;
            int unhiredGradCount_Remote = 0;

            int totalDaysInJP = 0, avgDaysInJP = 0, totalStudents=0;
            int startDateDay = 0, startDateMonth=0, startDateYear=0, todayDateDay=0, todayDateMonth=0, todayDateYear=0;

            foreach (var student in db.JPStudents)
            {
                int id = student.JPStudentId;

                startDateDay= student.JPStartDate.Day;                   /* ----------------PB--------------- */
                startDateMonth = student.JPStartDate.Month;
                startDateYear = student.JPStartDate.Year;
                todayDateDay = DateTime.Today.Day;
                todayDateMonth = DateTime.Today.Month;
                todayDateYear = DateTime.Today.Year;

                if (student.JPHired == true)
                {
                    if (startDateDay > todayDateDay)                         // checks if the start day was in a previous month
                    {                                                        // if so adjust day count for days in the previous month
                        if (todayDateMonth == 3) todayDateDay += 28;
                        else if (todayDateMonth == 10 || todayDateMonth == 5 || todayDateMonth == 7 || todayDateMonth == 12) todayDateDay += 30;
                        else todayDateDay += 31;
                    }

                    totalDaysInJP += (todayDateDay - startDateDay);
                    totalStudents++;
                } 

                var apps = db.JPApplications.Where(a => a.ApplicationUserId == student.ApplicationUserId).ToList();
                if (student.JPHired == true)
                {
                    var hire = db.JPHires.Where(a => a.ApplicationUserId == student.ApplicationUserId).FirstOrDefault();
                    if (hire.IsHiredWithinOneWeekOfCurrentDate == true) weeklyHiresList.Add(hire);
                }

                else if (student.JPHired == false && student.JPGraduated == false)
                {
                    if ((student.JPStudentLocation == JPStudentLocation.PortlandLocal) || (student.JPStudentLocation == JPStudentLocation.PortlandRemote)) jpStudentCount_Portland++;
                    if ((student.JPStudentLocation == JPStudentLocation.DenverLocal) || (student.JPStudentLocation == JPStudentLocation.DenverRemote)) jpStudentCount_Denver++;
                    if ((student.JPStudentLocation == JPStudentLocation.SeattleLocal) || (student.JPStudentLocation == JPStudentLocation.SeattleRemote)) jpStudentCount_Seattle++;
                    if ((student.JPStudentLocation == JPStudentLocation.Remote) || (student.JPStudentLocation == JPStudentLocation.PortlandLocal)) jpStudentCount_Remote++;
                    jpStudentCount++;
                    if (student.IsStartDateWithinOneWeekOfCurrentDate == true)
                    {
                        newJpStudentsList.Add(student);
                    }
                }

                else if (student.JPHired == false && student.JPGraduated == true)
                {
                    if ((student.JPStudentLocation == JPStudentLocation.PortlandLocal) || (student.JPStudentLocation == JPStudentLocation.PortlandRemote)) unhiredGradCount_Portland++;
                    if ((student.JPStudentLocation == JPStudentLocation.DenverLocal) || (student.JPStudentLocation == JPStudentLocation.DenverRemote)) unhiredGradCount_Denver++;
                    if ((student.JPStudentLocation == JPStudentLocation.SeattleLocal) || (student.JPStudentLocation == JPStudentLocation.SeattleRemote)) unhiredGradCount_Seattle++;
                    if (student.JPStudentLocation == JPStudentLocation.Remote) unhiredGradCount_Remote++;
                    unhiredGradCount++;
                }

                foreach (var app in apps) if (app.IsAppliedDateWithinOneWeekOfCurrentDate == true) weeklyAppsList.Add(app);
            }

            var newJpStudentsList_Portland = newJpStudentsList.Where(x => (x.JPStudentLocation == JPStudentLocation.PortlandLocal) || (x.JPStudentLocation == JPStudentLocation.PortlandRemote)).ToList();
            var newJpStudentsList_Denver = newJpStudentsList.Where(x => (x.JPStudentLocation == JPStudentLocation.DenverLocal) || (x.JPStudentLocation == JPStudentLocation.DenverRemote)).ToList();
            var newJpStudentsList_Seattle = newJpStudentsList.Where(x => (x.JPStudentLocation == JPStudentLocation.SeattleLocal) || (x.JPStudentLocation == JPStudentLocation.SeattleRemote)).ToList();
            var newJpStudentsList_Remote = newJpStudentsList.Where(x => x.JPStudentLocation == JPStudentLocation.Remote).ToList();

            var weeklyHiresList_Portland = weeklyHiresList.Where(x => (x.JPStudentLocation == JPStudentLocation.PortlandLocal) || (x.JPStudentLocation == JPStudentLocation.PortlandRemote)).ToList();
            var weeklyHiresList_Denver = weeklyHiresList.Where(x => (x.JPStudentLocation == JPStudentLocation.DenverLocal) || (x.JPStudentLocation == JPStudentLocation.DenverRemote)).ToList();
            var weeklyHiresList_Seattle = weeklyHiresList.Where(x => (x.JPStudentLocation == JPStudentLocation.SeattleLocal) || (x.JPStudentLocation == JPStudentLocation.SeattleRemote)).ToList();
            var weeklyHiresList_Remote = weeklyHiresList.Where(x => x.JPStudentLocation == JPStudentLocation.Remote).ToList();

            int totalWeeklyHires = weeklyHiresList.Count();
            int totalWeeklyHires_Portland = weeklyHiresList.Where(x => (x.JPStudentLocation == JPStudentLocation.PortlandLocal) || (x.JPStudentLocation == JPStudentLocation.PortlandLocal)).Count();
            int totalWeeklyHires_Denver = weeklyHiresList.Where(x => (x.JPStudentLocation == JPStudentLocation.DenverLocal) || (x.JPStudentLocation == JPStudentLocation.DenverRemote)).Count();
            int totalWeeklyHires_Seattle = weeklyHiresList.Where(x => (x.JPStudentLocation == JPStudentLocation.SeattleLocal) || (x.JPStudentLocation == JPStudentLocation.SeattleRemote)).Count();
            int totalWeeklyHires_Remote = weeklyHiresList.Where(x => x.JPStudentLocation == JPStudentLocation.Remote).Count();
            avgDaysInJP = (totalDaysInJP / totalStudents);              // PB ---------------------------------------
     
            int totalWeeklyApps = weeklyAppsList.Count();
            int totalWeeklyApps_Portland = weeklyAppsList.Where(x => x.JPCompanyCity == "Portland").Count();
            int totalWeeklyApps_Denver = weeklyAppsList.Where(x => x.JPCompanyCity ==  "Denver").Count();
            int totalWeeklyApps_Seattle = weeklyAppsList.Where(x => x.JPCompanyCity == "Seattle").Count();
            int totalWeeklyApps_Remote = weeklyAppsList.Where(x => x.JPCompanyCity == "Remote").Count();

            
            var snapshotStats = new SnapshotViewModel(newJpStudentsList, weeklyHiresList, totalWeeklyApps, totalWeeklyHires, jpStudentCount, unhiredGradCount,
                newJpStudentsList_Portland, weeklyHiresList_Portland, totalWeeklyApps_Portland, totalWeeklyHires_Portland, jpStudentCount_Portland, unhiredGradCount_Portland,
                newJpStudentsList_Denver, weeklyHiresList_Denver, totalWeeklyApps_Denver, totalWeeklyHires_Denver, jpStudentCount_Denver, unhiredGradCount_Denver,
                newJpStudentsList_Seattle, weeklyHiresList_Seattle, totalWeeklyApps_Seattle, totalWeeklyHires_Seattle, jpStudentCount_Seattle, unhiredGradCount_Seattle,
                newJpStudentsList_Remote, weeklyHiresList_Remote, totalWeeklyApps_Remote, totalWeeklyHires_Remote, jpStudentCount_Remote, unhiredGradCount_Remote, avgDaysInJP, totalDaysInJP
                ); 
            
            //weeklyApps is 3x what it should be (it was 54 today (8/30), but it should be 18) because there are 3 copies of each seed student. Without duplicate seed data this should work fine.)

            return View(snapshotStats);

        }


        // GET: SnapshotViewModel/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SnapshotViewModel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SnapshotViewModel/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SnapshotViewModel/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SnapshotViewModel/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SnapshotViewModel/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SnapshotViewModel/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // Class for selecting students who have been hired within the week. Followed by exporting that data as csv.
        public ActionResult Export()
        {
            var beginDate = DateTime.Now.AddDays(-7);
            var weeklyHiresEmails = from student in db.JPStudents join hire in db.JPHires
                                  on student.ApplicationUserId equals hire.ApplicationUserId
                                  where (hire.JPHireDate >= beginDate && hire.JPHireDate <= DateTime.Now)
                                  select new { student.JPEmail };

            var csv = new List<string>();
            csv.Add("Emails");
            foreach (var email in weeklyHiresEmails)
            {
                csv.Add(email.ToString());
            }
            System.IO.File.WriteAllLines(@".\Test.txt", csv);

            return RedirectToAction("Snapshot");
        }
    }
}
