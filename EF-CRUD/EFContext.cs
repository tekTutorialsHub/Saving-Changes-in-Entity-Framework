using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;


namespace EFCrud
{
    public class EFContext : DbContext
    {
        public EFContext() : base("Name=EFCon")
        {
            Database.SetInitializer<EFContext>(new EFInitializer());
        }


    
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Territory> Territories { get; set; }
        public DbSet<SalesPerson> SalesPersons { get; set; }


    }

    public class EFInitializer :CreateDatabaseIfNotExists<EFContext>
    {
        protected override void Seed(EFContext db)
        {
            db.SaveChanges();

            Department dept;

            dept = new Department(){ Name = "Accounts" };
            db.Departments.Add(dept);
            db.Employees.AddRange(new List<Employee>() {
                                  new Employee {FirstName = "Sandeep", LastName = "Kaliyath", Department = dept },
                                  new Employee {FirstName = "Sameer", LastName = "Tejani", Department = dept },
                                  new Employee {FirstName = "Nuan", LastName = "Yu", Department = dept },
                                  new Employee {FirstName = "Susan", LastName = "Eaton", Department = dept },
                                });


            dept = new Department() { Name = "Purchase" };
            db.Departments.Add(dept);
            db.Employees.AddRange(new List<Employee>() {
                                  new Employee {FirstName = "Michael", LastName = "Sullivan", Department = dept },
                                  new Employee {FirstName = "John", LastName = "Wood", Department = dept },
                                  new Employee {FirstName = "Mary", LastName = "Dempsey", Department = dept },
                                  new Employee {FirstName = "Mark", LastName = "Benshoof", Department = dept },
                                });


            dept = new Department() { Name = "HR" };
            db.Departments.Add(dept);
            db.Employees.AddRange(new List<Employee>() {
                                  new Employee {FirstName = "Guy", LastName = "Gilbert", Department = dept },
                                  new Employee {FirstName = "Mark", LastName = "McArthur", Department = dept },
                                  new Employee {FirstName = "Britta", LastName = "Simon", Department = dept },
                                  new Employee {FirstName = "Rebecca", LastName = "Laszlo", Department = dept },
                                });

            dept = new Department() { Name = "Production" };
            db.Departments.Add(dept);
            db.Employees.AddRange(new List<Employee>() {
                                  new Employee {FirstName = "Jose", LastName = "Lugo", Department = dept },
                                  new Employee {FirstName = "Chris", LastName = "Okelberry", Department = dept },
                                  new Employee {FirstName = "Kim", LastName = "Abercrombie", Department = dept },
                                  new Employee {FirstName = "Ed", LastName = "Dudenhoefer", Department = dept },
                                });

            dept = new Department() { Name = "Management" };
            db.Departments.Add(dept);
            db.Employees.AddRange(new List<Employee>() {
                                  new Employee {FirstName = "Andrew", LastName = "Hill", Department = dept },
                                  new Employee {FirstName = "Ruth", LastName = "Ellerbrock", Department = dept },
                                  new Employee {FirstName = "Barry", LastName = "Johnson", Department = dept },
                                  new Employee {FirstName = "Sidney", LastName = "Higa", Department = dept },
                                });


            dept = new Department() { Name = "Sales" };
            db.Departments.Add(dept);
            db.Employees.AddRange(new List<Employee>() {
                                  new Employee {FirstName = "Frank", LastName = "Miller", Department = dept },
                                  new Employee {FirstName = "Kendall", LastName = "Keil", Department = dept },
                                  new Employee {FirstName = "Bob", LastName = "Hohman", Department = dept },
                                  new Employee {FirstName = "Pete", LastName = "Male", Department = dept },
                                  new Employee {FirstName = "Sudhir", LastName = "Chawla", Department = dept },
                                  new Employee {FirstName = "Anand", LastName = "Naik", Department = dept },
                                  new Employee {FirstName = "Hung-Fu", LastName = "Ting", Department = dept },
                                  new Employee {FirstName = "Min", LastName = "Su", Department = dept },
                                });


            db.Regions.Add(new Region() { Name = "Asia" });
            db.Regions.Add(new Region() { Name = "America" });
            db.Regions.Add(new Region() { Name = "Europe" });

            db.Territories.Add(new Territory() { Name = "India", Region = db.Regions.Local.Where(p => p.Name == "Asia").First()});
            db.Territories.Add(new Territory() { Name = "Japan", Region = db.Regions.Local.Where(p => p.Name == "Asia").First() });

            db.Territories.Add(new Territory() { Name = "USA", Region = db.Regions.Local.Where(p => p.Name == "America").First() });
            db.Territories.Add(new Territory() { Name = "Canada", Region = db.Regions.Local.Where(p => p.Name == "America").First() });
            db.Territories.Add(new Territory() { Name = "Mexico", Region = db.Regions.Local.Where(p => p.Name == "America").First() });

            db.Territories.Add(new Territory() { Name = "England", Region = db.Regions.Local.Where(p => p.Name == "Europe").First() });
            db.Territories.Add(new Territory() { Name = "Spain", Region = db.Regions.Local.Where(p => p.Name == "Europe").First() });

            //Adding Sales Perons
            db.SalesPersons.Add(new SalesPerson() { Employee = db.Employees.Local.Where(p => p.FirstName == "Frank").First(), Territory = db.Territories.Local.Where(t => t.Name == "USA").First()});
            db.SalesPersons.Add(new SalesPerson() { Employee = db.Employees.Local.Where(p => p.FirstName == "Kendall").First(), Territory = db.Territories.Local.Where(t => t.Name == "USA").First()});
            db.SalesPersons.Add(new SalesPerson() { Employee = db.Employees.Local.Where(p => p.FirstName == "Bob").First(), Territory = db.Territories.Local.Where(t => t.Name == "Mexico").First()});
            db.SalesPersons.Add(new SalesPerson() { Employee = db.Employees.Local.Where(p => p.FirstName == "Pete").First(), Territory = db.Territories.Local.Where(t => t.Name == "England").First()});
            db.SalesPersons.Add(new SalesPerson() { Employee = db.Employees.Local.Where(p => p.FirstName == "Sudhir").First(), Territory = db.Territories.Local.Where(t => t.Name == "India").First()});
            db.SalesPersons.Add(new SalesPerson() { Employee = db.Employees.Local.Where(p => p.FirstName == "Anand").First(), Territory = db.Territories.Local.Where(t => t.Name == "India").First()});
            db.SalesPersons.Add(new SalesPerson() { Employee = db.Employees.Local.Where(p => p.FirstName == "Hung-Fu").First(), Territory = db.Territories.Local.Where(t => t.Name == "Japan").First()});
            db.SalesPersons.Add(new SalesPerson() { Employee = db.Employees.Local.Where(p => p.FirstName == "Min").First(), Territory = db.Territories.Local.Where(t => t.Name == "Japan").First()});

            db.SaveChanges();

            base.Seed(db);
        }
    }

}
