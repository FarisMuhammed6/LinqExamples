using System;

namespace LinqExamples
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Employee> employeeList = Data.GetEmployees();
            List<Department> departmentList = Data.GetDepartments();

            //Select and where Opertaors - Method Syntax;;

            /* var results = employeeList.Select(e => new
             {
                 FullName = e.FirstName + " " + e.LastName,
                 AnnualSalary = e.Salary

             }).Where(e => e.AnnualSalary>15000);
             foreach(var result in results)
             {
                 Console.WriteLine(result.FullName.PadRight(20) +  result.AnnualSalary.ToString().PadLeft(10));
             }*/


            //Select and where Opertaors - Method Syntax;;
            /*var results = from emp in employeeList
                          where emp.Id==3
                          select new{FullName = emp.FirstName + " " + emp.LastName,
                                     AnnualSalary = emp.Salary};
            employeeList.Add(new Employee
            {
                Id = 3,
                FirstName="Gokul",
                LastName = "Sudhir",
                Salary = 125334,
                IsManager  = true
            });
            foreach (var item in results)
            {
                Console.WriteLine(item.FullName.PadRight(20) + item.AnnualSalary.ToString().PadLeft(10));
            }

            Console.WriteLine("");*/



            //Join Operator - Method Syntax;
            /*var results = departmentList.Join(employeeList,
                           department => department.Id, employee => employee.DepartmentId,
                           (department, employee) => new
                           {
                               FullName = employee.FirstName + " " + employee.LastName,
                               AnnualSalary = employee.Salary,
                               departmentName = department.LongName
                           });
            foreach (var item in results2)
            {
                Console.WriteLine(item.FullName.PadRight(20) + item.AnnualSalary.ToString().PadLeft(10) +
                                      "\t"+item.departmentName);
            }*/

            //join Operator -  Query Syntax;
            var results = from dept in departmentList
                         join emp in employeeList
                         on dept.Id equals emp.DepartmentId
                         select new
                         {
                             FullName = emp.FirstName + " " + emp.LastName,
                             AnnualSalary = emp.Salary,
                             DepartmentName = dept.LongName
                         };
            foreach (var item in results)
            {
                Console.WriteLine(item.FullName.PadRight(20) + item.AnnualSalary.ToString().PadLeft(15)+item.DepartmentName.PadLeft(20));
            }

            Console.ReadLine();
        }
    }
    public class Employee
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public decimal Salary { get; set; }
        public bool IsManager { get; set; }
        public int DepartmentId { get; set; }
    }
    public class Department
    {
        public int Id { get; set; }
        public string? ShortName { get; set; }
        public string? LongName { get; set; }
    }
    public static class Data
    {
        public static List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();

            Employee employee = new Employee
            {
                Id = 1,
                FirstName = "Muhammed",
                LastName = "Faris",
                Salary = 12345,
                IsManager = true,
                DepartmentId = 1
            };
            employees.Add(employee);
            employee = new Employee
            {
                Id = 2,
                FirstName = "Drishtanth",
                LastName = "CK",
                Salary = 23456,
                IsManager = true,
                DepartmentId = 2
            };
            employees.Add(employee);
            employee = new Employee
            {
                Id = 3,
                FirstName = "Ashid",
                LastName = "Ahmed",
                Salary = 567890,
                IsManager = false,
                DepartmentId = 2
            };
            employees.Add(employee);
            employee = new Employee
            {
                Id = 3,
                FirstName = "Aflah",
                LastName = "Aboobacker",
                Salary = 456789,
                IsManager = false,
                DepartmentId = 3
            };
            employees.Add(employee);

            return employees;
        }

        public static List<Department> GetDepartments()
        {
            List<Department> departments = new List<Department>();

            Department department = new Department
            {
                Id = 1,
                ShortName = "HR",
                LongName = "Human Resources"
            };
            departments.Add(department);
            department = new Department
            {
                Id = 2,
                ShortName = "FN",
                LongName = "Finance"
            };
            departments.Add(department);
            department = new Department
            {
                Id = 3,
                ShortName = "TE",
                LongName = "Technology"
            };
            departments.Add(department);

            return departments;
        }

    }
}


