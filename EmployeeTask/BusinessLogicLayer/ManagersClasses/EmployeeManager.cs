using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Classes;
using DataAccessLayer.Models;
namespace BusinessLogicLayer.ManagersClasses
{
   public class EmployeeManager : EmployeeDA
    {

        //Here write Logic of Employee.
        public EmployeeManager(): base()
        {
        }

        public int GetStartIndex(int page, int pageSize)
        {
            int startIndex = pageSize * (page - 1);
            return startIndex;
        }
        public string Pagination(int totalRows, int pageSize, int page=1)
        {
            string pagination="";

            decimal value1 = (decimal)totalRows / (decimal)pageSize;

            int lastPage = (int)Math.Ceiling(value1);

            string URL = "GetNewPage";
         
            pagination += "<ul class='pagination'>";
            for (int counter = 1; counter <= lastPage; counter++)
            {
                if (counter == page)
                {
                    pagination += "<li class='active'><span onclick='GetAnotherPage(this)' class='Counter'>" + counter + "</span></li>";
                }
                else
                {
                    pagination += "<li ><span onclick='GetAnotherPage(this)' class='Counter'>" + counter + "</span></li>";
                }
            }
            pagination += "</ul>";
            return pagination;
        }

    }
}
