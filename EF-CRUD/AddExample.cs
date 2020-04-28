using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCrud
{
    public class AddExample
    {

        public void Qry()
        {

            //AddSingleRecord();
            //AddListOfOjects();
            //AddListOfOjects1();

            AddListOfOjects2();

            //AddRelatedData1();

            //AddRelatedData2();
            //AddRelatedData3();

        }


        public void AddSingleRecord()
        {

            //Adding
            using (EFContext db = new EFContext())
            {

                db.Database.Log = Console.WriteLine;

                Department dep = new Department();
                dep.Name = "Secuirty";
                db.Departments.Add(dep);

                db.SaveChanges();

                Console.WriteLine("Department {0} ({1}) is added ", dep.Name, dep.DepartmentID);
                
            }

            Console.ReadKey();

        }

        public void AddListOfOjects()
        {

            using (EFContext db = new EFContext())
            {

                db.Database.Log = Console.WriteLine;

                List<Department> deps = new List<Department>();
                deps.Add(new Department { Name = "Dept1", Descr = "" });
                deps.Add(new Department { Name = "Dept2", Descr = "" });
                db.Departments.AddRange(deps);
                db.SaveChanges();

                Console.WriteLine("{0} Departments added ", deps.Count);
                Console.ReadKey();
            }

        }

        public void AddListOfOjects1()
        {

            //This wont add
            using (EFContext db = new EFContext())
            {

                db.Database.Log = Console.WriteLine;

                List<Department> deps = db.Departments.ToList();

                //These records are not added
                deps.Add(new Department { Name = "Dept3", Descr = "" });
                deps.Add(new Department { Name = "Dept4", Descr = "" });

                //This record is added
                db.Departments.Add(new Department { Name = "Dept5", Descr = "" });

                //db.Departments.AddRange(deps); //Adds all oth them

                db.SaveChanges();

                Console.WriteLine("{0} Departments added ", deps.Count);
                Console.ReadKey();
            }

        }

        public void AddListOfOjects2()
        {

            //This wont add
            using (EFContext db = new EFContext())
            {

                db.Database.Log = Console.WriteLine;

                //The deps contain 6 records
                List<Department> deps = db.Departments.ToList();

                //Two more records are added
                deps.Add(new Department { Name = "Dept3", Descr = "" });
                deps.Add(new Department { Name = "Dept4", Descr = "" });

                //All of them added 
                db.Departments.AddRange(deps); 

                db.SaveChanges();

                Console.WriteLine("{0} Departments added ", deps.Count);
                Console.ReadKey();
            }

        }

        public void AddRelatedData1()
        {

            // Adding Department & Employee 
            using (EFContext db = new EFContext())
            {

                db.Database.Log = Console.WriteLine;

                //Create new employee
                Employee emp = new Employee();
                emp.FirstName = "Anil";
                emp.LastName = "Kumble";


                // Creat a new department 
                Department dep = new Department();
                dep.Name = "Bowling";
                dep.Employees = new List<Employee>();
                dep.Employees.Add(emp);

                //Add dep to Departments
                //Note that we are not adding Employee. Employee is already added to Dep 
                db.Departments.Add(dep);

                //Save
                db.SaveChanges();

                Console.WriteLine("Department {0} ({1}) is added ", dep.Name, dep.DepartmentID);
                Console.WriteLine("Employee {0} ({1}) is added in the department {2} ", emp.FirstName, emp.EmployeeID, emp.Department.Name);
                Console.ReadKey();

            }
        }

        public void AddRelatedData2()
        {

            // Adding Department & Employee 
            using (EFContext db = new EFContext())
            {

                db.Database.Log = Console.WriteLine;

                // Creat a new department 
                Department dep = new Department();
                dep.Name = "Bowling";
                dep.Employees = new List<Employee>();
                dep.Employees.Add(new Employee { FirstName = "Anil", LastName = "Kumble" });
                dep.Employees.Add(new Employee { FirstName = "Harbajan", LastName = "Singh" });

                //Add dep to Departments
                //Note that we are not adding Employee. Employee is already added to Dep 
                db.Departments.Add(dep);

                //Save
                db.SaveChanges();

                Console.WriteLine("Department {0} ({1}) is added ", dep.Name, dep.DepartmentID);
                Console.ReadKey();

            }
        }

        public void AddRelatedData3()
        {


            // Adding Department & Employee
            using (EFContext db = new EFContext())
            {

                db.Database.Log = Console.WriteLine;

                // Add a Department
                Department dep = new Department();
                dep.Name = "Batting";


                //Add Employee with Deparmtnet
                Employee emp = new Employee();
                emp.FirstName = "Rahul";
                emp.LastName = "Drvid";
                emp.Department = dep;

                //db.Departments.Add(dep);
                db.Employees.Add(emp);

                //Save
                db.SaveChanges();

                Console.WriteLine("Department {0} ({1}) is added ", dep.Name, dep.DepartmentID);
                Console.WriteLine("Employee {0} ({1}) is added in the department {2} ", emp.FirstName, emp.EmployeeID, emp.Department.Name);
                Console.ReadKey();

            }

        }

    }

}
