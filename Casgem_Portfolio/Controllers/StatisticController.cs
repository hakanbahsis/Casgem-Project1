using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Casgem_Portfolio.Models;
namespace Casgem_Portfolio.Controllers
{
    public class StatisticController : Controller
    {
        CasgemPortfolioEntities1 db = new CasgemPortfolioEntities1();
        // GET: Statistic
        public ActionResult Index()
        {
            ViewBag.employeeCount = db.TblEmployee.Count();
            ViewBag.maxSalaryEmployee = db.TblEmployee.Where(x => x.EmployeeSalary == db.TblEmployee.Max(y => y.EmployeeSalary)).Select(x => x.EmployeeName + " " + x.EmployeeSurname).FirstOrDefault();

            ViewBag.totalCityCount = db.TblEmployee.Distinct().GroupBy(x => x.EmployeeCity).Count();
            //  ViewBag.totalCityCount = db.TblEmployee.Select(x => x.EmployeeCity).Distinct().Count();
            ViewBag.avgEmployeeSalary = db.TblEmployee.Average(x => x.EmployeeSalary);

            ViewBag.countSoftwareDevelopment = db.TblEmployee.Where(x => x.EmployeeDepartmentId == db.TblDepartment.Where(z => z.DepartmentName == "Yazılım").Select(y => y.DepartmentId).FirstOrDefault()).Count();

            ViewBag.salary = db.TblEmployee.Where(x=>x.EmployeeCity=="Adana" || x.EmployeeCity=="Ankara").Sum(x => x.EmployeeSalary);
            var id =  db.TblDepartment.Where(x => x.DepartmentName == "Yazılım").FirstOrDefault();
            ViewBag.sumSalaryFromSoftwareDepartment = db.TblEmployee.Where(x=>x.EmployeeCity=="Ankara" && x.EmployeeDepartmentId==id.DepartmentId).Sum(x => x.EmployeeSalary);
           // ViewBag.sumSalaryFromSoftwareDepartment1 = db.TblEmployee.Where(x=>x.EmployeeCity=="Ankara" && x.EmployeeDepartmentId== db.TblDepartment.Where(z => z.DepartmentName == "Yazılım").Select(y => y.DepartmentId).FirstOrDefault()).Sum(x => x.EmployeeSalary);
            return View();
        }
    }
}