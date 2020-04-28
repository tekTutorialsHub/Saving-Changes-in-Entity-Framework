using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCrud
{
    public class DeleteExample
    {

        public void Delete()
        {

            //DeleteConnected();
            //DeleteDisconnected();
            //DeleteDisconnectedWithoutLoading();

            DeleteMultipleRecordsConnected();
            DeleteMultipleRecordsDisconnected();

        }



        public void DeleteConnected()
        {

            Department dep;

            //Connected Scenario
            using (EFContext db = new EFContext())
            {
                db.Database.Log = Console.WriteLine;

                dep = db.Departments.Where(d => d.Name == "Accounts").First();
                db.Departments.Remove(dep);
                db.SaveChanges();

                Console.WriteLine("Department {0} ({1}) is Deleted ", dep.Name, dep.DepartmentID);
                Console.ReadKey();
            }

        }



        public void DeleteDisconnected()
        {

            Department dep;

            //Disconnected Scenario
            using (EFContext db = new EFContext())
            {
                Console.Clear();
                db.Database.Log = Console.WriteLine;
                dep = db.Departments.Where(d => d.Name == "Production").First();
            }


            using (EFContext db = new EFContext())
            {

                db.Database.Log = Console.WriteLine;


                //This also works
                //db.Departments.Attach(dep);
                //db.Entry(dep).State = System.Data.Entity.EntityState.Deleted;

                db.Entry(dep).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }

            Console.WriteLine("Department {0} ({1}) is Deleted ", dep.Name, dep.DepartmentID);
            Console.ReadKey();

        }


        public void DeleteDisconnectedWithoutLoading()
        {
            Department dep;

            dep = new Department() { DepartmentID = 2 };

            using (EFContext db = new EFContext())
            {

                db.Database.Log = Console.WriteLine;

                db.Entry(dep).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();

            }
            Console.WriteLine("Department {0} is Deleted ", dep.DepartmentID);
            Console.ReadKey();

        }


        public void DeleteMultipleRecordsConnected()
        {

            //Deleting Multiple Records
            using (EFContext db = new EFContext())
            {

                db.Database.Log = Console.WriteLine;
                List<Department> deps = db.Departments.Take(2).ToList();
                db.Departments.RemoveRange(deps);

                try
                {
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
            Console.ReadKey();

        }


        public void DeleteMultipleRecordsDisconnected()
        {

            List<Department> deps = new List<Department>();
            deps.Add(new Department { DepartmentID = 1 });
            deps.Add(new Department { DepartmentID = 2 });

            //Deleting Multiple Records
            using (EFContext db = new EFContext())
            {

                db.Database.Log = Console.WriteLine;

                db.Entry(deps).State= System.Data.Entity.EntityState.Deleted;

                

                try
                {
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
            Console.ReadKey();

        }

    }
}
