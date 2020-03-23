using DepartmentsEmployees.Data;
using DepartmentsEmployeesConsole.Models;
using EmployeesEmployees.Data;
using System;
using System.Collections.Generic;

namespace DeptAndEmployees
{
    class Program
    {
        static void Main(string[] args)
        {
            DepartmentRepository departmentRepo = new DepartmentRepository();

            Console.WriteLine("Getting All Departments:");
            Console.WriteLine();

            List<Department> allDepartments = departmentRepo.GetAllDepartments();

            foreach (Department dept in allDepartments)
            {
                Console.WriteLine($"{dept.Id} {dept.DeptName}");
            }
            Console.WriteLine("----------------------------");
            Console.WriteLine("Getting Department with Id 1");

            Department singleDepartment = departmentRepo.GetDepartmentById(1);

            Console.WriteLine($"{singleDepartment.Id} {singleDepartment.DeptName}");

            var empRepo = new EmployeeRepository();
            var employees = empRepo.GetAllEmployees();
            Console.WriteLine("Get all Employees with With their Department");
            foreach (var employee in employees)
            {
                Console.WriteLine($"{employee.FirstName} {employee.LastName} is in {employee.Department.DeptName}");
            }
            Console.WriteLine("Get an employee with the ID 2");

            var employeeWithId2 = empRepo.GetEmployeeById(2);

            Console.WriteLine($"Employee with Id 2 is {employeeWithId2.FirstName} {employeeWithId2.LastName}");


            //Adding Employee
            Console.WriteLine("Let's make a new Employee");
            Console.WriteLine("First Name");
            var firstName = Console.ReadLine();

            Console.WriteLine("Last Name");
            var lastName = Console.ReadLine();

            Console.WriteLine("Dept ID if known");
            var department = Console.ReadLine();

            var newEmployee = new Employee()
            {
                FirstName = firstName,
                LastName = lastName,
                DepartmentId = int.Parse(department),
            };

            empRepo.CreateNewEmployee(newEmployee);


            //Updating Employee
            Console.WriteLine("Let's update an Employee");
            //Console.Clear();
            for (int i = 0; i < employees.Count; i++)
            {
                Console.WriteLine($"{employees[i].Id}. {employees[i].FirstName} {employees[i].LastName}");
            }
            Console.WriteLine("Update which employee");
            var UpdateEmpId = int.Parse(Console.ReadLine());
            Console.WriteLine("First Name?");
            var firstNameUpdate = Console.ReadLine();
            Console.WriteLine("Last Name");
            var lastNameUpdate = Console.ReadLine();
            var UpdateEmployeeInfo = new Employee()
            {
                Id = UpdateEmpId,
                FirstName = firstNameUpdate,
                LastName = lastNameUpdate,
                DepartmentId = 2
            };
            empRepo.UpdateEmployee(UpdateEmpId, UpdateEmployeeInfo);
            Console.ReadLine();

            //Delete Employee
            Console.WriteLine("Let's delete an Employee, choose by putting in the Id of that Employee");
            foreach (var employee in employees)
            {
                Console.WriteLine($"{employee.FirstName} {employee.LastName} is in {employee.Department.DeptName}");
            }
            var deleteEmployeeId = int.Parse(Console.ReadLine());
            Employee employeeToDelete = empRepo.GetEmployeeById(deleteEmployeeId);
            Console.WriteLine($"Deleting {employeeToDelete.FirstName} {employeeToDelete.LastName}");
            empRepo.DeleteEmployee(deleteEmployeeId);


            //Adding Department
            //Department legalDept = new Department
            //{
            //    DeptName = "Legal"
            //};

            //departmentRepo.AddDepartment(legalDept);

            //Console.WriteLine("-------------------------------");
            //Console.WriteLine("Added the new Legal Department!");

            //Updating Dept
            Console.WriteLine("Let's update a Department");
            //Console.Clear();
            foreach (Department dept in allDepartments)
            {
                Console.WriteLine($"{dept.Id} {dept.DeptName}");
            }
            Console.WriteLine("Update which Deptartment?");
            var UpdateDeptId = int.Parse(Console.ReadLine());
            Console.WriteLine("You can only Rename at Dept, what do you want to call it?");
            var deptNameUpdate = Console.ReadLine();
            var UpdateDeptInfo = new Department()
            {
                Id = UpdateDeptId,
                DeptName = deptNameUpdate,
            };
            departmentRepo.UpdateDepartment(UpdateDeptId, UpdateDeptInfo);
            Console.ReadLine();

            //Delete Dept
            Console.WriteLine("which Department do you want to Delete, specify by Number?");
            foreach (Department dept in allDepartments)
            {
                Console.WriteLine($"{dept.Id}.) {dept.DeptName}");
            }
            var deleteDepartmentId = int.Parse(Console.ReadLine());
            Department departmentToDelete = departmentRepo.GetDepartmentById(deleteDepartmentId);
            Console.WriteLine($"Deleting {departmentToDelete.DeptName}");
            departmentRepo.DeleteDepartment(deleteDepartmentId);
        }
    }
}
