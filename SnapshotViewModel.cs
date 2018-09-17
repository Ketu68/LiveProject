using JobPlacementDashboard.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace JobPlacementDashboard.ViewModels
{

    public class SnapshotViewModel
    {
        //General
        [DisplayName("New Students")]
        public List<JPStudent> NewStudents { get; set; }
        [DisplayName("Weekly Applications")]
        public List<JPApplication> WeeklyApplications { get; set; }
        [DisplayName("Weekly Hires")]
        public List<JPHire> WeeklyHires { get; set; }
        [DisplayName("Total Weekly Applications")]
        public int TotalWeeklyApplications { get; set; }
        [DisplayName("Total Weekly Hires")]
        public int TotalWeeklyHires { get; set; }
        [DisplayName("Total Students")]
        public int TotalStudents { get; set; }
        [DisplayName("Unhired Graduates")]
        public int UnhiredGraduates { get; set; }
        [DisplayName("Average Days in Job Placement per Student")]              /* PB */
        public int AvgDaysInJP { get; set; }
        [DisplayName("Total Days in Job Placement for All Students")]
        public int TotalDaysInJP { get; set; }


        //Portland
        [DisplayName("New Students Portland")]
        public List<JPStudent> NewStudents_Portland { get; set; }
        [DisplayName("Weekly Applications Portland")]
        public List<JPApplication> WeeklyApplications_Portland { get; set; }
        [DisplayName("Weekly Hires Portland")]
        public List<JPHire> WeeklyHires_Portland { get; set; }
        [DisplayName("Total Weekly Applications Portland")]
        public int TotalWeeklyApplications_Portland { get; set; }
        [DisplayName("Total Weekly Hires Portland")]
        public int TotalWeeklyHires_Portland { get; set; }
        [DisplayName("Total Students Portland")]
        public int TotalStudents_Portland { get; set; }
        [DisplayName("Unhired Graduates Portland")]
        public int UnhiredGraduates_Portland { get; set; }

        //Denver
        [DisplayName("New Students")]
        public List<JPStudent> NewStudents_Denver { get; set; }
        [DisplayName("Weekly Applications")]
        public List<JPApplication> WeeklyApplications_Denver { get; set; }
        [DisplayName("Weekly Hires")]
        public List<JPHire> WeeklyHires_Denver { get; set; }
        [DisplayName("Total Weekly Applications")]
        public int TotalWeeklyApplications_Denver { get; set; }
        [DisplayName("Total Weekly Hires")]
        public int TotalWeeklyHires_Denver { get; set; }
        [DisplayName("Total Students")]
        public int TotalStudents_Denver { get; set; }
        [DisplayName("Unhired Graduates")]
        public int UnhiredGraduates_Denver { get; set; }

        //Seattle
        [DisplayName("New Students")]
        public List<JPStudent> NewStudents_Seattle { get; set; }
        [DisplayName("Weekly Applications")]
        public List<JPApplication> WeeklyApplications_Seattle { get; set; }
        [DisplayName("Weekly Hires")]
        public List<JPHire> WeeklyHires_Seattle { get; set; }
        [DisplayName("Total Weekly Applications")]
        public int TotalWeeklyApplications_Seattle { get; set; }
        [DisplayName("Total Weekly Hires")]
        public int TotalWeeklyHires_Seattle { get; set; }
        [DisplayName("Total Students")]
        public int TotalStudents_Seattle { get; set; }
        [DisplayName("Unhired Graduates")]
        public int UnhiredGraduates_Seattle { get; set; }

        //Remote
        [DisplayName("New Students")]
        public List<JPStudent> NewStudents_Remote { get; set; }
        [DisplayName("Weekly Applications")]
        public List<JPApplication> WeeklyApplications_Remote { get; set; }
        [DisplayName("Weekly Hires")]
        public List<JPHire> WeeklyHires_Remote { get; set; }
        [DisplayName("Total Weekly Applications")]
        public int TotalWeeklyApplications_Remote { get; set; }
        [DisplayName("Total Weekly Hires")]
        public int TotalWeeklyHires_Remote { get; set; }
        [DisplayName("Total Students")]
        public int TotalStudents_Remote { get; set; }
        [DisplayName("Unhired Graduates")]
        public int UnhiredGraduates_Remote { get; set; }

        public SnapshotViewModel(List<JPStudent> newStudents, List<JPHire> weeklyHires, int totalWeeklyApps, int totalWeeklyHires, int totalStudents, int unhiredGraduates,
            List<JPStudent> newStudents_portland, List<JPHire> weeklyHires_portland, int totalWeeklyApps_portland, int totalWeeklyHires_portland, int totalStudents_portland, int unhiredGraduates_portland,
            List<JPStudent> newStudents_denver, List<JPHire> weeklyHires_denver, int totalWeeklyApps_denver, int totalWeeklyHires_denver, int totalStudents_denver, int unhiredGraduates_denver,
            List<JPStudent> newStudents_seattle, List<JPHire> weeklyHires_seattle, int totalWeeklyApps_seattle, int totalWeeklyHires_seattle, int totalStudents_seattle, int unhiredGraduates_seattle,
            List<JPStudent> newStudents_remote, List<JPHire> weeklyHires_remote, int totalWeeklyApps_remote, int totalWeeklyHires_remote, int totalStudents_remote, int unhiredGraduates_remote, int avgDaysInJP, int totalDaysInJP
            )
        {
            NewStudents = newStudents;
            WeeklyHires = weeklyHires;
            TotalWeeklyApplications = totalWeeklyApps;
            TotalWeeklyHires = totalWeeklyHires;
            TotalStudents = totalStudents;
            UnhiredGraduates = unhiredGraduates;

            NewStudents_Portland = newStudents_portland;
            WeeklyHires_Portland = weeklyHires_portland;
            TotalWeeklyApplications_Portland = totalWeeklyApps_portland;
            TotalWeeklyHires_Portland = totalWeeklyHires_portland;
            TotalStudents_Portland = totalStudents_portland;
            UnhiredGraduates_Portland = unhiredGraduates_portland;

            NewStudents_Denver = newStudents_denver;
            WeeklyHires_Denver = weeklyHires_denver;
            TotalWeeklyApplications_Denver = totalWeeklyApps_denver;
            TotalWeeklyHires_Denver = totalWeeklyHires_denver;
            TotalStudents_Denver = totalStudents_denver;
            UnhiredGraduates_Denver = unhiredGraduates_denver;

            NewStudents_Seattle = newStudents_seattle;
            WeeklyHires_Seattle = weeklyHires_seattle;
            TotalWeeklyApplications_Seattle = totalWeeklyApps_seattle;
            TotalWeeklyHires_Seattle = totalWeeklyHires_seattle;
            TotalStudents_Seattle = totalStudents_seattle;
            UnhiredGraduates_Seattle = unhiredGraduates_seattle;

            NewStudents_Remote = newStudents_remote;
            WeeklyHires_Remote = weeklyHires_remote;
            TotalWeeklyApplications_Remote = totalWeeklyApps_remote;
            TotalWeeklyHires_Remote = totalWeeklyHires_remote;
            TotalStudents_Remote = totalStudents_remote;
            UnhiredGraduates_Remote = unhiredGraduates_remote;

            AvgDaysInJP = avgDaysInJP;
            TotalDaysInJP = totalDaysInJP;
        }
    }
}