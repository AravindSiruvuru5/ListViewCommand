using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ListviewCommand.Models
{
    class EmployeeDataList
    {
        ObservableCollection<Employee> employeeList = new ObservableCollection<Employee>
        {
            new Employee
            {
                EmployeeName="Scarlet",
                EmployeeId = 2013,
                Designation = "Senior Software Enggineer",
                Branch ="Uppal"
            },
             new Employee
            {
                EmployeeName="Loki",
                EmployeeId = 2014,
                Designation = "Senior Manager",
                Branch ="Uppal"
            },
              new Employee
            {
                EmployeeName="john",
                EmployeeId = 2015,
                Designation = "Senior HR",
                Branch ="Uppal"
            },

        };

        public ObservableCollection<Employee> GetEmoployeeList()
        {
            return employeeList;
        }

    }
}
