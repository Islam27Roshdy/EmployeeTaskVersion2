using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace DataAccessLayer.Classes
{
    public class EmployeeDA : BasicRepository<Employee>
    {
        private readonly EmployeeDBModel employeeDBModel;
        public EmployeeDA(): base()
        {
            employeeDBModel = new EmployeeDBModel();
        }
        public List<Employee> Search(string fName , DateTime  StartDate, DateTime EndDate)
        {
            IEnumerable<Employee> query = employeeDBModel.Employees;
             
              if (StartDate != null)
              {
                if(fName != "")
                {
                    query = query.Where(x => x.BirthDay > StartDate && fName == x.FirstName);
                }
                else
                {
                    query = query.Where(x => x.BirthDay > StartDate);
                }
              }

              if (EndDate != null)
              {
                if (fName != "")
                {
                    query = query.Where(x => x.BirthDay < EndDate && fName == x.FirstName);

                }
                else
                {
                    query = query.Where(x => x.BirthDay < EndDate);
                }
             
              }
              
            // return employeeDBModel.Employees.Where(x => x.FirstName == fName).Where(x=> x.BirthDay > StartDate).Where(x => x.BirthDay < EndDate).ToList();

            return query.ToList();
        //   return employeeDBModel.Employees.Where(x => x.FirstName == fName || x.BirthDay > StartDate).Where(x=> x.FirstName=="7").ToList();
        }
        public List<EmployeeViewModel> GetOnePageEmployees(List<Employee> employees,int startindex, int pageSize)
        {
               return employees.OrderBy(x=> x.ID).Skip(startindex).Take(pageSize).
                Select(x=> new EmployeeViewModel {  BirthDate= x.BirthDay.ToString(), FirstName= x.FirstName,LastName=x.LastName}
                
               ).ToList();
        }
        //Here the Data Access Codes of Employee Model
    }
}
