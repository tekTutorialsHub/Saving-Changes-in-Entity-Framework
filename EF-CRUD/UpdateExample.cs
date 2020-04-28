using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCrud
{
    public class UpdateExample
    {

        public void Update()
        {
            //UpdateConnected();
            UpdateDisconnected();

            //UpdateDisconnected2();


            //UpdateMultipleRecords();

            //UpdateMultipleRecords();

        }


        private void UpdateConnected()
        {

            Department dep;

            //Connected Scenario
            using (EFContext db = new EFContext())
            {
                db.Database.Log = Console.WriteLine;

                dep = db.Departments.Where(d => d.Name == "Accounts").First();
                dep.Descr = "This is Accounts Department";
                db.SaveChanges();

                Console.WriteLine("Department {0} ({1}) is Updated ", dep.Name, dep.DepartmentID);
                Console.ReadKey();
            }

        }


        private void UpdateDisconnected()
        {

            Department dep;

            //Disconnected Scenario
            using (EFContext db = new EFContext())
            {
                Console.Clear();
                db.Database.Log = Console.WriteLine;
                dep = db.Departments.Where(d => d.Name == "Purchase").First();
            }

            dep.Descr = "Purchase Department-Disconnected Scenario";
            using (EFContext db = new EFContext())
            {

                db.Database.Log = Console.WriteLine;

                db.Entry(dep).State = System.Data.Entity.EntityState.Modified;

                //OR
                //db.Departments.Attach(dep);
                //db.Entry(dep).State = System.Data.Entity.EntityState.Modified;

                //OR
                //db.Departments.Add(dep);
                //db.Entry(dep).State = System.Data.Entity.EntityState.Modified;


                db.SaveChanges();
            }

            Console.WriteLine("Department {0} ({1}) is Updated ", dep.Name, dep.DepartmentID);
            Console.ReadKey();

        }



        private void updateDepartment()
        {
            updateDepartment1(2, "Purchase Department");
        }

        private void updateDepartment1(int id, string descr)
        {

            Department dep = new Department();
            dep.DepartmentID = id;
            dep.Descr = descr;

            using (EFContext db = new EFContext())
            {
                db.Database.Log = Console.WriteLine;

                db.Departments.Attach(dep);
                db.Entry(dep).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            Console.WriteLine("Department {0} ({1}) is Updated ", dep.Name, dep.DepartmentID);
            Console.ReadKey();

        }




        private void updateDepartment2(int id, string descr)
        {

            using (EFContext db = new EFContext())
            {
                db.Database.Log = Console.WriteLine;

                Department dep = db.Departments.Where(f => f.DepartmentID == id).FirstOrDefault();
                if (dep == null) throw new Exception("");

                dep.Descr = descr;
                db.SaveChanges();
            }

            Console.WriteLine("Records Updated");
            Console.ReadKey();

        }


        private void UpdateMultipleRecords()
        {

            List<Department> deps = new List<Department>();

            deps.Add(new Department { DepartmentID = 1, Descr = "Sales" });
            deps.Add(new Department { DepartmentID = 2, Descr = "Purchase" });
            deps.Add(new Department { DepartmentID = 3, Descr = "HR" });



            using (EFContext db = new EFContext())
            {
                db.Database.Log = Console.WriteLine;

                foreach (var item in deps)
                {
                    var dept = db.Departments.Where(f => f.DepartmentID == item.DepartmentID).FirstOrDefault();
                    if (dept == null) throw new Exception("");

                    dept.Descr = item.Descr;
                }

                db.SaveChanges();
            }

            Console.WriteLine("Records Updated ");
            Console.ReadKey();

        }


    }
}
